using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace timestamps_editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the lyrics with timestamps in this format: [00:00.00] in text.txt in the same folder of this exe");
            Console.Write("Insert how many second you want to add to any line, eg 4,20 or -1,69: ");
            double time=Convert.ToDouble(Console.ReadLine());
            StreamReader sr = new StreamReader("text.txt");
            StreamWriter sw=new StreamWriter("result.txt",false);
            while(sr.Peek()!=-1)
            {
                string s = sr.ReadLine();
                double n = double.Parse(s.Split(']')[0].Split(':')[1], System.Globalization.CultureInfo.InvariantCulture);
                n+=time;
                string number = n.ToString().Replace(',','.');
                string output = s.Split(']')[0].Split(':')[0] + ':' + number + ']' + s.Split(']')[1];
                sw.WriteLine(output);
                Console.WriteLine(output);
            }
            Console.WriteLine("Done! you can find everything in the result.txt file!");
            Console.ReadLine();
            sr.Close();
            sw.Close();
        }
    }
}
