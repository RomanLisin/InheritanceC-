#include <iostream>
#include <string>
#pragma once
class String
{
	std::string strWord;
	std::string get_strWord()
	{
		return strWord;
	}
	void set_strWord(std::string str)
	{
		strWord = str;
	}
public:
	String(std::string str)
	{
		strWord = str;
	}
	 std::string& replace_char(char oldChar, char newChar)
	{
		 for (int i = 0; i < strWord.length(); ++i)
		 {
			 if (strWord[i] == oldChar)
			 {
				 (strWord[i] = newChar);
			 }
		 }
		return strWord;
	}
};

