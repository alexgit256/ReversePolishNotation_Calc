/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 12.08.2018
 * Time: 17:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace RPNCalc
{
	/// <summary>
	/// Description of OperatorsImplementation.
	/// </summary>
	public static partial class TermLib
	{
		
		public static void PerformOperatorComputation(OPRTerm oper, TermStack TStack)
		{
			
			switch(oper.GetOperatorType)
			{
				case OPRType.EQUAL:
					throw new NotImplementedException();
						break;
				case OPRType.PLUS:
						TermAbsClass B = TStack.Pop();
						TermAbsClass A = TStack.Pop();
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(a+b));
								//Console.WriteLine("{0} is internal",TStack.Pop().debug_GetValueAsString());
								//TStack.Push(new INTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new FLTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if(A.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						break;
				case OPRType.MINUS:
						B = TStack.Pop();	//wtf(0_o)
						A = TStack.Pop();
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(a-b));
								//Console.WriteLine("{0} is internal",TStack.Pop().debug_GetValueAsString());
								//TStack.Push(new INTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a-b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new FLTTerm(a-b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a-b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if(A.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						break;
				case OPRType.MULT:
						B = TStack.Pop();
						A = TStack.Pop();
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(a*b));
								//Console.WriteLine("{0} is internal",TStack.Pop().debug_GetValueAsString());
								//TStack.Push(new INTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a*b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new FLTTerm(a*b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a*b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if(A.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						break;
				case OPRType.DIV:
						B = TStack.Pop();
						A = TStack.Pop();
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(a/b));
								//Console.WriteLine("{0} is internal",TStack.Pop().debug_GetValueAsString());
								//TStack.Push(new INTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a/b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new FLTTerm(a/b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a/b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if(A.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						break;
				case OPRType.PERCENT:
						B = TStack.Pop();
						A = TStack.Pop();
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(a%b));
								//Console.WriteLine("{0} is internal",TStack.Pop().debug_GetValueAsString());
								//TStack.Push(new INTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a%(long)b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new FLTTerm((long)a/b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm((long)a/(long)b));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if(A.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						break;
				case OPRType.LESS:
						B = TStack.Pop();
						A = TStack.Pop();
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a<b)));
								//Console.WriteLine("{0} is internal",TStack.Pop().debug_GetValueAsString());
								//TStack.Push(new INTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a<b)));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a<b)));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a<b)));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if(A.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						break;
				case OPRType.MORE:
						B = TStack.Pop();
						A = TStack.Pop();
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a>b)));
								//Console.WriteLine("{0} is internal",TStack.Pop().debug_GetValueAsString());
								//TStack.Push(new INTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a>b)));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a>b)));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a>b)));
							}
							if(B.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						}
						if(A.GetTermType==TermTypes.VAR)
								throw new NotImplementedException();
						break;
				case OPRType.EXL_MRK:	//NOT
						break;
				case OPRType.AMPERSANT:
						break;
				case OPRType.VERT_BAR:	//OR
						break;
				case OPRType.DBL_AMPERSANT:
						break;
				case OPRType.DBL_VERT_BAR:
						break;
				case OPRType.DBL_EXL_MRK:
						break;
				case OPRType.INCREMENT:
						break;
				case OPRType.DECREMENT:
						break;
				case OPRType.DBL_EQUAL:
						break;
				case OPRType.LEFT_SHIFT:
						break;
				case OPRType.RIGHT_SHIFT:
						break;
			}
			
		}
	}
}
