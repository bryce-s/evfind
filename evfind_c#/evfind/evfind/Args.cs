using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;

namespace evfind
{
    
    class Args
    {

        public List<string> optionsForRemoval()
        {
            // todo: nested namespaces for these might be nice.
            List<string> opts = new List<string>()
            {
                "-0", "--null-char",
                "-l", "--live",
                "-c", "--count",
                "-o", "--onlyin",
                "-i", "--literal",
                "-n", "--name",
                "-s", "--case-sensitive",
                "--help",
                "--version"
            };
            return opts;
        }

        public List<string> removeCommandLineOptions(string[] args)
        {
            List<string> optionsToRemove = optionsForRemoval();
            List<string> searchTerms = new List<string>();
            if (args.Contains("--help") || args.Contains("--version"))
            {
                Environment.Exit(1);
            }
            for (int i = 0; i < args.Length; i++)
            {
                if (!optionsToRemove.Contains(args[i]))
                {
                    searchTerms.Add(args[i]);
                }
            }
            return searchTerms;
        }


        public class Options
        { 
            [Option('0', "null-char", Required=false, HelpText="Print an ASCII NUL character after each result path. Useful with xargs -0.")]
            public bool nullFlag { get; set; }

            [Option('l', "live", Required=false, HelpText = "evfind will live-update search results. The search can be cancelled with ctrl-c.")]
            public bool liveResults { get; set; }

            [Option('c', "count", Required=false, HelpText = "Prints only the total number of resulting paths found.")]
            public bool count { get; set;  }

            [Option('o', "onlyin", Required = false, HelpText = "Search only in the directory path specified.")]
            public string onlyin { get; set; }

            [Option('i', "literal", Required = false, HelpText = "Query string will be treated as literal.")]
            public bool literal { get; set; }

            [Option('n', "name", Required = false, HelpText = "Filter by filename.")]
            public string fileName { get; set; }

            [Option('s', "case-sensitive", Required = false, HelpText = "Makes the query case-sensitive.")]
            public bool caseSensitive { get; set; }
        }
        public Args()
        {
        }

        public Tuple<List<char>, Dictionary<char, string>> runArguments(string[] args)
        {
            List<char> arguments = new List<char>();
            Dictionary<char, string> argValues = new Dictionary<char, string>();
            Parser.Default.ParseArguments<Options>(args).WithParsed(o =>
            {
                if (o.nullFlag)
                {
                    arguments.Add(SearchDefinitions.NULLCHAR);
                }
                if (o.liveResults)
                {
                    arguments.Add(SearchDefinitions.LIVE);
                }
                if (o.count)
                {
                    arguments.Add(SearchDefinitions.COUNT);
                }
                // right way to check this?
                if (o.onlyin != null)
                {
                    arguments.Add(SearchDefinitions.ONLYIN);
                    argValues.Add(SearchDefinitions.ONLYIN, o.onlyin);
                }
                if (o.literal)
                {
                    arguments.Add(SearchDefinitions.LITERAL);
                }
                if (o.fileName != null) 
                {
                    arguments.Add(SearchDefinitions.NAME);
                    argValues.Add(SearchDefinitions.NAME, o.fileName);
                }
                if (o.caseSensitive)
                {
                    arguments.Add(SearchDefinitions.CASE_SENSITIVE);
                }
            });
            return Tuple.Create(arguments, argValues);
        }
    }
}
