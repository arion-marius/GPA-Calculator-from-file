using System;
using System.Collections.Generic;
using System.IO;

namespace GPA_Calculator
{
    public static class Program
    {
        public static void Main()
        {
            string folder = "C:\\Users\\arion\\Desktop\\GPA\\GPA-Calculator-from-file\\Grades";
            var files = Directory.EnumerateFiles(folder, "*.txt");

            var studentAveragesAsText = new List<string>();

            var studentAverageFileParser = new StudentAverageFileParser();

            foreach (string file in files)
            {
                string fileContent = File.ReadAllText(file);

                try
                {
                    double medieGeneralaFinala = studentAverageFileParser.GetGPA(fileContent);

                    string numeElev = Path.GetFileName(file);
                    studentAveragesAsText.Add($"Media elevului/elevei {numeElev} este {medieGeneralaFinala}");
                }
                catch
                {
                    Console.WriteLine($"The format of {file} is invalid");
                }
            }

            var fisierMedii = @"C:\\Users\\arion\\Desktop\\GPA\\GPA-Calculator-from-file\\medii.txt";
            File.WriteAllLines(fisierMedii, studentAveragesAsText);
        }
    }
}