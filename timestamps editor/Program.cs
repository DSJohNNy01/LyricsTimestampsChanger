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
                int n2 = Convert.ToInt32(s.Split(']')[0].Split(':')[0].Remove(0,1));
                n+=time;
                if (n > 59.99)
                {
                    n2++;
                    n -= 60;
                }
                string number = String.Format("{0:F2}", n).Replace(',','.');
                if(number.Length<5)
                {
                    string nInit= number.Split('.')[0].PadLeft(2,'0');
                    string nFin = number.Split('.')[1].PadLeft(2, '0');
                    number = nInit + '.' + nFin;
                }
                string output = "["+ n2.ToString().PadLeft(2,'0') + ":" + number + "]" + s.Split(']')[1];
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
