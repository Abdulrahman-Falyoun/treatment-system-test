using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tesy.mvvm_framework.model;

namespace tesy.mvvm_framework.view_model
{
    class ChartInputModelView : ObservableObject
    {
        private ChartInput chartInput;

        public ChartInputModelView() {
            chartInput = new ChartInput
            {
                filesPaths = "values_matrix.txt;xGrid.txt;yGrid.txt",
                numberOfRows = 512,
                numberOfColumns = 125,
                xRes = 2,
                yRes = 1.5,
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
    }
}
