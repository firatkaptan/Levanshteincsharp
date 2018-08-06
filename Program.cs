using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string line;
            List<string> listnames = new List<string>();
            List<string> listsurnames = new List<string>();          
            BKTree bk = new BKTree();


            System.IO.StreamReader file1 = new System.IO.StreamReader(@"c:\names.txt");          
            while ((line = file1.ReadLine()) != null)
            {
                listnames.Add(line);                
            }
            file1.Close();

            System.IO.StreamReader file2 = new System.IO.StreamReader(@"c:\surnames.txt");
            while ((line = file2.ReadLine()) != null)
            {
                listsurnames.Add(line);
            }
            file2.Close();

            //foreach (string name in listnames){
            //    foreach (string surname in listsurnames)
            //    {
            //        listall.Add(name + surname);
            //    }
            //}

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    bk.Add(listnames[i] + listsurnames[j]);                    
                }
            }

            bk.Add("fetullahgülen");
            bk.Add("firatkaptan");

            Console.WriteLine("Ready!");

            while (true)
            {
                var l = Console.ReadLine();

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                var x = (l.Length * 15 / 100)+1;
                var a = bk.Search(l,x);
                stopWatch.Stop();     
           
                TimeSpan ts = stopWatch.Elapsed;

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);

                Console.WriteLine("RunTime " + elapsedTime);
                Console.WriteLine(String.Join(", ", a.ToArray()));
            }

            
        }
    }
}
