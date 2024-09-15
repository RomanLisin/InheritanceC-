#include<iostream>
#include<fstream>
#include<string>
#include<sstream>
using std::cout;
using std::cin;
using std::endl;
int string_length(const char str[]);
std::string replaceChar(std::string str, char oldChar, char newChar);
std::string toUpperChar(std::string str);

void main()
{
	setlocale(LC_ALL, "");
	
	std::ifstream inFromFile("201 RAW.txt");// 1) создаём поток на чтение и открываем его
	std::ofstream outInFile("201 ready.txt", std::ios_base::app); // 2) создаём поток на запись и открываем его
	if (inFromFile.is_open())  // если файл открылся
	{
		while (!inFromFile.eof() && outInFile.is_open())  // пока не конец
		{
			std::string ip, mac, str_line;
			std::getline(inFromFile, str_line); // читаем построчно из файла в строку str_line
			std::istringstream istr(str_line);   // создаём поток слов из строки
			// https://en.cppreference.com/w/cpp/io/basic_istringstream
			istr >> ip >> mac; // пишем из потока в каждую строку отдельное слово
			outInFile << replaceChar(mac, '-', ':') << "\t" << ip << endl; // пишем в файл в нужном нам порядке слово переделанный МАС
		}
		inFromFile.close(); // закрываем поток из файла
	}
	else
	{
		std::cerr << "Error: file not found" << endl;
	}
	outInFile.close(); // закрываем поток в файл
	//system("notepad 201 ready.txt");

	inFromFile.open("201 RAW.txt");
	outInFile.open("201.dhcpd", std::ios_base::app);
	if (inFromFile.is_open() && outInFile.is_open())
	{
		int countLine = 1;
		while (!inFromFile.eof())
		{
			std::string ip, mac, str_line, name = "host-";
			std::getline(inFromFile, str_line);
			if (str_line.empty())
			{
				continue; // пропускаем итерацию
			}
			std::istringstream istr(str_line);
			istr >> ip >> mac;

			outInFile << name << countLine << "\n"	
				<< "{" << "\n\t"
				<< "hardware ethernet\t" << replaceChar(mac, '-', ':') << ";" << "\n\t"
				<< "fixed-address\t\t" << ip << ";" << "\n" 
				<< "}" << "\n\n";
			countLine++;

		}
		inFromFile.close();
		outInFile.close();
	}
}
std::string replaceChar(std::string str, char oldChar, char newChar)
{
	for (int i = 0; i < str.length(); ++i)
	{
		if (str[i] == oldChar)str[i] = newChar;
	}
	return str;
}
std::string toUpperChar(std::string str)
{
	for (int i = 0; i < str.length(); ++i) {
		if (str[i] >= 'a' && str[i] <= 'z') {
			str[i] = str[i] - ('a' - 'A');
		}
	}
	return str;
}
int string_length(const char str[])
{
	int i = 0; 
	for (; str[i]; i++);
	return i;
}
