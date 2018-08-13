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
			
		unchecked
		{
				
			switch(oper.GetOperatorType)
			{
				case OPRType.EQUAL:
						TermAbsClass B = TStack.Pop();
						TermAbsClass A = TStack.Pop();
						if (A.GetTermType==TermTypes.INT||A.GetTermType==TermTypes.FLT)	//A is now totally B
						{
							TStack.Push(B);
						}
						if(A.GetTermType==TermTypes.VAR)	//A is now variable with B value (can be variable, that contains variable)
						{
							VARTerm tmp;	//(VARType)B.GetBitValue[0] gets variable type
							if(B.GetTermType==TermTypes.INT)
								tmp=new VARTerm(VARType.INT,B.GetBitValue);
							else
								if(B.GetTermType==TermTypes.FLT)
									tmp=new VARTerm(VARType.FLT,B.GetBitValue);
							else
									throw new NotImplementedException();
							TStack.Push(tmp);
						}
						break;
				case OPRType.PLUS:
						B = TStack.Pop();
						A = TStack.Pop();
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
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
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
						break;
				case OPRType.MULT:
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(a*b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new FLTTerm(a*b));
							}
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
						}
						break;
				case OPRType.DIV:
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
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
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
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
						}
						break;
				case OPRType.LESS:
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
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
						}
						break;
				case OPRType.MORE:
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
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
						}
						break;
				case OPRType.EXL_MRK:	//NOT
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);

						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if(a>0)
								TStack.Push(new INTTerm(0));
							else
								TStack.Push(new INTTerm(1));
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							int round =(int)(a+flt_round_tolerancy);
							if(round>0)
								TStack.Push(new INTTerm(0));
							else
								TStack.Push(new INTTerm(1));
						}
						break;
				case OPRType.AMPERSANT:	//boolean and
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(TransformToPseudoBool(a)&TransformToPseudoBool(b)));	//a and b are "booleans"
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(TransformToPseudoBool(a)&TransformToPseudoBool((long)(b+flt_round_tolerancy))));
							}
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							long tmp = (long)(a+flt_round_tolerancy);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(TransformToPseudoBool(tmp)&TransformToPseudoBool(b)));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								long tmp1=(long)(b+flt_round_tolerancy);
								TStack.Push(new INTTerm(TransformToPseudoBool(tmp)&TransformToPseudoBool(tmp1)));
							}
						}
						break;
				case OPRType.VERT_BAR:	//OR
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(TransformToPseudoBool(a)|TransformToPseudoBool(b)));	//a and b are "booleans"
								//Console.WriteLine("{0} is internal",TStack.Pop().debug_GetValueAsString());
								//TStack.Push(new INTTerm(a+b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(TransformToPseudoBool(a)|TransformToPseudoBool((long)(b+flt_round_tolerancy))));
							}
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							long tmp = (long)(a+flt_round_tolerancy);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(TransformToPseudoBool(tmp)|TransformToPseudoBool(b)));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								long tmp1=(long)(b+flt_round_tolerancy);
								TStack.Push(new INTTerm(TransformToPseudoBool(tmp)|TransformToPseudoBool(tmp1)));
							}
						}
						break;
				case OPRType.DBL_AMPERSANT:	//bitwise AND
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(a&b));	//a and b are "booleans"
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(a&(long)(b+flt_round_tolerancy)));
							}
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							long tmp = (long)(a+flt_round_tolerancy);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(tmp&b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								long tmp1=(long)(b+flt_round_tolerancy);
								TStack.Push(new INTTerm(tmp&tmp1));
							}
						}
						break;
				case OPRType.DBL_VERT_BAR:	//bitwise OR
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(a|b));	//a and b are "booleans"
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(a|(long)(b+flt_round_tolerancy)));
							}
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							long tmp = (long)(a+flt_round_tolerancy);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(tmp|b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								long tmp1=(long)(b+flt_round_tolerancy);
								TStack.Push(new INTTerm(tmp|tmp1));
							}
						}
						break;
				case OPRType.DBL_EXL_MRK:	//bitwise NOT
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							TStack.Push(new INTTerm(~a));	//~ is inversion
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							long tmp=(long)(a+flt_round_tolerancy);
							TStack.Push(new INTTerm(~tmp));
						}
						break;
				case OPRType.INCREMENT:
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							TStack.Push(new INTTerm(++a));	//~ is inversion
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							TStack.Push(new FLTTerm(a+flt_round_tolerancy));
						}
						break;
				case OPRType.DECREMENT:
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							TStack.Push(new INTTerm(--a));	//~ is inversion
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							TStack.Push(new FLTTerm(a-flt_round_tolerancy));
						}
						break;
				case OPRType.DBL_EQUAL:
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a==b)));	//a and b are "booleans"
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(a>(b-flt_round_tolerancy)||a<(b+flt_round_tolerancy))));
							}
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(LogicNumber(b>(a-flt_round_tolerancy)||b<(a+flt_round_tolerancy))));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								long tmp1=(long)(b+flt_round_tolerancy);
								TStack.Push(new INTTerm(LogicNumber(a==b)));
							}
						}
						break;
				case OPRType.LEFT_SHIFT:
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue)%64;
								TStack.Push(new INTTerm(a<<(int)b));	
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(a<<(int)(b+flt_round_tolerancy)%64));
							}
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							long tmp = (long)(a+flt_round_tolerancy);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(tmp<<(int)(b%64)));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								long tmp1=(long)(b+flt_round_tolerancy)%64;
								TStack.Push(new INTTerm(tmp<<(int)tmp1));
							}
						}
						break;
				case OPRType.RIGHT_SHIFT:
						B = TStack.Pop();
						A = TStack.Pop();
						if(A.GetTermType==TermTypes.VAR)
							A=GetObjectFromVAR(A);
						if(B.GetTermType==TermTypes.VAR)
							B=GetObjectFromVAR(B);
						
						if (A.GetTermType==TermTypes.INT)
						{
							long a=BytesToINT(A.GetBitValue);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue)%64;
								TStack.Push(new INTTerm(a>>(int)b));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								TStack.Push(new INTTerm(a>>(int)(b+flt_round_tolerancy)%64));
							}
						}
						if (A.GetTermType==TermTypes.FLT)
						{
							double a=BytesToDBL(A.GetBitValue);
							long tmp = (long)(a+flt_round_tolerancy);
							if (B.GetTermType==TermTypes.INT)
							{
								long b=BytesToINT(B.GetBitValue);
								TStack.Push(new INTTerm(tmp>>(int)(b%64)));
							}
							if(B.GetTermType==TermTypes.FLT)
							{
								double b=BytesToDBL(B.GetBitValue);
								long tmp1=(long)(b+flt_round_tolerancy)%64;
								TStack.Push(new INTTerm(tmp>>(int)tmp1));
							}
						}
						break;
			}	
				
		}
			
		}
	}
}
