using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
        class Program
        {
            static int class_symb(char c)
            {
                switch (c)
                {
                    case 'y': return 0;
                    case 'e': return 1;
                    case 's': return 2;
                    case 'n': return 3;
                    case 'o': return 4;
                    case 'x': return 5;
                    case 'r': return 6;
                    case 'z': return 7;

                default:
                        if (c - 48 == 1) return 8;
                        return 9;
                }
            }


            static void Main(string[] args)
            {
                char[] S = new char[1000000];    // row from file
                int ST;     // condition
                int CL;     // class
                int BEG = 0;    // number bedinning
                int[,] M = new int[,]   // all conditions
                {
                   { 1, -5, -5, 3, -5,  4, -5, 6,-5, -5 },
                   { 6, 2, -4, -4, -4, 6, -4, 6, 6, -4},
                   { -6, -6, -1,  -6,  -6, -6, -6, -6, -6, -6 },
                   { -6, -6, -6,  -6,  -2, -6, -6, -6, -6, -6 },
                   { 6, -4, -4, -4, 5, 6, -4, 6, 6, -4},
                   {  -6, -6,-6,  -6,  -6, -6, -3, -6, -6, -6 },
                   { 6, -4, -4, -4, -4, 6, -4, 6, 6, -4},

                 };
                string[] res = new string[] { "key word:yes ", "key word:no ", "key word:xor ", "iden from{x,y,z,1}-" };
                string filePath = @"C:\Users\Asus\Desktop\Сопронюк\Theory-of-compilation\ConsoleApp2\word.txtC:\Users\Asus\Desktop\Сопронюк\Theory-of-compilation\ConsoleApp2\word.txt\";
                string fileRead; //file fileRead
                string line;
                List<string> writeText = new List<string>();
                int i = 0, j = 0;
                do
                {
                    Console.WriteLine("Input file fileRead:");
                    fileRead = Console.ReadLine();
                }
                while (!File.Exists(filePath + fileRead));
                S[0] = '\0';

                ST = 0;
                StreamReader file =
                    new StreamReader(filePath + fileRead);

                // Folder, where a file is created.
                // Filename  
                string fileWrite = "write.txt";

                // Fullpath.  
                string fullPath = filePath + fileWrite;
                string foundedWord;
                int lineNumber = 1;
                while (true)
                {

                    foundedWord = "";
                    if (i < S.Length)
                    {
                        if ((ST == 0) && (S[i] == '\0'))
                        {
                            if ((S = (file.ReadLine()).ToCharArray()) == null)
                            {
                                writeText.Add("The end\n");
                                Console.WriteLine("The end\n");
                                file.Close();
                                return;
                            }
                            i = 0;
                        }
                    }
                    else
                    {
                        try
                        {

                            S = (file.ReadLine()).ToCharArray();
                        }
                        catch (Exception e)
                        {
                            foundedWord = "End file\n";
                            writeText.Add(foundedWord);
                            Console.WriteLine(foundedWord);
                            Console.ReadLine();
                            return;
                        }


                        i = 0;
                        lineNumber += 1;

                    }

                    if (ST == 0) BEG = i;
                    CL = class_symb(S[i]);
                    ST = M[ST, CL];
                    i++;
                    if (ST < 0)
                    {

                        if (ST == -1 || ST == -2 || ST == -3)
                        {
                            int index = Math.Abs(ST)-1;
                            string word = "";
                            for (j = BEG; j < i; j++)
                            {
                                word += S[j];

                            }

                            foundedWord = $"<row number={lineNumber},{res[index]}, {word}>\n";
                            writeText.Add(foundedWord);
                            Console.WriteLine(foundedWord);
                        }

                        
                    
                    if (ST == -4)
                        {
                            i--;
                            string word = "";
                            for (j = BEG; j < i; j++)
                            {
                                word += S[j];
                            }
                            foundedWord = $"<row number={lineNumber},{res[3]}, {word}>\n";
                            writeText.Add(foundedWord);
                            Console.WriteLine(foundedWord);

                        }

                        else if (ST == -6)
                        {
                            if (S[BEG] == 'y')
                            {
                                foundedWord = $"<row number={lineNumber},{res[3]}, y>\n";
                                Console.WriteLine(foundedWord);
                                writeText.Add(foundedWord);
                            }
                            if (S[BEG] == 'x')
                            {
                                foundedWord = $"<row number={lineNumber},{res[3]}, x>\n";
                                Console.WriteLine(foundedWord);
                                writeText.Add(foundedWord);
                            }
                            i--;
                        }
                        ST = 0;

                    }
                    string resText = "";
                    foreach (string item in writeText)
                    {
                        resText += item;
                    }
                    File.WriteAllText(fullPath, resText);
                }

            }
        }
    

}
