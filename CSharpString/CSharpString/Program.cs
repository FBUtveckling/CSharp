using System;
using System.IO;
using System.Text;

namespace CSharpString
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files\\String1.txt");
            string text = ReadLinesForFile(path);
            String dataSource = RemoveConsecutiveElementsFromString(text, 3);
            Console.WriteLine(dataSource);
        }
        
        public static String ReadLinesForFile(String filePath)
        {
            StringBuilder builder = new StringBuilder();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    builder.AppendLine(line);
                }
            }
            return builder.ToString();
        }
        public static String RemoveConsecutiveElementsFromString(String dataSource, int maxConsecutiveAllowedCount)
        {
            StringBuilder builder = new StringBuilder(dataSource);
            for (int i = 0; (i < builder.Length); i++)
            {
                int foundCount = 0;
                for (int j = (i - 1); (j >= 0); j--)
                {
                    if (builder[i] == builder[j])
                    {
                        foundCount++;
                        if ((foundCount >= maxConsecutiveAllowedCount))
                        {
                            builder.Remove(i, 1);
                            i--;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return builder.ToString();
        }
    }
}
