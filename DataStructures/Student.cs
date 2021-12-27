using System;

namespace DataStructures
{
    public class Student : IComparable<Student>
    {
        private string name;
        private int tall;

        public Student(string name, int tall)
        {
            this.name = name;
            this.tall = tall;
        }

        public Student() : this(default, default)
        {
        }

        public override string ToString()
        {
            return $" {{{name}: {tall} }}";
        }

        public int CompareTo(Student other)
        {
            if (tall > other.tall)
            {
                return 1;
            }

            if (tall < other.tall)
            {
                return -1;
            }

            return 0;
        }
    }
}