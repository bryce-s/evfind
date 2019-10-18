#pragma once

#include <vector>
#include <string>
#include <boost/program_options.hpp>
#include <iostream>
#include <string>

class ParseArgs
{
public:
	static std::vector<std::string> parseArgs(const int argc, const char *argv[]);
};

