using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Word_Unscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            string[] fileContent;

            try
            {
                fileContent = File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

            return fileContent;
        }
    }
}
