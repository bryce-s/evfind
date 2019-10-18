#pragma once

#include <vector>
#include <string>
#include <iostream>
#include <string>
#include <boost/program_options.hpp>

class ParseArgs
{
public:
	static std::vector<std::string> parseArgs(const int argc, const char *argv[]);
};

