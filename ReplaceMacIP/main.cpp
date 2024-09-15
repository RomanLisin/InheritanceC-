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
	
	std::ifstream inFromFile("201 RAW.txt");// 1) ������ ����� �� ������ � ��������� ���
	std::ofstream outInFile("201 ready.txt", std::ios_base::app); // 2) ������ ����� �� ������ � ��������� ���
	if (inFromFile.is_open())  // ���� ���� ��������
	{
		while (!inFromFile.eof() && outInFile.is_open())  // ���� �� �����
		{
			std::string ip, mac, str_line;
			std::getline(inFromFile, str_line); // ������ ��������� �� ����� � ������ str_line
			std::istringstream istr(str_line);   // ������ ����� ���� �� ������
			// https://en.cppreference.com/w/cpp/io/basic_istringstream
			istr >> ip >> mac; // ����� �� ������ � ������ ������ ��������� �����
			outInFile << replaceChar(mac, '-', ':') << "\t" << ip << endl; // ����� � ���� � ������ ��� ������� ����� ������������ ���
		}
		inFromFile.close(); // ��������� ����� �� �����
	}
	else
	{
		std::cerr << "Error: file not found" << endl;
	}
	outInFile.close(); // ��������� ����� � ����
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
				continue; // ���������� ��������
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
