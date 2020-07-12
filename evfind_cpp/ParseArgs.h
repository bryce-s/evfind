#pragma once

#include <vector>
#include <string>
#include <iostream>
#include <string>
#include <boost/program_options.hpp>
#include <boost/format.hpp>
#include <exception>

#define WHITESPACE_ESCAPE "e"
#define QUOTE_WHITESPACE "q"
#define COUNT_RESULTS "c"
#define HELP_CHAR "h"

class ParseArgs
{
	std::vector<std::string> searchTerms;
	std::vector<std::string> options;
public:
	void parseArgs(const int argc, const char *argv[]);

	std::vector<std::string> getSearchTerms();
	std::vector<std::string> getOptions();

};

