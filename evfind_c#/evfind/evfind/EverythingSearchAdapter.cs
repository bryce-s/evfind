using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace evfind
{
    /// <summary>
    /// gathers results from everything layer
    /// </summary>
    class EverythingSearchAdapter
    {

        List<char> m_SearchOptions;
        Dictionary<char, string> m_argValues;

        public EverythingSearchAdapter(Tuple<List<char>, Dictionary<char, string>> searchOptions_in) {
            m_SearchOptions = searchOptions_in.Item1;
            m_argValues = searchOptions_in.Item2;
        }

        private bool optionPresent(char c)
        {
            return m_SearchOptions.Contains(c);
        }

        private void addClosingSpace(StringBuilder queryBuilder)
        {
            queryBuilder.Append(" ");
        }

        private void matchSpecificPath(StringBuilder queryBuilder)
        {
            string path = m_argValues[NativeDefinitions.ONLYIN];
            // convert to windows path and validate it
            path = WslPath.wslToWin(path);
            queryBuilder.Append($"\"{path}\"");
            addClosingSpace(queryBuilder);
        }

        
        private void caseSensitive(StringBuilder queryBuilder)
        {
            queryBuilder.Append("case:");
            addClosingSpace(queryBuilder); 
        }

        private void matchFileName(StringBuilder queryBuilder)
        {
            string fileArgument = m_argValues[NativeDefinitions.NAME];
            queryBuilder.Append($"file: ${fileArgument}");
            addClosingSpace(queryBuilder);
        }

        private void insertSearchTerms(List<string> searchTerms, StringBuilder queryBuilder)
        {
            foreach (string term in searchTerms)
            {
                queryBuilder.Append(term);
            }
        }

        private string buildSearchQuery(List<string> searchTerms)
        {
            StringBuilder queryBuilder = new StringBuilder();
            if (optionPresent(NativeDefinitions.NAME))
            {
                matchFileName(queryBuilder);
            }
            if (optionPresent(NativeDefinitions.ONLYIN))
            {
                matchSpecificPath(queryBuilder);
            }
            if (optionPresent(NativeDefinitions.CASE_SENSITIVE))
            {
                caseSensitive(queryBuilder);
            }
            insertSearchTerms(searchTerms, queryBuilder);
            return queryBuilder.ToString();
        }

        public void queryEverything(List<string> searchTerms)
        {
            string searchQuery = buildSearchQuery(searchTerms);
            if (searchQuery == "" || searchQuery == null)
            {
                return;
            }
            NativeMethods.Everything_SetSearchW(searchQuery);
            NativeMethods.Everything_QueryW(true);
        }
    }
}
