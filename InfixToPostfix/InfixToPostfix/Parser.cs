using System;
using System.Text;

namespace InfixToPostfix
{
	public class Parser
	{
		private readonly string _input;

		private StringBuilder _sb;
		public string Result
		{
			get { return _sb.ToString(); }
		}

		private int _position;
		private char CurrentToken
		{
			get
			{
				return _position < _input.Length ? _input[_position] : (char)0;
			}
		}

		public Parser(string input)
		{
			_input = input;
			_position = 0;

			_sb = new StringBuilder();
		}

		public void Expr()
		{
			Term(); Rest();
		}

		public void Rest()
		{
			switch(CurrentToken)
			{
				case '+':
					Match('+');
					Term();
					_sb.Append('+');
					Rest();
					break;

				case '-':
					Match('-');
					Term();
					_sb.Append('-');
					Rest();
					break;

				default:
					return;
					break;
			}
		}

		public void Term()
		{
			if(Char.IsDigit(CurrentToken))
			{
				char tmp = CurrentToken;
				Match(CurrentToken);
				_sb.Append(tmp);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public void Match(char token)
		{
			if(CurrentToken == token)
				_position++;
			else
				throw new InvalidOperationException();
		}
	}
}

