using System;

namespace GPA_Calculator
{
    public static class Calculator
    {
        public static double GetMedie(int[] grades, int? thesis)
        {
            var sum = 0d;
            for (int i = 0; i < grades.Length; i++)
                sum += grades[i];

            var medie = sum / grades.Length;

            medie = thesis == null
                ? medie
                : (medie * 3 + thesis.Value) / 4;

            return Math.Round(medie, 2);

            //return thesis == null
            //    ? Math.Round(sum / grades.Length, 2)
            //    : Math.Round((sum / grades.Length * 3 + thesis.Value) / 4, 2);
        }
    }
}