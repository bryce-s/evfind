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
        static Regex m_WslDriveMountPattern = new Regex(@"\\mnt\\[a-z]");

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




        private static string convertSlashes(string wslPath, char convertTo)
        {
           if (convertTo == '/')
            {
                wslPath = wslPath.Replace('\\', '/');
            } else if (convertTo == '\\')
            {
                wslPath = wslPath.Replace('/', '\\');
            }
            else
            {
                throw new Exception("conversion char must be '\\' or '/'");
            }
            return wslPath;
        }

        private static void addBasePathIfRelative(string wslPath, string resPath)
        {
            if (wslPath[0] != '/')
            {
                resPath = Directory.GetCurrentDirectory();
            }
            resPath = Path.Join(resPath, convertSlashes(wslPath, '\\'));
        }

        private static void checkMnt(string wslPath, string resPath)
        {
            if (wslPath.Contains("/mnt/"))
            {
                m_WslDriveMountPattern.Replace(wslPath, 
                    (match) => {
                        char driveLetter = char.ToUpper(match.Value[5]);
                        return $"{driveLetter}:\\";
                    }
                    );
                resPath = wslPath;
            }
        }

        private static string getWslRootDir()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // do we need the dir sep char here?
            // there's not a programatic way to do this?
            string wslRootDir = $"{appData}{Path.DirectorySeparatorChar}Local\\Packages\\CanonicalGroupLimited.UbuntuonWindows_79rhkp1fndgsc\\LocalState\\rootfs\\";
            return wslRootDir; 
        }

        /// <summary>
        /// Converts a unix/wsl path to a windows path
        /// </summary>
        /// <param name="wslPath"></param>
        /// <returns></returns>
        public static string wslToWin(string wslPath)
        {
            // dont wanna allocate this every time.
            string resPath = "";
            string realPath = "";
            if (wslPath != null && wslPath.Length > 0)
            {
                // conditions here are mutally exclusive, no need to join
                addBasePathIfRelative(wslPath, resPath);
                checkMnt(wslPath, resPath);
                var resPathSlash = convertSlashes(resPath, '\\');
                realPath = Path.GetFullPath(resPathSlash);
            }
            return realPath; 
        }



    }
}
