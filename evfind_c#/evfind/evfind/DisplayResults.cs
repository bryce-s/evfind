using System;
using System.Collections.Generic;
using System.Text;

namespace evfind
{
    class DisplayResults
    {
        List<char> m_ArgList;
        DisplayResults(Tuple<List<char>, Dictionary<char, string>> arguments_in)
        {
            m_ArgList = arguments_in.Item1;
        }


        public void printResult(string result)
        {
            if (m_ArgList.Contains(NativeDefinitions.NULLCHAR))
            {
                Console.Write($"{result}\0");
            } else
            {
                Console.WriteLine(result);
            }
        }

        public void displayResults()
        {
            var buffer = new StringBuilder();
            var numResults = NativeMethods.Everything_GetNumResults();
            for (uint i = 0; i < numResults; i++)
            {
                NativeMethods.Everything_GetResultFullPathName(i, buffer, (uint)buffer.Capacity);
                string windowsPath = buffer.ToString();
                string wslPath = WslPath.winToWsl(windowsPath);
                if (!m_ArgList.Contains(NativeDefinitions.COUNT)) {
                    printResult(wslPath);
                }
            }
        }
    }
}
