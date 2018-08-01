/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 23.07.2018
 * Time: 9:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace RPNCalc
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			TermLib.TermTypes t0 = TermLib.TermTypes.MRK;
			TermLib.TermTypes t1 = TermLib.TermTypes.OPR;
			TermLib.TermTypes t2 = TermLib.TermTypes.INT;
			TermLib.TermTypes t3 = TermLib.TermTypes.FLT;
			TermLib.TermTypes t4 = TermLib.TermTypes.VAR;
			Console.Write("My debug {0}, {1}, {2}, {3}, {4}",t0,t1,t2,t3,t4);
			Console.ReadKey(true);
		}
	}
	
	public static partial class TermLib {}
	
}