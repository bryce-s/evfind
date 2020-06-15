using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace evfind
{
    
    class Args
    {
        public class Options
        { 
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose.")]
            public bool Verbose { get; set; }
        }
        public Args(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(o =>
            {
                if (o.Verbose)
                {
                    Console.WriteLine("verbose enabled");
                }
            });

        }
    }
}
