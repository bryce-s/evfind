using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;

namespace evfind
{
    
    class Args
    {
        public class Options
        { 
            [Option('0', "0", Required=false, HelpText="Print an ASCII NUL character after each result path. Useful when used in conjunction with xargs -0")]
            public bool nullFlag { get; set; }

            [Option('l', "live", Required=false, HelpText = "evfind will live-update search results. The search can be cancelled with ctrl-c.")]
            public bool liveResults { get; set; }

            [Option('c', "count", Required=false, HelpText = "Prints only the total number of resulting paths found.")]
            public bool count { get; set;  }

            [Option('o', "onlyin", Required = false, HelpText = "Search only in the directory path specified.")]
            public string onlyin { get; set; }


            [Option('i', "literal", Required = false, HelpText = "Query string will be treated as literal.")]
            public bool literal { get; set; }

            //[Option('i', "interpret", Required = false, HelpText = "")]

        }
        public Args()
        {
        }

        public List<char> runArguments(string[] args)
        {
            List<char> arguments = new List<char>();
            Parser.Default.ParseArguments<Options>(args).WithParsed(o =>
            {
                if (o.nullFlag)
                {
                    arguments.Add('0');
                }
                if (o.liveResults)
                {
                    arguments.Add('l');
                }
                if (o.count)
                {
                    arguments.Add('c');
                }
                // right way to check this?
                if (o.onlyin != "")
                {
                    arguments.Add('p');
                }

                if (o.literal)
                {
                    arguments.Add('i');
                }
            });
            return arguments;
        }


    }
}
