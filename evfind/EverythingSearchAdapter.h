#pragma once
#pragma comment(lib, "Everything64.lib")

#include <string>
#include <iostream>
#include "include/Everything.h"

class EverythingSearchAdapter
{
	bool everythingServiceIsRunning();

public:
	void searchTerm(const std::string& term);

};

