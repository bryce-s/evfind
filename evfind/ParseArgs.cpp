#include "ParseArgs.h"

using namespace boost::program_options;

void ParseArgs::parseArgs(const int argc, const char *argv[]) {
	namespace po = boost::program_options;
	po::options_description desc("Allowed options");

	std::string searchStr = "search";
	std::string help = "help";

	std::string escapeWhitespace = boost::str(boost::format("escape-whitespace,%1%") % WHITESPACE_ESCAPE);
	std::string quoteWhitespace = boost::str(boost::format("quote-whitespace,%1%") % QUOTE_WHITESPACE);

	bool escapeWhitespaceFlag = false;
	bool quoteWhitespaceFlag = false;

	desc.add_options()("help", "produce help message")
		(searchStr.c_str(), po::value<std::vector<std::string>>()->required(), "search terms")
		(escapeWhitespace.c_str(), po::bool_switch(&escapeWhitespaceFlag), "Escape whitespace characters");
	    (quoteWhitespace.c_str(), po::bool_switch(&quoteWhitespaceFlag), "Wrap all paths containing whitespace in quotes");


	po::positional_options_description pos;
	pos.add("search", -1);
	po::variables_map vm;

	try {
		po::store(po::command_line_parser(argc, argv).options(desc).positional(pos).run(), vm);
		po::notify(vm);
	}
	catch (const po::error& e) {
		std::cerr << "Error parsing arguments.\n";
		std::cerr << e.what() << '\n' << '\n';
		std::cerr << desc << '\n';
	}
	if (vm.size() > 0) {
		this->searchTerms = vm[searchStr].as<std::vector<std::string>>();
		if (escapeWhitespaceFlag) {
			this->searchTerms.push_back(WHITESPACE_ESCAPE);
		}
		if (quoteWhitespaceFlag) {
			this->searchTerms.push_back(QUOTE_WHITESPACE);
		}
	}

	if (vm.count("help")) {
		options.push_back("help");
	}
}

std::vector<std::string> ParseArgs::getSearchTerms()
{
	return searchTerms;
}

std::vector<std::string> ParseArgs::getOptions()
{
	return options;
}


