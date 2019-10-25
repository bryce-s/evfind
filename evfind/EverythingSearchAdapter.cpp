#include "EverythingSearchAdapter.h"

bool EverythingSearchAdapter::isUnixPath()
{
	return this->pathSeperatorChar == '/';
}

bool EverythingSearchAdapter::everythingServiceIsRunning()
{
	
	return false;
}

std::string EverythingSearchAdapter::winPathToUnix(std::string winPath)
{
	std::regex whitespace("\w");
	std::string whitespaceStripped = std::regex_replace(winPath, whitespace, "\\s");
	std::regex pathReplacer("\\");
	std::string pathsReplaced = std::regex_replace(whitespaceStripped, whitespace, "/");
	
	return std::string();
}

void EverythingSearchAdapter::searchTerm(const std::string& term)
{
	// long pointer to constant wide string--prefix with L
	// to make string wide. Is 2 bytes per char.
	LPCWSTR query = L"Bryce";
	

	Everything_SetSearch(LPCWSTR(query));
	Everything_Query(true);

	boost::format joinPaths("%i\\%i");

	for (auto i = 0; i < Everything_GetNumResults(); i++) {
		LPCWSTR filename = Everything_GetResultFileName(i);
		LPCWSTR path = Everything_GetResultPath(i);
		std::wstring fnamewide = filename;
		// need to figure out how to cast wstring to string
		std::string fname = string_cast<std::string>(fnamewide);

		std::string joinedPaths = boost::str(joinPaths % filename % path);

		if (this->isUnixPath()) {
			std::string resultString = this->winPathToUnix(joinedPaths);
		}
		std::wcout << path << std::endl;
		
	}
	
}
