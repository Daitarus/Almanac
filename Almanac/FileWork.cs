using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Almanac
{
    public static class FileWork
    {
        public static string FileReadLine(string path, int num)
        {
            string s = File.ReadLines(path).Skip(num).First();
            return s;
        }
        public static string FileReadLine(string path)
        {
            string s = File.ReadLines(path).Skip(0).First();
            return s;
        }
        public static int FileLineLength(string path)
        {
            int n = File.ReadAllLines(path).Length;
            return n;
        }
    }
}
