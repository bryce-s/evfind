using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace evfind
{
    class KeywordDefinitions
    {

        static HashSet<string> definitions;
        public HashSet<string> getSet()
        {
            if (definitions != null)
            {
                return definitions;
            }
            List<string> listDefs = new List<string>();
            
            // apps
            listDefs.Add("application");
            listDefs.Add("kind:app");

            // audio
            listDefs.Add("audio");
            listDefs.Add("music");

            // folder
            listDefs.Add("folder");
            listDefs.Add("folders");

            //fonts
            listDefs.Add("font");
            listDefs.Add("fonts");

            listDefs.Add("today");
            listDefs.Add("yesterday");
            listDefs.Add("this_week");

            definitions.UnionWith(listDefs);

            return definitions;

        }



    }
}
