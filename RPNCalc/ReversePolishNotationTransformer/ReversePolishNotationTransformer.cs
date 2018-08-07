/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 07.08.2018
 * Time: 15:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace RPNCalc.ReversePolishNotationTransformer
{
	/// <summary>
	/// Description of ReversePolishNotationTransformer.
	/// </summary>
	public class ReversePolishNotationTransformer
	{
		protected TermLib.TermStack StackToTransform;
		
		public TermLib.TermStack OutputTermStack()
		{
			throw new NotImplementedException();
		}
		
		public ReversePolishNotationTransformer(TermLib.TermStack TS)
		{
			StackToTransform=TS;
		}
	}
}
