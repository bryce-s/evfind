#include "ParseArgs.h"

using namespace boost::program_options;

std::vector<std::string> ParseArgs::parseArgs(const int argc, const char *argv[]) {
	namespace progOpts = boost::program_options;
	progOpts::options_description desc("Options");
	desc.add_options()
		("Help", "Print help messages.");
	progOpts::variables_map vm;
	try {
		progOpts::store(progOpts::parse_command_line(argc, argv, desc), vm);
	}
	catch (progOpts::error& e) {
		std::cerr << "a CLI parse error\n";
	}
}
