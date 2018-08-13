/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 12.08.2018
 * Time: 18:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace RPNCalc
{
	/// <summary>
	/// Description of BytesConvertation.
	/// </summary>
	public static partial class TermLib
	{
		public static long BytesToINT(uint[] inp)
		{
			long outt=(long)inp[1]; outt=outt<<32; outt+=inp[0]; return outt;
		}
		
		public static uint[] INTToBytes(long inp)
		{
			uint[] val=new uint[2]; val[0]=(uint)inp; var tmp=inp>>32; val[1]=(uint)tmp; return val;
		}
		
		public static double BytesToDBL(uint[] inp)
		{
			long tmp0=inp[0]; long tmp1=inp[1]; tmp1=tmp1<<32; return BitConverter.Int64BitsToDouble(tmp0+tmp1);
		}
		
		public static uint[] DBLToBytes(double inp)
		{
			uint[] val=new uint[2]; 
			long tmp = BitConverter.DoubleToInt64Bits(inp);
			val[0] = (uint)tmp; val[1]=(uint)(tmp>>32);
			return val;
		}
		
		public static long LogicNumber(bool condition)
		{
			if(condition) return 1;
			else return 0;
		}
		
		public static long TransformToPseudoBool(long x)
		{
			if (x<=0)
				return 0;
			return 1;
		}
		
		public static TermAbsClass GetObjectFromVAR(TermAbsClass x)
		{
			if (x.GetTermType!=TermTypes.VAR)
				throw new ArgumentException();
			uint[] tmp=new uint[x.GetBitValue.Length-1];
			for (int i=1;i<x.GetBitValue.Length;i++)
			{
				tmp[i-1]=x.GetBitValue[i];
			}
			if((VARType)x.GetBitValue[0]==VARType.INT)
				return new INTTerm(tmp);
			if((VARType)x.GetBitValue[0]==VARType.FLT)
				return new FLTTerm(tmp); 
			throw new ArgumentException();
		}
	}
}
