using OxyPlot;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using tesy.mvvm_framework.view_model;
using LineSeries = OxyPlot.Series.LineSeries;

namespace tesy
{
    public partial class CustomUserControl: UserControl
    {
        private bool isDrawing = false;
        private readonly ChartInputModelView chartInputModelView;


        public CustomUserControl()
        {
            InitializeComponent();
            chartInputModelView = new ChartInputModelView(this.drawChart);
            
            // The DataContext serves as the starting point of Binding Paths
             DataContext = chartInputModelView;
            plotModelUIElement.Model = Drawer.initializePlotModelWithAxes();
        }

        
        private void data2plot(List<double> points)
        {
            LineSeries series = Drawer.generateLineSeriesBasedOnListOfPoints(points);
            plotModelUIElement.Model.Series.Add(series);
        }
       

        private void drawChart()
        {
            if (!isDrawing) {

                Console.WriteLine("Drawing...");
                isDrawing = true; // To disable multiple click event



                // Map points to one-dimensional list
                List<double> points = new List<double>();
                for(int i = 0; i < chartInputModelView.numberOfRows; i++)
                {
                    for (int j = 0; j < chartInputModelView.numberOfColumns; j++) {
                        points.Add(chartInputModelView.matrixValues[i, j]);
                    }
                }


                // Getting bitmap out of 2d array
                System.Drawing.Bitmap bitmapImage = Drawer.Array2DToBitmap(chartInputModelView.matrixValues);
                var bitmapSource = Drawer.getBitmapSource(bitmapImage);

                // Creating brush for plot to be rendered
                var brush = new System.Windows.Media.ImageBrush(bitmapSource);
                oxyPlot2.PlotAreaBackground = brush;



                // Assign series of points to plot
                data2plot(points);


                // Sort axes ticks arrays so we can determine the max and min value
                chartInputModelView.xResValues.Sort();
                chartInputModelView.yResValues.Sort();

                // Get axes
                OxyPlot.Axes.Axis xAxis = Drawer.getAxisByKey(plotModelUIElement.Model, "XAxis");
                OxyPlot.Axes.Axis yAxis = Drawer.getAxisByKey(plotModelUIElement.Model, "YAxis");


                // Modify axes based on new data
                // Remove below comments to update axes according to data
                // Drawer.modifyAxisData(ref xAxis, xResValues[xResValues.Count - 1], xResValues[0], chartInputModelView.xRes, OxyColor.FromRgb(100, 10, 10));
                // Drawer.modifyAxisData(ref yAxis, yResValues[yResValues.Count - 1], yResValues[0], chartInputModelView.yRes, OxyColor.FromRgb(0, 0, 100));

                double w = chartInputModelView.numberOfRows * chartInputModelView.xRes;
                double h = chartInputModelView.numberOfColumns * chartInputModelView.yRes;

                // double widthAdjustment = Math.Abs(plotModelUIElement.Model.PlotArea.Width - plotModelUIElement.Model.PlotArea.Height);
                plotModelUIElement.Width = w != 0 ? w : plotModelUIElement.Width;
                plotModelUIElement.Height = h != 0 ? h : plotModelUIElement.Height;

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
            if (plotModelUIElement.Model != null)
            {
                double w = chartInputModelView.numberOfRows * chartInputModelView.xRes;
                double h = chartInputModelView.numberOfColumns * chartInputModelView.yRes;

                // double widthAdjustment = Math.Abs(plotModelUIElement.Model.PlotArea.Width - plotModelUIElement.Model.PlotArea.Height);
                plotModelUIElement.Width = w != 0 ? w : plotModelUIElement.Width;
                plotModelUIElement.Height = h != 0 ? h : plotModelUIElement.Height;
            }
        }

    }
}
