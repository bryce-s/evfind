using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;



namespace evfind
{
    class Evfind
    {
		static void Main(string[] args)
        {
			Args argParser = new Args();
			List<char> arguments = argParser.runArguments(args);

			NativeMethods.Everything_SetSearchW("Bryce is");
			NativeMethods.Everything_QueryW(true);
			NativeMethods.Everything_SortResultsByPath();
			var buffer = new StringBuilder(NativeMethods.WINDOWS_PATH_LENTH_LIMIT);
			for (uint i = 0; i < NativeMethods.Everything_GetNumResults(); i++)
			{
				NativeMethods.Everything_GetResultFullPathName((uint)i, buffer, (uint)buffer.Capacity);
				string windowsPath = buffer.ToString();
				WslPath.convertWindowsPathToWsl(windowsPath);
				Console.WriteLine(buffer);
				buffer.Clear();
			}
		} 
    }
}


