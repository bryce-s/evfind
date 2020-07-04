using System;
using System.Collections.Generic;
using System.Text;

namespace evfind
{
    /// <summary>
    /// gathers results from everything layer
    /// </summary>
    class EverythingSearchAdapter
    {

        List<char> m_SearchOptions;

        public EverythingSearchAdapter(ref List<Char> searchOptions_in) {
            m_SearchOptions = searchOptions_in; 
        }

        private void addClosingSpace(StringBuilder queryBuilder)
        {
            queryBuilder.Append(" ");
        }

        private void matchFileName(StringBuilder queryBuilder)
        {
            string stubfile = "stub";
            queryBuilder.Append($"file: ${stubfile}");
            addClosingSpace(queryBuilder);
        }

        private string buildSearchQuery()
        {
            StringBuilder queryBuilder = new StringBuilder();
            if (m_SearchOptions.Contains(NativeDefinitions.NAME))
            {

            }

            return "stub";
        }

        public string queryEverything()
        {
            string searchQuery = buildSearchQuery();
            NativeMethods.Everything_SetSearchW(searchQuery);
            return "hey";
        }

    }
}
