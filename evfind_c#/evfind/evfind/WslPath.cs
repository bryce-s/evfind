using CommandLine.Text;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace evfind
{
    class WslPath
    {

        static Regex m_DriveMountPattern = new Regex(@"[A-Z]:\\");

        /// <summary>
        /// Checks path for multiple drives. driveMountPattern should be declared outside of any
        /// iteration.
        /// todo: need to profile this, findall() will be expensive.
        /// </summary>
        /// <param name="windowsPath"></param>
        /// <param name="driveMountPattern"></param>
        private static void checkForMultipleDrives(string windowsPath, ref Regex driveMountPattern)
        {
            MatchCollection matches = driveMountPattern.Matches(windowsPath);
            if (matches.Count != 1)
            {
                throw new Exception("incorrect number of drive patterns everything api path.");
            }
        }

        private static void checkPathForErrors(string windowsPath)
        {
            // will a windows path from everything api always start with a drive letter?
            // assuming yes for now.
            char driveLetter = windowsPath[0];
            if (windowsPath[1] != ':' || windowsPath[2] != '\\' || !Char.IsUpper(driveLetter))
            {
                throw new Exception("Start of path from everything api does not match [A-Z]:\\");
            }
            checkForMultipleDrives(windowsPath, ref m_DriveMountPattern);

        }

        /// <summary>
        /// Converts a windows path to a unix path, prefixed with '/mnt/{driveLetter}'.
        /// </summary>
        /// <param name="windowsPath"></param>
        /// <returns></returns>
        public static string convertWindowsPathToWsl(string windowsPath)
        {
            try
            {
                checkPathForErrors(windowsPath);
            } catch (Exception e)
            {
                // log to stderror for now
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine($"critical: {e.Message}");
                Environment.Exit(1);
            }

            char driveLetter = windowsPath[0];
            string wslPath = $"/mnt/{Char.ToLower(driveLetter)}/{windowsPath.Substring(3).Replace('\\', '/')}";
            return wslPath;
        }

    }
}
