using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Almanac
{
    class WriteFile
    {
        static public string[] writeFile(string nameFile)
        {
            int count = System.IO.File.ReadAllLines(nameFile).Length;
            string[] dataFile = new string[count];
            for(int i=0;i<count;i++)
            {
                dataFile[i] = File.ReadLines(nameFile).Skip(i).First();
            }
            return dataFile;
        }
    }
}
