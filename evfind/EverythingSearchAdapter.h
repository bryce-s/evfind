#pragma once
#pragma comment(lib, "Everything64.lib")

#include <string>
#include <iostream>
#include "include/Everything.h"
#include <boost/format.hpp>
#include <boost/s>
#include <regex>

class EverythingSearchAdapter
{

	char pathSeperatorChar;

	bool isUnixPath();

	bool everythingServiceIsRunning();
	


	// converts a windows path to a unix path
	std::string winPathToUnix(std::string);

public:

	EverythingSearchAdapter(const char sep) : pathSeperatorChar(sep) {}

	void searchTerm(const std::string& term);

};

