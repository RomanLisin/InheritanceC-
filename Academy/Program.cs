//#define INHERITANCE_1
//#define INHERITANCE_2
//#define SAVE_TO_FILE
//#define LOAD_FROM_FILE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy
{
	internal class Program
	{
		//static readonly string delimetr = "\n-----------------------------------------------\n";
		static void Main(string[] args)
		{
#if INHERITANCE_1
			Human human = new Human("Montana", "Antonio", 25);
			human.Print();
			Console.WriteLine(human);
			Console.WriteLine(delimetr);

			Student student = new Student("Pinkman", "Jessie", 25, "Chemistry", "WW_220", 95, 97);
			student.Print();
			Console.WriteLine(student);
			Console.WriteLine(delimetr);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			teacher.Print();
			Console.WriteLine(teacher);
			Console.WriteLine(delimetr);

			Graduate graduate = new Graduate("Vasya", "Ivanov", 28, "Chemistry", "WW_221", 98, 92, "Mathematic");
			graduate.Print();
			Console.WriteLine(graduate);
			Console.WriteLine(delimetr); 
#endif
#if INHERITANCE_2
			Human tommy = new Human("Vercetty", "Tommy", 30);
			Console.WriteLine(tommy);

			Human ken = new Human("Rozenberg", "Ken", 35);
			Console.WriteLine(ken);

			Human diaz = new Human("Diaz", "Ricardo", 50);
			Console.WriteLine(diaz);


			Student s_tommy = new Student(tommy, "Theft", "Vice", 98, 99);
			Console.WriteLine(s_tommy);

			Student s_ken = new Student(ken, "Lawer", "Vice", 42, 35);

			Graduate g_tommy = new Graduate(s_tommy, "How to make money");
			Console.WriteLine(g_tommy);

			Teacher t_diaz = new Teacher(diaz, "Weapons distribution", 20);
			Console.WriteLine(t_diaz);

#endif

#if SAVE_TO_FILE
			//Generalization:
			Human[] group = new Human[]
			{
				new Student("Pinkman", "Jessie", 25, "Chemistry", "WW_220", 95, 97),
				new Teacher("White", "Walter", 50, "Chemistry", 25),
				new Graduate("Schreder", "Hank", 40, "Criminalistic", "OBN", 50, 80, "How to catch Heisenberg"),
				new Student("Vercetty", "Tommy", 30, "Theft", "Vice", 95, 98),
				new Teacher("Diaz", "Ricardo", 50, "Weapons distribution", 20)
			};


			//string path = @"C:\Users\rls\source\repos\InheritanceC#\Academy\noteHuman.txt";

			//Generalization<Human> generalization = new Generalization<Human>();

			//generalization.WriteTxtFile(path, group);
			//generalization.ReadTxtFile(path);

			string filename = "group.csv";
			Save(group, filename); 
#endif
			Human[] group = Load("group.csv");
			//System.Diagnostics.Process;
			Print(group);

		}
		static void Print(Human[] group)
		{
			
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i]);
			}


		}
		static void Save(Human[] group, string filename)
		{
			StreamWriter sw = new StreamWriter(filename);
			for(int i=0;i< group.Length;i++) 
			{
				sw.WriteLine(group[i].ToFileString());

			}
			sw.Close();
			// CSV - Comma Separated Values.
			System.Diagnostics.Process.Start("txt",filename);


		}
		//CSV - Comma Separated Values.
		static Human[] Load(string filename)
		{
			List<Human> group = new List<Human>();
			// group = new List<Human>();

			//Console.WriteLine(sr);
			try
			{
				StreamReader sr = new StreamReader(filename);
				while (!sr.EndOfStream)
				{
					string bufer = sr.ReadLine();
					//Console.WriteLine(bufer);
					string[] values = bufer.Split(',', ';');
					group.Add(HumanFactory(values[0]));
					group.Last().Init(values);
				}
			sr.Close();
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}

			return group.ToArray();
		}

		static Human HumanFactory(string type)
		{
			Human human = null;
			switch (type)
			{
				case "Teacher": human = new Teacher("", "", 0, "", 0);break;
				case "Student": human = new Student("", "", 0, "", "", 0, 0);break;
				case "Graduate": human = new Graduate("", "", 0, "", "", 0, 0,""); break;
				default: human = new Human("", "", 0); break;
			}
			return human;
		}

	}
}
