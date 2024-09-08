using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	// Generic type
	// https://metanit.com/sharp/tutorial/3.12.php
	internal class Generalization<T>
	{
		// StreamWriter - запись текса в файл, StreamReader - чтение текста из файла
		//https://metanit.com/sharp/tutorial/5.5.php
		public void WriteTxtFile(string path, T[] data)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(path, true))
				{
					foreach (T item in data)
					{
						writer.WriteLine(item.ToString());
					}
					// здесь файл автоматически закрывается
				}
			}
			catch (IOException exc)
			{
                Console.WriteLine("Wreter error:\n"+exc.Message);
            }
		}

		 public void ReadTxtFile(string path)
		{
			try
			{
				using (StreamReader reader = new StreamReader(path))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						Console.WriteLine(line);
					}

				}
			}
			catch (IOException exc)
			{
                Console.WriteLine("Reader error:\n"+exc.Message);
            }
		}
	}
}
