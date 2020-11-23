using OxyPlot;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using LineSeries = OxyPlot.Series.LineSeries;

namespace tesy
{
    public partial class CustomUserControl : UserControl
    {
        private bool isDrawing = false;
        private double[,] matrixValues;
        private List<double> xResValues;
        private List<double> yResValues;
        private int nValue, mValue;
        private String[] files;
        double xAxisStep;
        double yAxisStep;
        public CustomUserControl()
        {
            InitializeComponent();
            plotModelUIElement.Model = Drawer.initializePlotModelWithAxes();
        }

        private void readContentFromFiles() {

            FileReader fileReader = new FileReader();
            foreach (String file in files)
            {
                fileReader.fileName = file;
                switch (file)
                {
                    case "values_matrix.txt":
                        matrixValues = new double[nValue, mValue];
                        matrixValues = fileReader.readFileAs2D(nValue, mValue);
                        break;


                    case "xGrid.txt":
                        xResValues = new List<double>();
                        xResValues = fileReader.readValuesFromFile();
                        break;

                    case "yGrid.txt":
                        yResValues = new List<double>();
                        yResValues = fileReader.readValuesFromFile();
                        break;

                }

            }
        }
        private void data2plot(List<double> points)
        {
            LineSeries series = Drawer.generateLineSeriesBasedOnListOfPoints(points);
            plotModelUIElement.Model.Series.Add(series);
        }
        private void parseDataFromUI(){
            try
            {
                nValue = int.Parse(n.Text.ToString());
                mValue = int.Parse(m.Text.ToString());
                this.files = filesName.Text.ToString().Split(';');
                xAxisStep = double.Parse(xRes.Text.ToString());
                yAxisStep = double.Parse(yRes.Text.ToString());
            } catch(System.Exception e)
            {
                throw new Exception("Could not parse data, please make sure your entering correct type: " + e.Message);
            }
            
        }

       
        private void onDrawClicked(object sender, RoutedEventArgs e)
        {
            if (!isDrawing) {

                Console.WriteLine("Drawing...");
                isDrawing = true; // To disable multiple click event

                try
                {
                    parseDataFromUI(); // Get data from UI elements names to local data members

                }
                catch (System.Exception exception)
                {
                    Console.WriteLine(exception);
                    isDrawing = false;
                    return;
                }


                    readContentFromFiles();


                // Map points to one-dimensional list
                List<double> points = new List<double>();
                for(int i = 0; i < nValue; i++)
                {
                    for (int j = 0; j < mValue; j++) {
                        points.Add(matrixValues[i, j]);
                    }
                }


                // Getting bitmap out of 2d array
                System.Drawing.Bitmap bitmapImage = Drawer.Array2DToBitmap(matrixValues);
                var bitmapSource = Drawer.getBitmapSource(bitmapImage);

                // Creating brush for plot to be rendered
                var brush = new System.Windows.Media.ImageBrush(bitmapSource);
                oxyPlot2.PlotAreaBackground = brush;



                // Assign series of points to plot
                data2plot(points);


                // Sort axes ticks arrays so we can determine the max and min value
                xResValues.Sort();
                yResValues.Sort();

                // Get axes
                OxyPlot.Axes.Axis xAxis = Drawer.getAxisByKey(plotModelUIElement.Model, "XAxis");
                OxyPlot.Axes.Axis yAxis = Drawer.getAxisByKey(plotModelUIElement.Model, "YAxis");


                // Modify axes based on new data
                // Remove below comments to update axes according to data
                // Drawer.modifyAxisData(ref xAxis, xResValues[xResValues.Count - 1], xResValues[0], xAxisStep, OxyColor.FromRgb(100, 10, 10));
                // Drawer.modifyAxisData(ref yAxis, yResValues[yResValues.Count - 1], yResValues[0], yAxisStep, OxyColor.FromRgb(0, 0, 100));


                plotModelUIElement.Model.InvalidatePlot(true); // To refresh the UI chart

                isDrawing = false; // You're now able to draw another chart
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            plotModelUIElement.LayoutUpdated += OnLayoutUpdated;
        }
        private void OnLayoutUpdated(object sender, EventArgs e)
        {
            Console.WriteLine("OnLayoutUpdated");
            if (plotModelUIElement.Model != null)
            {
                double w = nValue * xAxisStep;
                double h = mValue * yAxisStep;

                // double widthAdjustment = Math.Abs(plotModelUIElement.Model.PlotArea.Width - plotModelUIElement.Model.PlotArea.Height);
                plotModelUIElement.Width = w != 0 ? w : plotModelUIElement.Width;
                plotModelUIElement.Height = h != 0 ? h : plotModelUIElement.Height;
            }
        }

    }
}
