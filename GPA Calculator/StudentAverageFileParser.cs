using System;
using System.Collections.Generic;
using System.Linq;

namespace GPA_Calculator
{
    public class StudentAverageFileParser
    {
        private const char LineElementsSeparator = '|';
        private const char GradesSeparator = ',';

        public double GetGPA(string fileContent)
        {
            var subjects = GetSubjects(fileContent);

            var subjectAverageList = new List<double>();
            foreach (var subject in subjects)
            {
                var average = new Calculator(subject.Grades.ToList(), subject.Thesis).GetAverage();
                subjectAverageList.Add(average);
            }

            var medieGeneralaFinala = Math.Round(subjectAverageList.Average(), 2);
            return medieGeneralaFinala;
        }

        private IEnumerable<Subject> GetSubjects(string fileContent)
        {
            var lines = fileContent.Split(Environment.NewLine);
            var subjects = new List<Subject>();

            try
            {
                foreach (var line in lines)
                {
                    string[] elements = line.Split(LineElementsSeparator);
                    int[] grades = GetGrades(elements[1]);

                    int? thesis = elements.Length > 2
                        ? int.Parse(elements[2])
                        : null;

                    subjects.Add(new Subject
                    {
                        Name = elements[0],
                        Grades = grades,
                        Thesis = thesis,
                    });
                }

                return subjects;
            }
            catch
            {
                return Enumerable.Empty<Subject>();
            }
        }

        private static int[] GetGrades(string gradesAsText)
        {
            string[] gradesArray = gradesAsText.Split(GradesSeparator);
            int[] grades = new int[gradesArray.Length];
            for (int i = 0; i < gradesArray.Length; i++)
            {
                grades[i] = int.Parse(gradesArray[i]);
            }
            return grades;
        }
    }
}