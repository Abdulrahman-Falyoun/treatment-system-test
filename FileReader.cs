using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tesy
{
    public class FileReader
    {

        // Path were input files are stored from solution directory
        private String pathToDataFiles = "\\tesy\\data_files\\";
        public FileReader() { }
        public FileReader(String fileName) {
            this.fileName = fileName;
        }


        /**
         * Getting directory from root to current folder
         * 
         * */
        private String getBaseDirectory() {
            return VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName + pathToDataFiles;
        }

        /**
         * Method to read data from file as line by line
         * each line expected to be a string of double value
         * we try to parse the value, if it's a double we add it to return value
         * @return {list<double>} 
         * */
        public List<double> readValuesFromFile() {
            List<double> res = new List<double>();
            // Getting the root directory from system to file
            String path = getBaseDirectory();
            String fullPath = path + fileName;

            using (var reader = new StreamReader(fullPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    // Parsing
                    double valueToBeReferenced;
                    bool parsingDone = Double.TryParse(line, out valueToBeReferenced);
                    if(parsingDone)
                    {
                        res.Add(valueToBeReferenced);
                    }
                }

                reader.Close();
            }

            return res;
        }

        /**
         * Method to read data from file as line by line
         * each line expected to be a string of double value
         * we try to parse the value, if it's a double we add it to return value
         * here we try to read the file for 2d array in Column-major order
         * @param {int} number of rows as n
         * @param {int} number of columns as m
         * @return {double[,]} 
         * */
        public double[,] readFileAs2D(int n, int m)
        {
            double[,] res = new double[n, m];
            String path = getBaseDirectory();
            String fullPath = path + fileName;
            using (var reader = new StreamReader(fullPath))
            {
                string line;
                int nRowCounter = 0;
                int mColumnCounter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    // if we hit the final row, we have to reset the row to zero and increament the column number by one
                    if (nRowCounter >= n) {
                        // Resetting row
                        nRowCounter = 0;
                        // Increase column by one to acheive column major order
                        mColumnCounter++;
                    }

                    // Parsing
                    double valueToBeReferenced;
                    bool parsingDone = Double.TryParse(line, out valueToBeReferenced);
                    if (parsingDone)
                    {
                        res[nRowCounter,mColumnCounter] = valueToBeReferenced;
                        // Increasing row by one and we still at the same column
                        nRowCounter++;
                    }

                }
                reader.Close();
            }

            return res;
        }


        public String fileName { set; get; }
    }
}
