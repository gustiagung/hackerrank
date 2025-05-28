using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'superReducedString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     

    public static string superReducedString(string s)
    {
        var result = s;
        
        var isContainDuplicate = true;
        while(isContainDuplicate)
        {
            var tempResult = ReducedString(result);
            if (tempResult != result)
            {
                result = tempResult;                
            } else {
                isContainDuplicate = false;
            }
        }
        
        return string.IsNullOrEmpty(result) ? "Empty String" : result;
    }
    
    private static string ReducedString(string s) {
        if (s.Length < 2) return s;
        
        for(var i=0; i < s.Length - 1; i++) {
            if (s[i] == s[i+1]) {
                s = s.Remove(i, 2);
                break;
            }
        }
        
        return s;
    }
    */
    
    /*
     * Complete the 'superReducedString' function below.
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */
    public static string superReducedString(string s)
    {
        var stack = new Stack<char>();

        foreach (char c in s)
        {
            if (stack.Count > 0 && stack.Peek() == c)
            {
                stack.Pop(); // Remove adjacent pair
            }
            else
            {
                stack.Push(c);
            }
        }

        if (stack.Count == 0) return "Empty String";

        // Rebuild the reduced string from the stack
        var result = new StringBuilder();
        foreach (char c in stack.Reverse()) // Stack is LIFO, reverse to get original order
        {
            result.Append(c);
        }

        return result.ToString();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.superReducedString(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
