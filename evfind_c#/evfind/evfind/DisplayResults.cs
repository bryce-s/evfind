using System;
using System.Collections.Generic;
using System.Text;

namespace evfind
{
    class DisplayResults
    {
        List<char> m_ArgList;
        public DisplayResults(Tuple<List<char>, Dictionary<char, string>> arguments_in)
        {
            m_ArgList = arguments_in.Item1;
        }
        private void printResult(string result)
        {
            if (!m_ArgList.Contains(SearchDefinitions.NULLCHAR))
            {
                Console.WriteLine(result);
            } else
            {
                Console.Write($"{result}\0");
            }
        }

        private void printCount(uint numResults)
        {
            if (!m_ArgList.Contains(SearchDefinitions.NULLCHAR))
            {
                Console.WriteLine(numResults);
            }
            else
            {
                Console.Write($"{numResults}\0");
            }
        }

        public void displayResults()
        {
            var buffer = new StringBuilder(SearchDefinitions.WINDOWS_PATH_LENTH_LIMIT);
            var numResults = NativeMethods.Everything_GetNumResults();

            if (numResults == 0)
            {
                return;
            }

            if (m_ArgList.Contains(SearchDefinitions.COUNT))
            {
                printCount(numResults);
                return;
            }

            for (uint i = 0; i < numResults; i++)
            {
                NativeMethods.Everything_GetResultFullPathName(i, buffer, (uint)buffer.Capacity);
                string windowsPath = buffer.ToString();
                buffer.Clear();
                string wslPath = ParseWslPath.winToWsl(windowsPath);
                printResult(wslPath);
            }
        }
    }
}
