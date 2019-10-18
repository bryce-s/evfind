#pragma once

#include <vector>
#include <string>
#include <iostream>
#include <string>
#include <boost/program_options.hpp>
#include <exception>

class ParseArgs
{
	std::vector<std::string> searchTerms;
	std::vector<std::string> options;
public:
	void parseArgs(const int argc, const char *argv[]);

	std::vector<std::string> getSearchTerms();
	std::vector<std::string> getOptions();

};

