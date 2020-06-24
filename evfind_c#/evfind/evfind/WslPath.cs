using System;
using System.Collections.Generic;
using System.Text;

namespace evfind
{
    class WslPath
    {

        private static void checkForMultipleDrives(string windowsPath)
        {
            //windowsPath.Replace
        }

        private static void checkPathForErrors(string windowsPath)
        {
            // will a windows path from this api always start with a drive letter?
            // assuming yes for now.
            char driveLetter = windowsPath[0];
            if (windowsPath[1] != ':' || windowsPath[2] != '\\' || !Char.IsUpper(driveLetter))
            {
                throw new Exception("start of path from everything does not match [A-Z]:\\");
            }
            checkForMultipleDrives(windowsPath);
           
        }


        public static string convertWindowsPathToWsl(string windowsPath)
        {
            checkPathForErrors(windowsPath);

            char driveLetter = windowsPath[0];
            string wslPath = $"/mnt/{Char.ToLower(driveLetter)}/{windowsPath.Substring(3).Replace('\\', '/')}";

            return wslPath;
        }

    }
}
