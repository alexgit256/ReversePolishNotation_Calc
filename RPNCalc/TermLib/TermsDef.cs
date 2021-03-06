﻿/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 23.07.2018
 * Time: 10:46
 * 
 * Here all Terms Types' fields and properties are defined.
 */
using System;
using System.Text.RegularExpressions;

namespace RPNCalc
{
	/// <summary>
	/// Defines classes for terms.
	/// </summary>
	public static partial class TermLib
	{
		public abstract class TermAbsClass
		{
			public abstract Boolean checkMatch(string input);	//check if input is given term
			public abstract string debug_GetValueAsString();	//
			protected TermTypes TermType;
			protected uint[] val;
			public TermTypes GetTermType { get {return TermType; } }
			public uint[] GetBitValue { get { return val; } }
			public uint[] SetBitValue { set { val=value; } }
			//public static abstract TermAbsClass getFromString(string input);
			//public abstract TermAbsClass GetResult(TermAbsClass TermA, TermAbsClass TermB);
			
			public TermAbsClass()	{ TermType = TermTypes.ERR; val=new uint[1]; val[0]=(int)ERRType.ERR_NOT_DEFINED; }
			public TermAbsClass(ERRType err)	{ TermType = TermTypes.ERR; val=new uint[1]; val[0]=(uint)err; }
			//public TermAbsClass()
		}
		
		/*public class EXPTerm: TermAbsClass
		{
			
		}*/
		
		public class ERRTerm: TermAbsClass
		{
			/*public TermAbsClass GetResult(TermAbsClass TermA, TermAbsClass TermB)
			{
				return new ERRTerm(ERRType.ERR_INVALID_ARGUMENTS);	//problems with arguments
			}*/
			public override string debug_GetValueAsString() { return "Error"; }
			public override bool checkMatch(string input) {return true;}
			
			public ERRTerm(ERRType err)	{ TermType = TermTypes.ERR; val=new uint[1]; val[0]=(uint)err; }
		}
	
		public class MRKTerm : TermAbsClass
		{
			/*public TermAbsClass GetResult(TermAbsClass TermA, TermAbsClass TermB) 
			{ 
				Console.WriteLine("Markup doesn't perform any operations!");
				return new ERRTerm(ERRType.ERR_GET_RESULT);	//ERR_15 No operations for markup
			}*/
			
			public MRKType MarkupType {get { return (MRKType)val[0];} }
			
			public override bool checkMatch(string input)
			{
				if (input.Length!=1)
					return false;
				
				if (Array.BinarySearch(Markup,input[0])>=0)	//if symbol is markup
					return true;
				return false;
			}
			
			public override string debug_GetValueAsString()
			{
				return String.Format("Markup: {0}", this.MarkupType);
			}
			
			public MRKTerm(string text)
			{
				base.val = new uint[1];
				base.TermType=TermTypes.MRK;
				switch (text) 
				{
					case ".":
						val[0]=(int)MRKType.POINT;
						break;
					case ",":
						val[0]=(int)MRKType.COMMA;
						break;
					case "(":
						val[0]=(int)MRKType.OP_PARENTHESIS;
						break;
					case ")":
						val[0]=(int)MRKType.CLS_PARENTHESIS;
						break;
					case "[":
						val[0]=(int)MRKType.OP_BRACKET;
						break;
					case "]":
						val[0]=(int)MRKType.CLS_BRACKET;
						break;
				}
			}
		}
	
		public class OPRTerm : TermAbsClass
		{
			protected OPRType opType;
			public OPRType GetOperatorType { get { return opType; } }
			
			public override bool checkMatch(string input)
			{
				if (input.Length>2)
					return false;
				if (Array.BinarySearch(OperatorSymbols,input[0])>=0)
					if (input.Length==1)
						return true;
					else
						if (Array.BinarySearch(OperatorSymbols,input[1])>=0)
							return true;
				return false;
			}
			
			public override string debug_GetValueAsString()
			{
				return String.Format("Operator: {0}", this.opType);
			}
			
			public TermAbsClass GetResult(params TermAbsClass[] TermA)
			{
				throw (new NotImplementedException());
			}
			
			public static OPRTerm GetOperatorTerm(string inpt)
			{
				OPRType tmp;
			
				switch(inpt)
				{
					case "=":
						tmp=OPRType.EQUAL;
						break;
					case "+":
						tmp=OPRType.PLUS;
						break;
					case "-":
						tmp=OPRType.MINUS;
						break;
					case "*":
						tmp=OPRType.MULT;
						break;
					case "/":
						tmp=OPRType.DIV;
						break;
					case "<":
						tmp=OPRType.LESS;
						break;
					case ">":
						tmp=OPRType.MORE;
						break;
					case "!":
						tmp=OPRType.EXL_MRK;
						break;
					case "&":
						tmp=OPRType.AMPERSANT;
						break;
					case "|":
						tmp=OPRType.VERT_BAR;
						break;
					case "==":
						tmp=OPRType.DBL_EQUAL;
						break;
					case "+=":
						tmp=OPRType.PLUS_EQUAL;
						break;
					case "-=":
						tmp=OPRType.MINUS_EQUAL;
						break;
					case "*=":
						tmp=OPRType.MULT_EQUAL;
						break;
					case ">=":
						tmp=OPRType.MORE_EQUAL;
						break;
					case "<=":
						tmp=OPRType.LESS_EQUAL;
						break;
					case "!!":
						tmp=OPRType.DBL_EXL_MRK;
						break;
					case "&&":
						tmp=OPRType.DBL_AMPERSANT;
						break;
					case "||":
						tmp=OPRType.DBL_VERT_BAR;
						break;
					case ">>":
						tmp=OPRType.RIGHT_SHIFT;
						break;
					case "<<":
						tmp=OPRType.LEFT_SHIFT;
						break;
					case "++":
						tmp=OPRType.INCREMENT;
						break;
					case "--":
						tmp=OPRType.DECREMENT;
						break;
					default:
						tmp=OPRType.ERROPR;
						//Console.Write("<{0}>",inpt);
						break;
				}
				return new OPRTerm(tmp);
			}
			
