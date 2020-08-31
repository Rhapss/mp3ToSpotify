using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace mp3ToSpotify
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '_', '0','1','2','3','4','5','6','7','8','9', '-', '\t' };
            var dir = new DirectoryInfo(@"F:\Music");
            var allNames = new List<string>();
            int i = 0;
            foreach (FileInfo file in dir.GetFiles())
            {
                allNames.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }
            foreach (string file in allNames)
            {
                allNames[i].Replace('_', ' ');
                i++;
                Console.WriteLine(file);
            }
        }
    }
}
