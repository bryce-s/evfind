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

	EverythingSearchAdapter e('/', 
		(std::find(terms.begin(), terms.end(), WHITESPACE_ESCAPE) != terms.end()),
		(std::find(terms.begin(), terms.end(), QUOTE_WHITESPACE) != terms.end()),
		(std::find(terms.begin(), terms.end(), HELP_CHAR) != terms.end())

	
	);
	// really these should be a big string 
	for (std::string s : terms) {
		e.searchTerm(s);
	}


}
