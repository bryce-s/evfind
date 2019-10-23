#include "EverythingSearchAdapter.h"

bool EverythingSearchAdapter::everythingServiceIsRunning()
{
	return false;
}

void EverythingSearchAdapter::searchTerm(const std::string& term)
{
	// long pointer to constant wide string--prefix with L
	// to make string wide. Is 2 bytes per char.
	LPCWSTR query = L"Bryce";

	Everything_SetSearch(LPCWSTR(query));
	Everything_Query(true);
	for (auto i = 0; i < Everything_GetNumResults(); i++) {
		std::cout << Everything_GetResultFileName(i) << std::endl;
	}
	
}
