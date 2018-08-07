/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 07.08.2018
 * Time: 16:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace RPNCalc
{
	/// <summary>
	/// Description of DebugTools.
	/// </summary>
	public static class DebugTools
	{
		public static void debug_ListAllTermsFromString(string x, bool internalTest)
		{
			Console.WriteLine(x);

			TermLib.TermStack TStack = new TermLib.TermStack();
			TermLib.ScanExpression(x,ref TStack);
			while (!TStack.isEmpty) 
			{
				try 
				{
					if (internalTest)
						Console.Write("{0}, ", TStack.Pop().debug_GetValueAsString());
					else
						Console.Write("{0}, ", TStack.Pop().GetTermType);
				} 
				catch (IndexOutOfRangeException e) 
				{
					Console.WriteLine(e.ToString());
					break;
				}
			}
		}
	}
}
