using System;
using System.IO;

public class PrepAsm
{
    public static void Main(String[] Args)
    {
        String[] lines = File.ReadAllLines(Args[0]);
        foreach(String line in lines)
        {
            if(line.Contains('<'))
            {
                String[] pieces = line.Split('<');
                if(pieces[1].Contains(':'))
                {
//                  Method names
                    Console.WriteLine();
                }
                else
                {
//                  Instruction
                    parse(line);
                }
            }
            else if(line != String.Empty)
            {
//                  Instruction
                    parse(line);
            }
        }
        Console.WriteLine();
    }

    private static void parse(String line)
    {
        string[] tokens = line.Split('\t');
        Console.Write(tokens[2].Split()[0] + " ");
    }
}
