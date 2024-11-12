using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace _aaa {



    [Serializable]
    public struct Baggage
    {
        public string Name;
        public decimal Weight;
    }

    [Serializable]
    public struct Passenger
    {
        public string Name;
        public List<Baggage> BaggageItems;
    }

    public class filetask 
    {
        public static void gen(int tasknumber, uint len)
        {
            int a;
            Random rand = new Random();
            switch (tasknumber) {
                case 4:
                    


                    using (BinaryWriter writer = new BinaryWriter(File.Open("rnd.bin", FileMode.Create)))
                    {
                        for (int i = 0; i < len; i++)
                        {
                            a = rand.Next(-100, 100);
                            //Console.WriteLine(a);
                            writer.Write(a);

                        }
                    }
                    break;
                case 5:
                    var passengers = new List<Passenger>();

                    XmlSerializer serializer = new XmlSerializer(typeof(List<Passenger>), new XmlRootAttribute("passengers"));

                    using (FileStream fs = File.Create("rnd.xml"))
                    {
                        serializer.Serialize(fs, passengers);
                    }


                    var random = new Random();
                    for (int i = 0; i < len; i++)
                    {
                        Passenger passenger = new Passenger
                        {
                            Name = $"Passenger_{i}",
                            BaggageItems = Enumerable.Range(0, random.Next(5) + 1)
                                .Select(j => new Baggage
                                {
                                    Name = $"Item_{j}_{i}",
                                    Weight = (decimal)(random.Next(50) + 10)
                                })
                                .ToList()
                        };
                        passengers.Add(passenger);
                    }


                    using (FileStream fs = File.Create("rnd.xml"))
                    {
                        serializer.Serialize(fs, passengers);
                    }
                    break;
                case 6:
                    using (StreamWriter writer = new StreamWriter("rnd.txt", false))
                    {
                        for (int i = 0; i < len; i++)
                        {
                            writer.WriteLine(rand.Next(-100, 101));
                        }
                        
                    }
                    break;
                case 7:
                    using (StreamWriter writer = new StreamWriter("rnd.txt", false))
                    {
                        for (int i = 0; i < len; i++)
                        {
                            writer.Write($"{rand.Next(-100, 101)} ");
                        }

                    }
                    break;
                case 8:
                    string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;:,.<>?";
                    using (StreamWriter writer = new StreamWriter("rnd.txt", false))
                    {
                        for (int i = 0; i < len; i+=0)
                        {
                            writer.Write($"{chars[rand.Next(chars.Length)]}");
                            if (rand.Next(20) == 3)
                            {
                                i++;
                                writer.Write("\n");
                            }
                        }

                    }
                    break;
            }
                
        }

        public static void rewrite(uint m)
        {
            StreamWriter writer = new StreamWriter("rnd1.txt", false);
            StreamReader reader = new StreamReader("rnd.txt");
            string? i;
            while ((i = reader.ReadLine()) != null)
            {
                if (i.Length == m) 
                {
                    writer.WriteLine(i);
                    Console.WriteLine($"Записано {i}");
                }
                
            }
            writer.Close();
            reader.Close();
        }
        public static int sqare()
        {
            int res = 0;
            using (StreamReader reader = new StreamReader("rnd.txt"))
            {
                
                string? i;
                while ((i = reader.ReadLine())!=null) {
                    res += Convert.ToInt32(i) * Convert.ToInt32(i);
                }
            }
            return res;
        }

        public static long multiplicate()
        {
            long res = 1;
            using (StreamReader reader = new StreamReader("rnd.txt"))
            {

                string? i;
                while ((i = reader.ReadLine()) != null)
                {
                    string pres = "";
                    foreach(char i1 in i)
                    {
                        if (i1 == ' ')
                        {
                            res *= Convert.ToInt32(pres);
                            pres = "";
                            continue;
                        }
                        pres += i1;
                    }
                }
            }
            return res;
        }
        public static List<Passenger> read(string filePath = "rnd.xml")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Passenger>), new XmlRootAttribute("passengers"));
            using (FileStream fs = File.OpenRead(filePath))
            {
                return serializer.Deserialize(fs) as List<Passenger>;
            }
        }

        public static int twoormore(List<Passenger> passengers)
        {
            int a = 0;
            foreach (var i in passengers)
            {
                int sum = 0;
                foreach (var j in i.BaggageItems)
                {
                    sum++;
                }
                if (sum > 2) a++;
            }
            return a;
        }
        public static int weight(List<Passenger> passengers)
        {
            int sum = 0;
            int res = 0;
            foreach (var i in passengers)
            {

                foreach (var j in i.BaggageItems)
                {
                    sum++;
                }

            }
            decimal avg = (decimal)sum / passengers.Count();
            foreach (var i in passengers)
            {
                if (avg < i.BaggageItems.Count()) res++;
            }
            return res;
        }

        public static long con(uint len)
        {
            long product = 1;
            int a;
            using (BinaryReader reader = new BinaryReader(File.Open("rnd.bin", FileMode.Open)))
            {

                
                for (int i = 0; i < len; i++)
                {
                    a = reader.ReadInt32();
                    if (a % 2 != 0 && a < 0) {
                        product *= a;
                    }

                }
            }
            return product;
        }

        

    }

}

