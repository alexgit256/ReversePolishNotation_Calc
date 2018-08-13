/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 23.07.2018
 * Time: 9:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;

namespace RPNCalc
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			
			DebugTools.debug_ComplexOperatorTest();
			
			Console.WriteLine("Press any key to leave");
			Console.ReadKey(true);
		}
	}
	
	public static partial class TermLib {}
	
}