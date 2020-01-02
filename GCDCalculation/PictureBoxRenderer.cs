using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GCDCalculation
{
    class PictureBoxRenderer : IRenderer
    {

        private static int _width = 300, _height = 300;
        private Thread _backgroundThread;
        //private PictureBox _pictureBox;
        private Chart _chart;
        private Form _underlyingForm = new Form() {
             Width = _width, Height = _height
        };

        public PictureBoxRenderer()
        {
            _backgroundThread = new Thread(() => Application.Run(_underlyingForm)) {
                IsBackground = true,
                Name = "bgThread"
            };
            _chart = new Chart() {
                Location = new System.Drawing.Point(0, 0),
                //Size = new System.Drawing.Size(_width, _height),
                ClientSize = new System.Drawing.Size(_width, _height-50),
                Parent = _underlyingForm,
                Visible = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                
            };

            _chart.ChartAreas.Add(new ChartArea());
            _chart.Legends.Add(new Legend());
            _chart.Series.Add(new Series());
            _chart.Series.Add(new Series());

        }
        public void Render(TimeSpan first, TimeSpan second, Orientation orientation = Orientation.Vertical)
        {
            SeriesChartType chartType = 0;
            switch (orientation)
            {
                case Orientation.Horizontal:
                    _chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                    chartType = SeriesChartType.Bar;
                    break;
                case Orientation.Vertical:
                    _chart.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
                    chartType = SeriesChartType.Column;
                    break;
                    
            }

            _chart.Series[0].ChartType = _chart.Series[1].ChartType = chartType;
            _chart.Series[0].Points.AddXY(1, first.TotalMilliseconds);
            _chart.Series[1].Points.AddXY(2, second.TotalMilliseconds);

            //_chart.DataSource = new[] { first.TotalMilliseconds, second.TotalMilliseconds };
            _backgroundThread.Start();
        }

        public void SetDataLegend(string firstName, string secondName)
        {
            _chart.Series[0].LegendText = firstName;
            _chart.Series[1].LegendText = secondName;
        }

        public void TerminateThread() => _underlyingForm.Invoke((Action)(() => Application.Exit()));
    }
}
