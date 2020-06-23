﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace evfind
{
    internal class NativeMethods
    {

		public const int WINDOWS_PATH_LENTH_LIMIT = 260;

		[DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
		public static extern UInt32 Everything_SetSearchW(string lpSearchString);
		[DllImport("Everything64.dll")]
		public static extern void Everything_SetMatchPath(bool bEnable);
		[DllImport("Everything64.dll")]
		public static extern void Everything_SetMatchCase(bool bEnable);
		[DllImport("Everything64.dll")]
		public static extern void Everything_SetMatchWholeWord(bool bEnable);
		[DllImport("Everything64.dll")]
		public static extern void Everything_SetRegex(bool bEnable);
		[DllImport("Everything64.dll")]
		public static extern void Everything_SetMax(UInt32 dwMax);
		[DllImport("Everything64.dll")]
		public static extern void Everything_SetOffset(UInt32 dwOffset);

		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetMatchPath();
		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetMatchCase();
		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetMatchWholeWord();
		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetRegex();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetMax();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetOffset();
		[DllImport("Everything64.dll")]
		public static extern IntPtr Everything_GetSearchW();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetLastError();

		[DllImport("Everything64.dll")]
		public static extern bool Everything_QueryW(bool bWait);

		[DllImport("Everything64.dll")]
		public static extern void Everything_SortResultsByPath();

		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetNumFileResults();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetNumFolderResults();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetNumResults();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetTotFileResults();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetTotFolderResults();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetTotResults();
		[DllImport("Everything64.dll")]
		public static extern bool Everything_IsVolumeResult(UInt32 nIndex);
		[DllImport("Everything64.dll")]
		public static extern bool Everything_IsFolderResult(UInt32 nIndex);
		[DllImport("Everything64.dll")]
		public static extern bool Everything_IsFileResult(UInt32 nIndex);
		[DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
		public static extern void Everything_GetResultFullPathName(UInt32 nIndex, StringBuilder lpString, UInt32 nMaxCount);
		[DllImport("Everything64.dll")]
		public static extern void Everything_Reset();

		[DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr Everything_GetResultFileName(UInt32 nIndex);

		// Everything 1.4
		[DllImport("Everything64.dll")]
		public static extern void Everything_SetSort(UInt32 dwSortType);
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetSort();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetResultListSort();
		[DllImport("Everything64.dll")]
		public static extern void Everything_SetRequestFlags(UInt32 dwRequestFlags);
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetRequestFlags();
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetResultListRequestFlags();
		[DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr Everything_GetResultExtension(UInt32 nIndex);
		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetResultSize(UInt32 nIndex, out long lpFileSize);
		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetResultDateCreated(UInt32 nIndex, out long lpFileTime);
		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetResultDateModified(UInt32 nIndex, out long lpFileTime);
		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetResultDateAccessed(UInt32 nIndex, out long lpFileTime);
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetResultAttributes(UInt32 nIndex);
		[DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr Everything_GetResultFileListFileName(UInt32 nIndex);
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetResultRunCount(UInt32 nIndex);
		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetResultDateRun(UInt32 nIndex, out long lpFileTime);
		[DllImport("Everything64.dll")]
		public static extern bool Everything_GetResultDateRecentlyChanged(UInt32 nIndex, out long lpFileTime);
		[DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr Everything_GetResultHighlightedFileName(UInt32 nIndex);
		[DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr Everything_GetResultHighlightedPath(UInt32 nIndex);
		[DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr Everything_GetResultHighlightedFullPathAndFileName(UInt32 nIndex);
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_GetRunCountFromFileName(string lpFileName);
		[DllImport("Everything64.dll")]
		public static extern bool Everything_SetRunCountFromFileName(string lpFileName, UInt32 dwRunCount);
		[DllImport("Everything64.dll")]
		public static extern UInt32 Everything_IncRunCountFromFileName(string lpFileName);


	}
}
