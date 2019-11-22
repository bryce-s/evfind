#pragma once
#pragma comment(lib, "Everything64.lib")

#include <string>
#include <iostream>
#include "include/Everything.h"
#include <clocale>
#include <locale>
#include <codecvt>
#include <vector>
#include <boost/format.hpp>
#include <locale>
#include <regex>
#include <ctype.h>

class EverythingSearchAdapter
{

	std::string wstringToString(const std::wstring);


	bool escapeWhitespace;

	char pathSeperatorChar;

	bool isUnixPath();

	void queryEverything(const LPCWSTR);

	void parseLastEverythingError();

	// converts a windows path to a unix path
	std::string winPathToUnix(std::string);

public:

	EverythingSearchAdapter(const char sep, const bool esc) : pathSeperatorChar(sep), escapeWhitespace(esc)  {}

	void searchTerm(std::string& term);

};

