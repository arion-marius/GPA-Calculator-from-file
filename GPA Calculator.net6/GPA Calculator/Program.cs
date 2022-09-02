using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace GPA_Calculator
{
    internal static class Program
    {
        private const char LineElementsSeparator = '|';
        private const char GradesSeparator = ',';

        static void Main(string[] args)
        {
            string folder = "C:\\Users\\arion\\Desktop\\GPA\\GPA-Calculator-from-file\\Grades";
            int b = 0;
            var files = Directory.EnumerateFiles(folder, "*.txt");
            string[] text = new string[files.Count()];

            foreach (string file in files)
            {
                double sumaMedii = 0;
                string numeElev = Path.GetFileName(file);
                string contents = File.ReadAllText(file);
                string[] lines = GetLinii(contents);

                foreach (var line in lines)
                {
                    string[] elements = GetElements(line);
                    int[] grades = GetGrades(elements[1]);
                    int? thesis = null;
                    if (elements.Length > 2)
                        thesis = GetThesis(elements[2]);
                    double medie = Calculator.GetMedie(grades, thesis);
                    sumaMedii += medie;
                }

                var medieGeneralaFinala = Math.Round(sumaMedii / lines.Length, 2);
                text[b++] = $"Media elevului/elevei {numeElev} este {medieGeneralaFinala}";
            }
            var fisierMedii = @"C:\\Users\\arion\\Desktop\\GPA\\GPA-Calculator-from-file\\medii.txt";
            File.AppendAllLines(fisierMedii, text);



            static string[] GetLinii(string content)
               => content.Split(Environment.NewLine);

            static string[] GetElements(string line)
                => line.Split(LineElementsSeparator);

            static int GetThesis(string v)
                => Convert.ToInt32(v);

            static int[] GetGrades(string v)
            {
                string[] splitGrades = v.Split(GradesSeparator);
                int[] ints = new int[splitGrades.Length];
                for (int i = 0; i < splitGrades.Length; i++)
                {
                    ints[i] = Convert.ToInt32(splitGrades[i]);
                }
                return ints;
            }
        }
    }

}
