using System;
using System.IO;
using System.Text;

namespace Task5
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            var Mainpath = path.Replace("\\bin\\Debug\\net5.0", "");
            string currentFile = Path.Combine(Mainpath, "Hello.txt");
            if (File.Exists(currentFile) == true)
            {
                var rand = new Random();
                string rm = rand.Next(10000).ToString();
                string oldOne = Path.Combine(Mainpath, "Hello.txt");
                string newFile = Path.Combine(Mainpath, rm + "Hello.txt");
                System.IO.File.Move(oldOne, newFile);
            }


            try
            {
                using (FileStream fs = File.Create(currentFile))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("Hello world from C#");
                    fs.Write(info, 0, info.Length);
                }
                using (StreamReader srs = File.OpenText(currentFile))
                {
                    string line = "";
                    while ((line = srs.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            catch (Exception expre)
            {
                Console.WriteLine(expre.ToString());
            }

        }
    }
}
