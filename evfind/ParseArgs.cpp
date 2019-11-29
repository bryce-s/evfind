#include "ParseArgs.h"

using namespace boost::program_options;

void ParseArgs::parseArgs(const int argc, const char *argv[]) {
	namespace po = boost::program_options;
	po::options_description desc("Allowed options");
	desc.add_options()("help", "produce help message")
		("search", po::value<std::vector<std::string>>()->required(), "search terms")
		("escape-whitespace,s", po::value<bool>(), "Escape whitespace characters");
	    ("quote-whitespace,q", po::value<bool>(), "Wrap all paths containing whitespace in quotes");


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
		searchTerms = vm["search"].as<std::vector<std::string>>();
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

