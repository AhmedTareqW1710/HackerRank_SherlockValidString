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

class Solution
{

    // Complete the isValid function below.
    static string isValid(string s)
    {
        string isValid = "";
        bool isEmptyList = false;
        int diffCount = 0;

        List<int> numberOfDouplicateOfeachChar = new List<int>();
        List<char> sList = s.ToArray().ToList();

        sList.Sort();

        while (!isEmptyList)
        {
            numberOfDouplicateOfeachChar.Add(sList.Where(x => x == sList[0]).Count());
            //sList.RemoveAll(x => x == sList[0]);
            sList.RemoveRange(0, sList.Where(x => x == sList[0]).Count());
            if (sList.Count <= 0)
                isEmptyList = true;
        }

        numberOfDouplicateOfeachChar.Sort();

        for (int i = 0; i < numberOfDouplicateOfeachChar.Count; i++)
        {
            if (i + 1 <= numberOfDouplicateOfeachChar.Count - 1)
            {
                if (numberOfDouplicateOfeachChar[i] == numberOfDouplicateOfeachChar[i + 1] && diffCount < 1)
                    continue;
                else if (i == 0 && numberOfDouplicateOfeachChar[i] < numberOfDouplicateOfeachChar[i + 1] && numberOfDouplicateOfeachChar[i] == 1 && diffCount < 1)
                    continue;
                else if (numberOfDouplicateOfeachChar[0] == 1 && numberOfDouplicateOfeachChar[0] < numberOfDouplicateOfeachChar[i] && numberOfDouplicateOfeachChar[i] < numberOfDouplicateOfeachChar[i + 1] && numberOfDouplicateOfeachChar[i + 1] - numberOfDouplicateOfeachChar[i] == 1)
                    diffCount = 2;
                else if (numberOfDouplicateOfeachChar[i] < numberOfDouplicateOfeachChar[i + 1] && numberOfDouplicateOfeachChar[i + 1] - numberOfDouplicateOfeachChar[i] == 1)
                    diffCount++;
                else if (numberOfDouplicateOfeachChar[i] < numberOfDouplicateOfeachChar[i + 1] && numberOfDouplicateOfeachChar[i + 1] - numberOfDouplicateOfeachChar[i] > 1 && diffCount > 0)
                    diffCount = 2;               
                else
                    diffCount = 2;
            }

            if (diffCount > 1)
            {
                isValid = "NO";
                break;
            }
            else
            {
                isValid = "YES";
            }
        }

        return isValid;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = isValid(s);

        Console.WriteLine(result);
        Console.ReadLine();

        //textWriter.Flush();
        //textWriter.Close();
    }
}
