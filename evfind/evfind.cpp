#include "ParseArgs.h"
#include "EverythingSearchAdapter.h"
#include <vector>
#include <string>

int main(int argc, const char* argv[])
{
	std::ios_base::sync_with_stdio(false);

	ParseArgs args;
	args.parseArgs(argc, argv);
	std::vector<std::string> terms = args.getSearchTerms();

	EverythingSearchAdapter e('/', true);
	e.searchTerm("woof");


}
