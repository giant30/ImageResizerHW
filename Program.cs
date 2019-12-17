using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task>();

            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output");
            string destinationPathOrgin = Path.Combine(Environment.CurrentDirectory, "outputOrgin");
            long newResult = 0;
            long OriginResult = 0;
            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);            
            sw.Stop();
            newResult = sw.ElapsedMilliseconds;
            Console.WriteLine("New : "+$"花費時間: {sw.ElapsedMilliseconds} ms");
            //Console.ReadKey();



            imageProcess.Clean(destinationPathOrgin);
            sw.Restart();
            sw.Start();
            imageProcess.ResizeImagesOrigin(sourcePath, destinationPathOrgin, 2.0);
            sw.Stop();
            OriginResult = sw.ElapsedMilliseconds;
            Console.WriteLine("Origin : " +$"花費時間: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("效能增加 :" + (OriginResult * 1.00 - newResult * 1.00) / OriginResult * 100); 
            Console.ReadKey();




        }
    }
}
