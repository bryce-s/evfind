#include "ParseArgs.h"
#include "EverythingSearchAdapter.h"
#include <vector>
#include <string>

int main(int argc, const char* argv[])
{
	ParseArgs args;
	args.parseArgs(argc, argv);
	std::vector<std::string> terms = args.getSearchTerms();

	EverythingSearchAdapter e('/');
	e.searchTerm("woof");


}
