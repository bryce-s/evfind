#include "EverythingSearchAdapter.h"

bool EverythingSearchAdapter::everythingServiceIsRunning()
{
	return false;
}

void EverythingSearchAdapter::searchTerm(const std::string& term)
{
	Everything_SetSearch(LPCWSTR("Bryce"));
	Everything_Query(true);
	for (auto i = 0; i < Everything_GetNumResults(); i++) {
		std::cout << Everything_GetResultFileName(i) << std::endl;
	}
	
}
