using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Axis = OxyPlot.Axes.Axis;
using LinearAxis = OxyPlot.Axes.LinearAxis;
using LineSeries = OxyPlot.Series.LineSeries;

namespace tesy
{
    class Drawer
    {
        public void draw() { }

        public static PlotModel initializePlotModelWithAxes() {
            
            // Plot model constructing
            PlotModel plotModel = getPlotModel(
                "Treatement system test",
                TitleHorizontalAlignment.CenteredWithinPlotArea,
                "Legend",
                LegendOrientation.Horizontal,
                LegendPlacement.Inside,
                LegendPosition.TopRight
                );

            // Initializing axes
            Axis xAxis = getAxis("XAxis", "X Axis", AxisPosition.Bottom);
            Axis yAxis = getAxis("YAxis", "Y Axis", AxisPosition.Left);


            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);


            // Prepear initial series
            LineSeries lineSerie = new LineSeries
            {
                StrokeThickness = 2,
                CanTrackerInterpolatePoints = false,
                Title = "Value",
            };

            plotModel.Series.Add(lineSerie);

            return plotModel;
        }

        // Loop over list of values and map them with an index to construct a point
        public static LineSeries generateLineSeriesBasedOnListOfPoints(List<double> points) {
            var series = new LineSeries();
            int i = 0;
            foreach (double val in points)
            {
                series.Points.Add(new DataPoint(i, val));
                i++;
            }
            return series;
        }
        public static LinearAxis getAxis(String key, String title, AxisPosition axisPosition)
        {
            return new LinearAxis()
            {
                Key = key,
                Position = axisPosition,
                Title = title,
            };
        }

        public static PlotModel getPlotModel(
            String title,
            TitleHorizontalAlignment titleHorizontalAlignment,
            String legendTitle,
            LegendOrientation legendOrientation,
            LegendPlacement legendPlacement,
            LegendPosition legendPosition) {
            return new PlotModel
            {
                Title = title,
                TitleHorizontalAlignment = titleHorizontalAlignment,
                LegendTitle = legendTitle,
                LegendOrientation = legendOrientation,
                LegendPlacement = legendPlacement,
                LegendPosition = legendPosition
            };

        }

        public static void modifyAxisData(
            ref Axis axis,
            double maxValue,
            double minValue,
            double majorStep,
            OxyColor tickLineColor)
        {
            axis.MajorStep = majorStep;
            axis.Maximum = maxValue;
            axis.Minimum = minValue;
            axis.TicklineColor = tickLineColor;
        }

        // Filtering axes by key
        public static Axis getAxisByKey(PlotModel plotModel, String key)
        {
            return plotModel.Axes.FirstOrDefault(s => s.Key == key);
        }



        public static Bitmap Array2DToBitmap(double[,] integers)
        {
            int width = integers.GetLength(0);
            int height = integers.GetLength(1);

            int stride = width * 4;//int == 4-bytes

            Bitmap bitmap = null;

            unsafe
            {
                fixed (double* intPtr = &integers[0, 0])
                {
                    bitmap = new Bitmap(width, height, stride, PixelFormat.Format32bppRgb, new IntPtr(intPtr));
                }
            }

            return bitmap;
        }

        public static BitmapSource getBitmapSource(Bitmap bitmapImage) {

            return Imaging.CreateBitmapSourceFromHBitmap(bitmapImage.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        }
    }


    
}
