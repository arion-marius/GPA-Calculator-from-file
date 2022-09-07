using System.Collections.Generic;

namespace GPA_Calculator
{
    public class Subject
    {
        public string Name { get; set; }
        public IEnumerable<int> Grades { get; set; }
        public int? Thesis { get; set; }
    }
}