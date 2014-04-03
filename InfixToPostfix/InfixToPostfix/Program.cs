using System;

namespace InfixToPostfix
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Parser p = new Parser("9-5+2");
			p.Expr();

			Console.WriteLine(p.Result);
		}
	}
}
