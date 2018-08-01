/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 25.07.2018
 * Time: 15:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;


namespace RPNCalc
{
	/// <summary>
	/// Description of TermStackAndFunc.
	/// </summary>
	public static partial class TermLib
	{
		public class TermStack
		{
			protected List<TermAbsClass> Terms;
			protected int pointer;	//points the top of the stack
			public bool isEmpty { get { return pointer<0; } }
			
			public TermStack()
			{
				pointer =-1;
				Terms=new List<TermAbsClass>();
			}
			
			public TermAbsClass Pop()
			{
				if (pointer<0)
					throw new IndexOutOfRangeException();
				return Terms[pointer--];
			}
			
			public void Push(TermAbsClass x)
			{
				if (pointer<0)
				{
					Terms.Add(x);
					pointer++;
				}
				else
				{
					if (pointer++<=Terms.Count)
						Terms[pointer]=x;
					else
						Terms.Add(x);
				}
			}		
		}
		public class StringSplitter
		{
			protected int currentPosition;
			protected int currentTermStartPosition;
			protected TermTypes currentTermType;
			
			public StringSplitter()
			{
				currentPosition=0; currentTermStartPosition=0;
				currentTermType = TermTypes.NUL;
			}
			
			public void getTermFromString(string input, ref TermStack TStack, ref int startPositionPointer)
			{
				TermTypes tt;
				TermAbsClass term=null;
				bool isOK_Flag=false;
				int tmp=startPositionPointer;
				//string txt=TakePieceFromText(input,startPosition,input.Length-startPosition-1);
				
				if (Array.BinarySearch(OperatorSymbols,input[startPositionPointer])>=0 && !isOK_Flag)	//if is operator
				{
					tt=TermTypes.OPR;
					startPositionPointer++;
					if (Array.BinarySearch(OperatorSymbols,input[startPositionPointer])>=0)
						startPositionPointer++;
					string txt=TakePieceFromText(input,tmp,startPositionPointer-tmp);
					term = OPRTerm.GetOperatorTerm(txt);
					isOK_Flag=true;
				}
				
				if (char.IsDigit(input[startPositionPointer]) && !isOK_Flag)	//if a number
				{
					int len=0;
					bool isFloat=false;
					while (char.IsDigit(input[startPositionPointer+len]))
						len++;
					if (len>0 && input[startPositionPointer+len]=='.')
					{
						isFloat=true; len++;
					}
					while (char.IsDigit(input[startPositionPointer+len]))
						len++;
					
					if (isFloat)
					{
						double x = Convert.ToDouble(TakePieceFromText(input,startPositionPointer,len));
						term = new FLTTerm(x);
					}
					else
					{
						long x=Convert.ToInt64(TakePieceFromText(input,startPositionPointer,len));
						term = new INTTerm(x);
					}
					isOK_Flag=true;
					startPositionPointer+=len;
				}
				
				if (char.IsLetter(input[startPositionPointer]) && !isOK_Flag)
				{
					int len=1;
					
				}
				
				TStack.Push(term);
			}
		}
		
		private static string TakePieceFromText(string text, int startIndex, int length)
		{
	 		if (string.IsNullOrEmpty(text))
        		throw new ArgumentNullException("no text givin");

    		string result = string.Empty;
    		try
    		{
        		result = text.Substring(startIndex, length);
    		}
    		catch (Exception ex)
    		{ 
    			Console.WriteLine(ex.ToString());
    			// log exception
    		}
    		return result;
		}
	}
}
