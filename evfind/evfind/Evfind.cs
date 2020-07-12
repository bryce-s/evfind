using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;

namespace evfind
{
    class Evfind
    {
		static void Main(string[] args)
        {
			Args argParser = new Args();
			Tuple<List<char>, Dictionary<char, string>> arguments = argParser.runArguments(args);
			
			List<string> searchTerms = argParser.removeCommandLineOptions(args);

			EverythingSearchAdapter searchAdapter = new EverythingSearchAdapter(arguments);
			searchAdapter.queryEverything(searchTerms);

			DisplayResults displayObject = new DisplayResults(arguments);
			displayObject.displayResults();

		} 
    }
}


