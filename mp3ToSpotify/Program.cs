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

            var dir = new DirectoryInfo(@"F:\Music");
            var allNames = new List< string >();

            foreach (FileInfo file in dir.GetFiles())
            {
                allNames.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }
            foreach (string file in allNames)
            {
                Console.WriteLine(file);
            }
        }
    }
}
