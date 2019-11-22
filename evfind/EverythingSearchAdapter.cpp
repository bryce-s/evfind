#include "EverythingSearchAdapter.h"

std::string EverythingSearchAdapter::wstringToString(const std::wstring wstr)
{
	using convert_type = std::codecvt_utf8<wchar_t>;
	std::wstring_convert<convert_type, wchar_t> converter;
	return std::string(converter.to_bytes(wstr));
}

bool EverythingSearchAdapter::isUnixPath()
{
	return this->pathSeperatorChar == '/';
}

void EverythingSearchAdapter::queryEverything(const LPCWSTR query)
{
	Everything_SetSearch(query);
	const int noError = Everything_Query(true);
	if (!noError) {
		std::cerr << "Error making a query:\n";
		this->parseLastEverythingError();
	}
}

void EverythingSearchAdapter::parseLastEverythingError()
{
	switch (Everything_GetLastError()) {
	    case EVERYTHING_ERROR_CREATETHREAD: 
			std::cerr << "Failed to create the search query thread.\n";
			break;
		case EVERYTHING_ERROR_REGISTERCLASSEX:
			std::cerr << "Failed to register the search query window class\n";
			break;
		case EVERYTHING_ERROR_CREATEWINDOW:
			std::cerr << "Failed to create the search query window\n";
			break;
		case EVERYTHING_ERROR_IPC:
			std::cerr << "Failed to establish IPC. Ensure Everything is running\n";
			break;
		case EVERYTHING_ERROR_MEMORY:
			std::cerr << "Failed to allocate memory for query\n";
			break;
		case EVERYTHING_ERROR_INVALIDCALL:
			std::cerr << "Call Everything_SetReplyWIndow before Everything_Query\n";
			break; 
		default:
			break;
	}
}

std::string EverythingSearchAdapter::winPathToUnix(std::string winPath)
{
	std::string stripped = "";
	try {
		
		stripped = winPath;
		std::replace(stripped.begin(), stripped.end(), '\\', '/');
		static std::regex whitespace("\\s+");
		if (this->escapeWhitespace) {
			stripped = std::regex_replace(stripped, whitespace, "\\ ");
		}
		static std::regex driveMount("[A-Z]:/");
		static std::smatch match;

		while (std::regex_search(stripped, match, driveMount)) {
			if (match.size() != 1) {
				throw std::length_error("Matched more than one drive letter in string.\n");
			}
			std::string driveLetterStr = match[0]; 
			char driveLetter = tolower(driveLetterStr[0]);
			static boost::format mountPath("/mnt/%i/");
			std::string unixDriveLetterStr = boost::str(mountPath % driveLetter);
			stripped = std::regex_replace(stripped, driveMount, unixDriveLetterStr);
		}
	}
	catch (std::regex_error re) {
		std::cout << re.what();
	}
	return stripped;
}

void EverythingSearchAdapter::searchTerm(const std::string& term)
{
	// long pointer to constant wide string--prefix with L
	// to make string wide. Is 2 bytes per char.
	LPCWSTR query = L"bryce";
	
	this->queryEverything(query);

	boost::format joinPaths("%i\\%i");

	for (auto i = 0; i < Everything_GetNumResults(); i++) {
		LPCWSTR wideFilename = Everything_GetResultFileName(i);
		LPCWSTR widePath = Everything_GetResultPath(i);
		std::wstring fnamewide = wideFilename;
		std::wstring pathNameWide = widePath;

		std::string filename = this->wstringToString(fnamewide);
		std::string pathname = this->wstringToString(pathNameWide);


		std::string joinedPaths = boost::str(joinPaths % pathname % filename);

		std::string resStr = joinedPaths;
		if (this->isUnixPath()) {
			resStr = this->winPathToUnix(joinedPaths);
		}
		std::cout << resStr << std::endl;
		
	}
	
}
