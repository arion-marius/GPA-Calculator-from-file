using System;
using System.IO;

namespace GPA_Calculator
{
    internal static class Program
    {
        private const char LineElementsSeparator = '|';
        private const char GradesSeparator = ',';

        static void Main(string[] args)
        {
            var content = File.ReadAllText(@"C:\Users\arion\Desktop\GPA\GPA-Calculator-from-file\grades.txt");
            string[] lines = GetLinii(content);

            foreach (var line in lines)
            {
                string[] elements = GetElements(line);
                var subjectName = elements[0];
                int[] grades = GetGrades(elements[1]);
                int? thesis = null;
                if (elements.Length > 2)
                    thesis = GetThesis(elements[2]);

                double medie = Calculator.GetMedie(grades, thesis);
                Console.WriteLine($"Media ta la {subjectName} este:{medie}");
            }
        }

        private static string[] GetLinii(string content)
            => content.Split(Environment.NewLine);

        private static string[] GetElements(string line)
            => line.Split(LineElementsSeparator);

        private static int GetThesis(string v)
            => Convert.ToInt32(v);

        private static int[] GetGrades(string v)
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