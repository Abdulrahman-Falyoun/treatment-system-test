using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesy.mvvm_framework.model
{


    class ChartInput
    {
        public int numberOfRows {
            set; get;
        }
        public int numberOfColumns
        {
            set; get;
        }

        public double xRes { set; get; }
        public double yRes { set; get; }

        public String filesPaths { set; get; }
        public String xLabel { set; get; }

        public String yLabel { set; get; }

    }
}
