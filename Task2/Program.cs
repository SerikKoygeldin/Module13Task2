using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = new Dictionary<string, int>();
            string filePath = @"/Users/Serik/Desktop/C#/Module 13/Text2.txt";

            using (StreamReader sr = File.OpenText(filePath))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null) 
                {          
                    var noPunctuationText = new string(str.Where(c => !char.IsPunctuation(c)).ToArray());

                    String[] arrayOfWords = noPunctuationText.Split(' ');

                    foreach (var key in arrayOfWords) 
                    {
                        if (key != "")
                        {
                            if (items.ContainsKey(key))
                            {
                                items[key] += 1;
                            }
                            else
                            {
                                items.Add(key, 1);
                            }
                        }     
                    }
                }

                items = items.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
   
                int id = 0;

                foreach (KeyValuePair<string, int> p in items)
                {
                    Console.WriteLine($"{p.Key} = {p.Value}");

                    id++;
                    if (id == 10)
                    {
                        break;
                    }    
                }
                Console.ReadKey();
            }
        }
    }
}
