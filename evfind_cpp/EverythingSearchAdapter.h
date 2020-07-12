#pragma once
#pragma comment(lib, "Everything64.lib")
// note: this is not beinng copied to output dir right now, and there's
//       no error at runtime. 


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

	bool quoteWhitespace;

	bool escapeWhitespace;

	char pathSeperatorChar;

	bool isUnixPath();

	bool countOnly;

	void queryEverything(const LPCWSTR);

	void parseLastEverythingError();

	// converts a windows path to a unix path
	std::string winPathToUnix(std::string);

public:

	EverythingSearchAdapter(const char pathSeperatorChar_In, const bool escapeWhitespace_in, const bool quoteWhitespaceIn, const bool countOnly_in) 
		: pathSeperatorChar(pathSeperatorChar_In), escapeWhitespace(escapeWhitespace_in), quoteWhitespace(quoteWhitespaceIn), countOnly(countOnly_in)  {}

	void searchTerm(std::string& term);

};