			public OPRTerm(OPRType oprT) {base.TermType=TermTypes.OPR; val = new uint[1]; val[0]=(uint)oprT; opType=oprT; }
			
		}
		
		public class INTTerm : TermAbsClass
		{
			/*public TermAbsClass GetResult(TermAbsClass TermA, TermAbsClass TermB)
			{
				return new ERRTerm(ERRType.ERR_INVALID_ARGUMENTS);	//problems with arguments
			}*/
			
			public override bool checkMatch(string input)
			{
				if (input.Length>max_Term_Length)
					return false;
				if (Regex.IsMatch(input,@"\d*"))
					return true;
				return false;
			}
			
			public override string debug_GetValueAsString()
			{
				return string.Format("Integer: {0}", this.Value);
			}
			
			public long Value
			{
				get { long outt=(long)val[1]; outt=outt<<32; outt+=val[0]; return outt; }
				set { val[0]=(uint)value; var tmp=value>>32; val[1]=(uint)tmp; }
			}
			
			public INTTerm(Int64 num)
			{
				TermType=TermTypes.INT;
				val=new uint[2];
				unchecked
				{
					val[0]=(uint)num;
					num=num>>32;
					val[1]=(uint)num;
				}
			}
			
			public INTTerm(uint[] inp)
			{
				TermType=TermTypes.INT;
				val=inp;
			}
		}
		
		public class FLTTerm : TermAbsClass
		{
			public override bool checkMatch(string input)
			{
				if (max_Term_Length<input.Length)
					return false;
				if (Regex.IsMatch(input,@"\d\.\d"))
					return true;
				return false;
			}
			
			public override string debug_GetValueAsString()
			{
				return String.Format("Float: {0}",this.Value);
			}
			
			public double Value
			{
				get { long tmp0=val[0]; long tmp1=val[1]; tmp1=tmp1<<32; return BitConverter.Int64BitsToDouble(tmp0+tmp1); }
				set { long tmp = BitConverter.DoubleToInt64Bits(value); val[0] = (uint)tmp; val[1]=(uint)(tmp>>32); }
			}
			
			public FLTTerm(double input)
			{
				base.TermType=TermTypes.FLT;
				long tmp = BitConverter.DoubleToInt64Bits(input);
				unchecked
				{
					val = new uint[2];
					val[0] = (uint)input;
					var tmp0=val[0];
					val[1]=(uint)(tmp>>32);	
					var tmp1=val[1];
				}
			}
			
			public FLTTerm(uint[] inp)
			{
				base.TermType=TermTypes.FLT;
				val=inp;
			}
		}
		
		public class VARTerm: TermAbsClass
		{
			protected VARType variableType;
			public VARType VariableType	//NORMALY NOT TO BE USED!
			{
				get 
				{
					return variableType;
				}
				set 
				{
					variableType=value;
				}
			}
			
			public override bool checkMatch(string input)
			{
				if (!Char.IsLetter(input[0]))
					return false;
				if (input.Length==1)
					return true;
				for (int i=1; i<input.Length; i++)
				{
					if (!Char.IsLetter(input[i]))
						if (input[i]!='_')
							return false;
				}
				return true;
			}
			
			public uint[] Value	//variable management
			{
				get { return val; }
				set { this.val = value; }
			}
			
			public override string debug_GetValueAsString()
			{
				string x=string.Empty;
				if (this.variableType==VARType.INT)
					x=string.Format("{0}", BytesToINT(GetObjectFromVAR(this).GetBitValue));
				if (this.variableType==VARType.FLT)
					x=string.Format("{0}", BytesToDBL(GetObjectFromVAR(this).GetBitValue));
				
				return String.Format("Variable: {0} = {1}",variableType, x);
			}
			
			public VARTerm(VARType var_type, uint[] intVal)
			{
				unchecked
				{
					variableType=var_type;
					base.TermType=TermTypes.VAR;
					base.val=null;
					base.val=new uint[intVal.Length+1];
					base.val[0]=(uint)var_type;
					Array.ConstrainedCopy(intVal,0,base.val,1,intVal.Length);
				}
			}
		}
		
		public class FNCTerm: TermAbsClass
		{
			//private byte[] functionTransform() {};
			
			public override bool checkMatch(string input)
			{
				if (!Char.IsLetter(input[0]))
					return false;
				if (input.Length==1)
					return true;
				for (int i=1; i<input.Length; i++)
				{
					if (!Char.IsLetter(input[i]))
						if (input[i]!='_')
							return false;
				}
				return true;
			}
			
			public override string debug_GetValueAsString()
			{
				return "Function";
			}
			
			public FNCTerm(FNCType func_type)
			{
				base.TermType=TermTypes.FNC;
				base.val = new uint[2];
				base.val[0] = (uint)func_type;
			}
		}
		
		public class NULLTerm : TermAbsClass	//e.g. for comments
		{
			public override bool checkMatch(string input) {return true;}
			public override string debug_GetValueAsString()
			{
				return "Null Term";
			}
			public NULLTerm(uint[] code)
			{
				base.val=code;
			}
		}
	}
}
