using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {

        /// <summary>
        /// Method to read a specific file with the good path
        /// </summary>
        /// <param name="filename">Var to determine the path of the file</param>
        /// <returns>It return the content of the file</returns>
        public string[] Read(string filename)
        {
            string[] Content;
            try
            {
                Content = File.ReadAllLines(filename);
            }
            catch(FileNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Content;

        }
    }
}
