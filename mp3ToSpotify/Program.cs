using System;
using System.IO;
using System.Text;
using TagLib;
using File = TagLib.File;

namespace mp3ToSpotify
{
    internal class Program
    {
        private static void Main()
        {
            var dir = new DirectoryInfo(@"F:\Music");

            FileStream fs = null;
            File tagFile = null;
            fs = new FileStream(@"F:\music3.txt", FileMode.CreateNew);
            var sw = new StreamWriter(fs, Encoding.UTF8);
            
            foreach (var file in dir.GetFiles("*.mp3"))
                //Console.WriteLine(file);
                try
                {
                    tagFile = File.Create(file.FullName);
                    sw.WriteLine("{0} - {1}", string.Join(", ", tagFile.Tag.Performers), tagFile.Tag.Title);
                }
                catch (CorruptFileException)
                {
                    Console.WriteLine("Error!");
                    throw;
                }
            Console.WriteLine("Finish!");
        }
    }
}