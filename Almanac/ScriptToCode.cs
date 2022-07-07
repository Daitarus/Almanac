using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almanac
{
    class Script
    {
        static public int ToCode = 0;
        //construction
        public Script()
        {
        }
        //converter
        static public void Converter(string CodeWord)
        {
            switch (CodeWord)
            {
                case "time":
                    {
                        ToCode = 1;
                        break;
                    }
                case "->":
                    {
                        if(ToCode==1)
                        {
                            ToCode = 2;
                        }
                        else
                        {
                            ToCode = 0;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

    }
}
