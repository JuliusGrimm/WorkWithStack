using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tools.Collections;

namespace WorkWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CStack nums = new CStack();
                CStack ops = new CStack();
                Console.WriteLine("Enter a math equation with proper spacing.");
                string expression = Console.ReadLine();      
                Calculate(nums, ops, expression);
                Console.WriteLine("\n" + nums.Pop());
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid characters entered.");
                Console.ReadLine();
            }
        }
        //IsNumber isn't built into C# so we must define it
        static bool IsNumber(string input)
        {
            bool flag = true;
            string pattern = (@"^\d+$");
            Regex validate = new Regex(pattern);
            if (!validate.IsMatch(input))
            {
                flag = false;
            }
            return flag;
        }

        static void Calculate(CStack N, CStack O, string exp)
        {
            string ch;
            string token = string.Empty;
            for(int p = 0; p < exp.Length;p++)
            {
                ch = exp.Substring(p, 1);
                if (IsNumber(ch) == true)
                    token += ch;
                    if (ch == " " || p == (exp.Length-1))
                    {
                        if (IsNumber(token))
                        {
                            N.Push(token);
                            token = string.Empty;
                        }
                    }
                    else if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
                    {
                        O.Push(ch);                       
                    }
                if (N.Count == 2)
                {
                    Compute(N, O);
                }
            }
        }

        static void Compute(CStack N, CStack O)
        {
            int operand1;
            int operand2;
            string oper;
            operand1 = Convert.ToInt32(N.Pop());
            operand2 = Convert.ToInt32(N.Pop());
            oper = Convert.ToString(O.Pop());
            switch(oper)
            {
                case "+":
                    N.Push(operand1 + operand2);
                    break;
                case "-":
                    N.Push(operand1 - operand2);
                    break;
                case "*":
                    N.Push(operand1 * operand2);
                    break;
                case "/":
                    N.Push(operand1 / operand2);
                    break;
            }
        }
    }
}
