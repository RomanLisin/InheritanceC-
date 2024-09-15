using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Graduate : Student
	{
		public string Subject { get; set; }
		public Graduate
			(
			string lastName, string firstName, uint age,
			string speciality, string group, double rating, double attendance,
			string subject
			) : base (lastName, firstName, age, speciality, group, rating, attendance)
		{
			Subject = subject;
            Console.WriteLine($"GConstuctor:\t{GetHashCode()}");
        }
		public Graduate(Student student, string subject):base(student)
		{
			Subject = subject; 
            Console.WriteLine($"GConstuctor:\t{GetHashCode()}");
		}
		~Graduate()
		{
            Console.WriteLine($"GDestuctor:\t{GetHashCode()}");
		}

		public void Print()
		{
			base.Print();
            Console.WriteLine($"{Subject}");
        }
		public override string ToString()
		{
			return base.ToString() + $"{Subject}";
		}
		public override string ToFileString()
		{
			return $"{base.ToFileString()},{Subject}";       //ToString().Split('.').Last()}: {Subject}";
		}
		public override void Init(string[] values)
		{
			base.Init(values);
			Subject = values[8];
		}
	}
}
