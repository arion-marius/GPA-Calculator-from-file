using System;
using System.Collections.Generic;
using System.Linq;

namespace GPA_Calculator
{
    public class Calculator
    {
        public Calculator(List<int>? grades, int? thesis)
        {
            if (grades is null
                || grades.Count == 0
                || grades.Any(grade => grade < 1 || grade > 10))
            {
                throw new ArgumentOutOfRangeException(nameof(grades));
            }

            if (Thesis.HasValue && (Thesis.Value < 1 || Thesis.Value > 10))
            {
                throw new ArgumentOutOfRangeException(nameof(thesis));
            }

            Grades = grades.ToList();
            Thesis = thesis;
        }

        public List<int>? Grades { get; set; }

        public int? Thesis { get; set; }

        public double GetAverage()
        {
            var sum = 0d;
            for (int i = 0; i < Grades!.Count; i++)
                sum += Grades[i];

            var medie = sum / Grades.Count;

            medie = Thesis == null
                ? medie
                : (medie * 3 + Thesis.Value) / 4;

            return Math.Round(medie, 2, MidpointRounding.AwayFromZero);

            //return thesis == null
            //    ? Math.Round(sum / grades.Length, 2)
            //    : Math.Round((sum / grades.Length * 3 + thesis.Value) / 4, 2);
        }
    }
}