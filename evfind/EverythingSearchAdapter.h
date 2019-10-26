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

class EverythingSearchAdapter
{

	std::string wstringToString(const std::wstring);

	char pathSeperatorChar;

	bool isUnixPath();

	void queryEverything(const LPCWSTR);

	void parseLastEverythingError();

	// converts a windows path to a unix path
	std::string winPathToUnix(std::string);

public:

	EverythingSearchAdapter(const char sep) : pathSeperatorChar(sep) {}

	void searchTerm(const std::string& term);

};

