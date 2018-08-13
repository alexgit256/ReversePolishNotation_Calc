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
		
		public static void debug_TestOperator(TermLib.OPRType oper, TermLib.TermStack TStack)
		{
			TermLib.OPRTerm operObj=new TermLib.OPRTerm(oper);
			TermLib.PerformOperatorComputation(operObj,TStack);
			TermLib.TermAbsClass testt=TStack.Pop();
			Console.WriteLine(testt.debug_GetValueAsString());
		}
		
		public static void debug_ComplexOperatorTest()
		{
			
			Console.WriteLine("Write here your first number for plus check");
			string x = Console.ReadLine();
			TermLib.TermStack testing=new TermLib.TermStack();
			TermLib.ScanExpression(x,ref testing);
			Console.WriteLine("And second one");
			x = Console.ReadLine();
			TermLib.ScanExpression(x,ref testing);
			DebugTools.debug_TestOperator(TermLib.OPRType.PLUS,testing);
			
			Console.WriteLine("Write here your first number for minus check");
			x = Console.ReadLine();
			testing=new TermLib.TermStack();
			TermLib.ScanExpression(x,ref testing);
			Console.WriteLine("and second one");
			x = Console.ReadLine();
			TermLib.ScanExpression(x,ref testing);
			DebugTools.debug_TestOperator(TermLib.OPRType.MINUS,testing);
			
			Console.WriteLine("Write here your first number for mult check");
			x = Console.ReadLine();
			testing=new TermLib.TermStack();
			TermLib.ScanExpression(x,ref testing);
			Console.WriteLine("and second one");
			x = Console.ReadLine();
			TermLib.ScanExpression(x,ref testing);
			DebugTools.debug_TestOperator(TermLib.OPRType.MULT,testing);
		}
	}
}
