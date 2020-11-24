using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using tesy.mvvm_framework.model;

namespace tesy.mvvm_framework.view_model
{
    class ChartInputModelView : ObservableObject
    {
        private ChartInput chartInput;
        private readonly Action drawChart;
        public ChartInputModelView(Action drawChartAction) {
            this.drawChart = drawChartAction;

            chartInput = new ChartInput
            {
                filesPaths = "values_matrix.txt;xGrid.txt;yGrid.txt",
                numberOfRows = 512,
                numberOfColumns = 125,
                xRes = 2,
                yRes = 1.5,
                xResValues = new List<double>(),
                yResValues = new List<double>(),
                xLabel = "X Label",
                yLabel = "Y Label"
            };
        }
        public String filesPaths
        {
            get { return chartInput.filesPaths;  }
            set
            {
                if(chartInput.filesPaths != value)
                {
                    chartInput.filesPaths = filesPaths;
                    RaisePropertyChangedEvent("filesPaths");
                }
                
            }
        }
        public int numberOfRows
        {
            get { return chartInput.numberOfRows; }
            set
            {
                Console.WriteLine("Number of rows: " + value);
                if (chartInput.numberOfRows != value)
                {
                    chartInput.numberOfRows = value;
                    RaisePropertyChangedEvent("numberOfRows");
                }
            }
        }

        public int numberOfColumns
        {
            get { return chartInput.numberOfColumns; }
            set
            {
                if (chartInput.numberOfColumns != value)
                {
                    chartInput.numberOfColumns = value;
                    RaisePropertyChangedEvent("numberOfColumns");
                }
            }
        }
        public double xRes
        {
            get { return chartInput.xRes; }
            set
            {
                if (chartInput.xRes != value)
                {
                    chartInput.xRes = value;
                    RaisePropertyChangedEvent("xRes");
                }
            }
        }
        public double yRes
        {
            get { return chartInput.yRes; }
            set
            {
                if (chartInput.yRes != value)
                {
                    chartInput.yRes = value;
                    RaisePropertyChangedEvent("yRes");
                }
            }
        }
        public String xLabel
        {
            get { return chartInput.xLabel; }
            set
            {
                if(chartInput.xLabel != value)
                {
                    chartInput.xLabel = xLabel;
                    RaisePropertyChangedEvent("xLabel");
                }
                
            }
        }
        public String yLabel
        {
            get { return chartInput.yLabel; }
            set
            {
                if(chartInput.yLabel != value)
                {
                    chartInput.yLabel = yLabel;
                    RaisePropertyChangedEvent("yLabel");
                }
                
            }
        }
        public double[,] matrixValues
        {
            get { return chartInput.matrixValues; }
            set
            {
                chartInput.matrixValues = value;
                RaisePropertyChangedEvent("matrixValues");
            }
        }
        public List<double> xResValues
        {
            get { return chartInput.xResValues; }
            set
            {
                chartInput.xResValues = value;
                RaisePropertyChangedEvent("xResValues");
            }
        }

        public List<double> yResValues
        {
            get { return chartInput.yResValues; }
            set
            {
                chartInput.yResValues = value;
                RaisePropertyChangedEvent("yResValues");
            }
        }
        private void readContentFromFiles()
        {

            String[] files = filesPaths.Split(';');

            FileReader fileReader = new FileReader();
            foreach (String file in files)
            {
                fileReader.fileName = file;
                switch (file)
                {
                    case "values_matrix.txt":
                        chartInput.matrixValues = new double[numberOfRows, numberOfColumns];
                        chartInput.matrixValues = fileReader.readFileAs2D(numberOfRows, numberOfColumns);
                        break;


                    case "xGrid.txt":
                        chartInput.xResValues = fileReader.readValuesFromFile();
                        break;

                    case "yGrid.txt":
                        chartInput.yResValues = fileReader.readValuesFromFile();
                        break;

                }

            }
        }
        public ICommand readContentCommand
        {
            get
            {
                return new DelegateCommand(readContentFromFiles);
            }
        }
        public ICommand drawChartCommand
        {
            get {
                if(readContentCommand.CanExecute(null))
                {
                    readContentCommand.Execute(null);
                }
                return new DelegateCommand(drawChart);
            }
        }
    }
}
