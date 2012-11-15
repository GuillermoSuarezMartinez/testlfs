//***********************************************************************
// Assembly         : Orbita.VAHardware
// Author           : aiba�ez
// Created          : 05-11-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Orbita.VAHardware
{
	/// <summary>
	/// Some Win32 API functions
	/// </summary>
	[ComVisible(false)]
	public class Win32
	{
		// memcpy - copy a block of memery
		[DllImport("ntdll.dll")]
		public static extern
			int memcpy(int dst, int src, int count);

		// Supplies a pointer to an implementation of IBindCtx
		[DllImport("ole32.dll")]
		public static extern
		int CreateBindCtx(
			int reserved,
			out UCOMIBindCtx ppbc);

		// Converts a string into a moniker that identifies
		// the object named by the string
		[DllImport("ole32.dll", CharSet=CharSet.Unicode)]
		public static extern
		int MkParseDisplayName(
			UCOMIBindCtx pbc,
			string szUserName,
			ref int pchEaten,
			out UCOMIMoniker ppmk);

		// window styles
		[Flags]
		public enum WS
		{
			CHILD	= 0x40000000,
			VISIBLE	= 0x10000000
		}
	}
}
