using System;
using System.IO;

public class PrepAsm
{
    private static String[] mInstructions = null;

    public static void Main(String[] Args)
    {
        if (Args.Length == 1)
        {
            String[] lines = File.ReadAllLines(Args[0]);
            foreach(String line in lines)
            {
                if(line.Contains('<'))
                {
                    String[] pieces = line.Split('<');
                    if(pieces[1].Contains(':'))
                    {
//                      Method names
                        Console.WriteLine();
                    }
                    else
                    {
//                      Instruction
                        parse(line);
                    }
                }
                else if(line != String.Empty)
                {
//                      Instruction
                        parse(line);
                }
            }
            Console.WriteLine();
        }
        else
        {
            mInstructions    = File.ReadAllLines(Args[0]);
            String[] arm64   = File.ReadAllLines(Args[1]);
            String[] program = File.ReadAllLines(Args[2]);

            foreach(String line in program)
            {
                Int32 index = find(line.ToLower());
                if (index != -1)
                {
                    Console.WriteLine(arm64[index]);
                }
            }
        }
    }

    private static Int32 find(String instruction)
    {
        Int32 index = 0;
        while(index < mInstructions.Length)
        {
            if(mInstructions[index].Equals(instruction))
            {
                return index;
            }
            index++;
        }

        return -1;
    }

    private static void parse(String line)
    {
        string[] tokens = line.Split('\t');
        Console.Write(tokens[2].Split()[0] + " ");
    }

    private void ngrams()
    {
        Int32 ndx = 0;
        Int32 grams = Int32.Parse(Args[1])-1;
        String[] lines = File.ReadAllLines(Args[0]);
        foreach(String line in lines)
        {
            if(ndx < lines.Length-grams)
            {
                String output = line;
                for(Int32 i = 1; i <= grams; i++)
                {
                    output += "-" + lines[ndx+i];
                }
                Console.WriteLine(output);
                ndx++;
            }
        }
    }
}
