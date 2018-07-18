using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS = Abstract_Data_Structures;

namespace Problems.Stack
{
    public static class StackApplication
    {
        private const char OpenParantheSis = '(';
        private const char CloseParantheSis = ')';
        private const char OpenSquareBracket = '[';
        private const char CloseSquareBracket = ']';
        private const char OpenBraces = '{';
        private const char CloseBraces = '}';


        public static bool BalancingSymbols(string expression)
        {
            ADS.Stack<char> charactersStack = new ADS.Stack<char>();
            foreach (char item in expression)
            {
                switch(item)
                {
                    case OpenParantheSis:
                    case OpenSquareBracket:
                    case OpenBraces:
                        {
                            charactersStack.Push(item);
                            break;
                        }
                    case CloseParantheSis:
                        {
                            if(charactersStack.Pop()!=OpenParantheSis)
                            {
                                return false;
                            }
                            break;
                        }
                    case CloseSquareBracket:
                        {
                            if(charactersStack.Pop()!= OpenSquareBracket)
                            {
                                return false;
                            }
                            break;
                        }
                    case CloseBraces:
                        {
                            if(charactersStack.Pop()!=OpenBraces)
                            {
                                return false;
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            return charactersStack.IsEmpty();
        }
    }
}
