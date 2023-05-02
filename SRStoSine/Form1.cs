using DevExpress.Data.Filtering.Helpers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;

namespace SRStoSine
{
   public partial class Form1 : Form
   {
    public double lastDateValue;
    public List<DataPoint> AllData;

    public Form1()
     {
     InitializeComponent();
   
     }

    private void button1_Click(object sender, EventArgs e)
    {
      ClearAll();


      // SignalProperties DataGridView'deki her sat?r için i?lem yap
      for (int i = 0; i < SignalProperties.Rows.Count; i++)
      {
        // De?er bo? de?ilse i?lem yap
        if (SignalProperties.Rows[i].Cells[4].Value != null )
        {
          // datagridview'deki ilgili de?erleri al ve de?i?kenlere ata
          int sampleRate = Convert.ToInt32(SignalProperties.Rows[i].Cells[7].Value); //fs
          int SignalRowsCount = SignalProperties.Rows.Count;
          int sample = Convert.ToInt32(SignalProperties.Rows[i].Cells[8].Value);
          double amplitude = Convert.ToDouble(SignalProperties.Rows[i].Cells[0].Value);
          double frequency = Convert.ToDouble(SignalProperties.Rows[i].Cells[4].Value);
          int repeatAllCycle = Convert.ToInt32(SignalProperties.Rows[i].Cells[9].Value);
          double phase = Convert.ToDouble(SignalProperties.Rows[i].Cells[2].Value);
          double offset = Convert.ToDouble(SignalProperties.Rows[i].Cells[1].Value);
          double ratio = Convert.ToDouble(SignalProperties.Rows[i].Cells[5].Value);
          int cycle = Convert.ToInt32(SignalProperties.Rows[i].Cells[3].Value);

          if (frequency <= 0)
          {
            MessageBox.Show("Frekans de?eri s?f?rdan büyük olmal?d?r.", "Uyar?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
          }
          if (cycle <= 0)
          {
            MessageBox.Show("Frekans de?eri s?f?rdan büyük olmal?d?r.", "Uyar?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
          }

          if (ratio == 0)
          {
            MessageBox.Show("Ratio de?eri s?f?rdan farkl? olmal?d?r.", "Uyar?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
          }

          if (sampleRate <= 0 || sample <= 0)
          {
            MessageBox.Show("Sample Rate ve Sample de?erleri s?f?rdan büyük olmal?d?r.", "Uyar?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
          }

          if (amplitude <= 0)
          {
            MessageBox.Show("Amplitude de?eri s?f?rdan büyük olmal?d?r.", "Uyar?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
          }

          // Sinüs veri noktalar?n? hesapla ve çiz
          List<DataPoint> sinusPoints = CalculateSinusPoints(amplitude, frequency, phase, sampleRate, sample, ratio, offset, cycle, AllData, true);
          List<DataPoint> signalLevels = CalculateSinusPoints(amplitude, frequency, phase, sampleRate, sample, ratio, offset, 1, new List<DataPoint> { new DataPoint(0.0, 0.0) }, false);

          // Tüm sinüs sinyallerini tek cycle olacak ?ekilde level olarak çiz
          DrawSinusSignal(signalLevels, chartControl2, false, SignalRowsCount - i - 1);

          // RepatAllCycle De?eri kadar bütün listeyi birdaha üstüne kopyala
          int originalAllDataCount = AllData.Count;

          for (int j = 1; j < repeatAllCycle; j++)
          {
            double lastTimeValue = AllData.Last().Date;
            List<DataPoint> lastCopy = new List<DataPoint>(AllData.Take(originalAllDataCount));
            CopySeries(lastCopy, lastTimeValue);
          }
        }
      }

      // Tüm sinüs sinyallerini çiz
      DrawSinusSignal(AllData, chartControl1, true, 0);

      // Veri noktalar?n? dosyaya kaydet
      SaveDataPointsToFile(AllData);
    }

    private void DrawSinusSignal(List<DataPoint> sinusPoints,DevExpress.XtraCharts.ChartControl chart,bool AllDataTrue,int SignalRow)
    {
      // E?er AllDataTrue ise, tüm veri noktalar?n? tek bir seri olarak çizdir
      if (AllDataTrue==true)
      {
        Series series = new Series("Sin All Signal", ViewType.Line);// Yeni bir seri olu?tur
        series.DataSource = sinusPoints; // Seri için veri kayna??n? ayarla
        series.ArgumentDataMember = "Date"; // Serinin x eksenindeki de?erleri temsil eden özellik
        series.ValueDataMembers.AddRange("Value");// Serinin y eksenindeki de?erleri temsil eden özellik
        chart.Series.Add(series);// Seriyi grafile ekle
        LineSeriesView view = (LineSeriesView)series.View;// Seri görünümünü al
        view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;// Seri üzerindeki noktalar? göster
      }
      else
      {
        // AllDataTrue de?ilse, belirtilen SignalRow de?erine göre level ad?n? kullanarak seri olu?tur
        Series series = new Series("Level" + SignalRow.ToString(), ViewType.Line);
        series.DataSource = sinusPoints;
        series.ArgumentDataMember = "Date";
        series.ValueDataMembers.AddRange("Value");
        chart.Series.Add(series);
        LineSeriesView view = (LineSeriesView)series.View;
        view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
      }

      // X eksenini özelle?tir
      XYDiagram diagram = (XYDiagram)chart.Diagram;
      diagram.AxisX.Title.Text = "Zaman(s)";
      diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

      // Y eksenini özelle?tir
      diagram.AxisY.Title.Text = "Genlik";
      diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
    }

    private List<DataPoint>  CalculateSinusPoints(double amplitude, double frequency, double phase, int sampleRate, int sample, double ratio, double offset,int cycle,List<DataPoint> existingData,bool AllDataTrue)
    {
      double offsetDate = 0.0;
      // E?er mevcut veriler varsa, son verinin zaman de?erini offsetDate olarak kullan
      if (existingData != null)
      {
        if (existingData.Count == 0)
        {

        }
        else
        {
          offsetDate = existingData.LastOrDefault().Date;
        }
      }
      else
      {
        AllData = new List<DataPoint>();
      }

      List<DataPoint> points = new List<DataPoint>(sample * cycle);
      // Veri noktalar?n? olu?tur ve döngü boyunca sinusoidal de?erler hesapla
      for (int i = 0; i < sample * cycle; i++)
      {
        double x = (double)i / sampleRate;
        double y = (double)((amplitude * ratio) * Math.Sin((2 * Math.PI * i * frequency + phase) / sampleRate) + offset);
        // E?er AllDataTrue ise, tüm veri noktalar?n? AllData listesine ekle
        if (AllDataTrue)
        {
          AllData.Add(new DataPoint(x + offsetDate, y));
        }

        // Hesaplanan veri noktas?n? points listesine ekle
        points.Add(new DataPoint(x + offsetDate, y));
      }

      // Hesaplanan veri noktalar?n?n listesini döndür
      return points;
    }

    private List<DataPoint> CopySeries(List<DataPoint> DataPoints, double lastTimeValue)
    {
      List<DataPoint> CopyPoints = new List<DataPoint>();
      List<DataPoint> TempPoints = new List<DataPoint>();

      foreach (DataPoint point in DataPoints)
      {
        DataPoint newDataPoint = new DataPoint(point.Date + lastTimeValue, point.Value);
        CopyPoints.Add(newDataPoint);
        TempPoints.Add(newDataPoint);
      }

      AllData.AddRange(TempPoints);

      return CopyPoints;
    }

    public void SaveDataPointsToFile(List<DataPoint> dataPoints)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog
      {
        Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
        Title = "Save Data Points File",
        DefaultExt = "txt"
      };

      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        string filePath = saveFileDialog.FileName;

        StringBuilder sb = new StringBuilder();

        // Sütun ba?l?klar?n? ekle
        sb.AppendLine("Time\tForce\tEnable\tEnableForce");

        // Verileri ekle
        foreach (DataPoint point in dataPoints)
        {
          sb.AppendLine(String.Format("{0:F6}\t{1:F6}\t{2:F6}\t{3:F6}", point.Date, point.Value, 1.000000, 1.000000));
        }

        // Dosyaya yaz
        File.WriteAllText(filePath, sb.ToString());
      }
    }

    public class DataPoint
    {
      public double Date { get; set; } = 0.0;
      public double Value { get; set; }=0.0;
      public DataPoint(double date, double value)
      {
        this.Date = date;
        this.Value = value;
      }

    }

    private void SaveChartToPdf(ChartControl chart, string filePath)
    {
      // ChartControl için PDF d??a aktarma seçeneklerini olu?tur
      PrintableComponentLink link = new PrintableComponentLink();

      // Ba?lant?ya ChartControl'ü ekle
      link.Component = chart;

      // PrintingSystem nesnesi olu?tur
      PrintingSystem ps = new PrintingSystem();

      // Sayfa boyutunu ve yönlendirmesini ayarla
      ps.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
      ps.PageSettings.Landscape = true;
      ps.PageSettings.PageSettings.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
     

      // PDF dosyas?n? olu?tur ve kaydet

      // PrintingSystem nesnesini ba?lant?ya ekle
      link.PrintingSystem = ps;

      link.PrintingSystem.Document.AutoFitToPagesWidth = 1;

      // PDF dosyas?n? olu?tur ve kaydet
      link.CreateDocument();
      link.ExportToPdf(filePath);
    }
  

    private void button3_Click(object sender, EventArgs e)
    {
      // Dosya kaydetme ileti?im kutusunu aç
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
      saveFileDialog.Title = "Save Chart as PDF";
      saveFileDialog.DefaultExt = ".pdf";

      // Kullan?c? dosya ad?n? ve konumunu seçtikten sonra, ChartControl'ü PDF olarak kaydet
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        SaveChartToPdf(chartControl2, saveFileDialog.FileName);
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      ClearAll();
    }

    private void ClearAll()
    {
      chartControl1.Series.Clear();
      chartControl2.Series.Clear();
      if (AllData !=null)
      {
        AllData.Clear();
      }
    }
  }
}

