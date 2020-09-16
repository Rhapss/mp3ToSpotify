using System;
using System.IO;
using System.Text;
using TagLib;
//using File = TagLib.File;

namespace mp3ToSpotify
{
    internal class Program
    {
        private static void Main()
        {
            //Директория с музыкой
            var dir = new DirectoryInfo(@"F:\Music");

            //Экземляр потока файлов
            FileStream fs = null;

            //Экземпляр класса для ображениям к тегам
            TagLib.File tagFile = null;

            //Создаем поток данных в указаный файл
            fs = new FileStream(@"F:\music10.txt", FileMode.Create);

            var sw = new StreamWriter(fs, Encoding.UTF8);
            
            //За каждую итерацию мы перебираем каждый последующий файл, подставляя путь к каждому последующему файлу в
            //tagFile. После обращаясь уже к самому файлу берём тег исполнителя и названия песни и вписываем в файл построчно.
            foreach (var file in dir.GetFiles("*.mp3"))
                try
                {
                    tagFile = TagLib.File.Create(file.FullName);
                    sw.WriteLine("{0} - {1}", string.Join(", ", tagFile.Tag.Performers), tagFile.Tag.Title);
                }
                catch (CorruptFileException)
                {
                    Console.WriteLine("Error!");
                    throw;
                }
                finally
                {
                    sw.Close();
                    fs.Close();
                }
            Console.WriteLine("Finish!");
        }
    }
}