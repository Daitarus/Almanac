using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almanac
{
    class Algs
    {
        static public DateTime date = new DateTime();   
        static private string[] codeToday;
        static private DateTime lastDateChF = new DateTime(), NewDateChF;
        static private string URLCodeTasks;
        static public int Err=0;
        static private int[] time = new int[3];
        static private int k = 0;
        public static void AlgsTime()
        {
            //data setting
            date = DateTime.Now;
            //updata URLCodeTasks
            URLCodeTasks = "Data//Profile//CodeTasks" + date.Day + "_" + date.Month + "_" + date.Year;
            //IfChangeFile
            if (File.Exists(URLCodeTasks))
            {
                NewDateChF = File.GetLastWriteTime(URLCodeTasks);
                if (NewDateChF != lastDateChF)
                {
                    lastDateChF = NewDateChF;
                    codeToday = WriteFile.writeFile(URLCodeTasks);
                }
            }
            //cicle Code Work
            if (codeToday != null)
            {
                for (int i = 0; i < codeToday.Length; i++)
                {
                    WorkAlg(codeToday[i]);
                }
            }
        }
        //Code Work
        static private void WorkAlg(string CodeS)
        {

            int j = 0; string BufCode = ""; string[] CodeW = new string[CodeS.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length];
            //fragmentation CodeS
            for (int i = 0; i < CodeS.Length; i++)
            {
                if (CodeS[i] != ' ')
                {
                    BufCode += CodeS[i];
                }
                if ((CodeS[i] == ' ') || (i == (CodeS.Length - 1)))
                {
                    CodeW[j] = BufCode;
                    BufCode = "";
                    j++;
                }
            }
            
            BufCode = "";
            //converter
            for (int i = 0; i < CodeS.Length; i++)
            {
                Script.Converter(CodeW[i]);
            }
            //work

        }
             
    }
}
