using System;
using System.Collections.Generic;

public class ExpressionBalanceChecker
{
    /// <summary>
    /// Checks if a mathematical expression is balanced using a stack
    /// </summary>
    /// <param name="expression">Mathematical expression to check</param>
    /// <returns>True if expression is balanced, false otherwise</returns>
    public static bool IsBalancedExpression(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in expression)
        {
            // Opening brackets
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            // Closing brackets
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                // If stack is empty, no matching opening bracket
                if (stack.Count == 0)
                    return false;

                char top = stack.Pop();

                // Check if brackets match
                if ((ch == ')' && top != '(') ||
                    (ch == '}' && top != '{') ||
                    (ch == ']' && top != '['))
                {
                    return false;
                }
            }
        }

        // Stack should be empty for a balanced expression
        return stack.Count == 0;
    }

    /// <summary>
    /// Towers of Hanoi implementation using recursion and stack principles
    /// </summary>
    public class TowersOfHanoi
    {
        /// <summary>
        /// Solves Towers of Hanoi problem
        /// </summary>
        /// <param name="n">Number of disks</param>
        /// <param name="source">Source rod</param>
        /// <param name="auxiliary">Auxiliary rod</param>
        /// <param name="destination">Destination rod</param>
        public static void SolveTowersOfHanoi(int n, char source, char auxiliary, char destination)
        {
            // Base case: if only one disk, move directly
            if (n == 1)
            {
                Console.WriteLine($"Move disk 1 from {source} to {destination}");
                return;
            }

            // Move n-1 disks from source to auxiliary rod
            SolveTowersOfHanoi(n - 1, source, destination, auxiliary);

            // Move the nth disk from source to destination
            Console.WriteLine($"Move disk {n} from {source} to {destination}");

            // Move n-1 disks from auxiliary to destination rod
            SolveTowersOfHanoi(n - 1, auxiliary, source, destination);
        }

        // Example usage method
        public static void Main()
        {
            // Test balanced expression
            string expression1 = "{7+(8*5)-[(9-7)+(4+1)]}";
            Console.WriteLine($"Is {expression1} balanced? {IsBalancedExpression(expression1)}");

            // Test Towers of Hanoi
            Console.WriteLine("\nTowers of Hanoi Solution:");
            SolveTowersOfHanoi(3, 'A', 'B', 'C');
        }
    }
}
