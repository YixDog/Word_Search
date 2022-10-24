using System;

namespace WordGame
{
    class Program
    {


        static void Main(string[] args)
        {
            //Defining important variables.
            string InputText = "";
            string[] SplittedInputText;
            string[] LowerWords;
            string InputPattern = "";
            bool WrongInput = true;
            int ArrayIndex = 0;
            int Charactercounter=0;
            int WordsRemoveCounter = 0;
            int InputRemoveCounter = 0;
            int starcounter = 0;

            //Taking and checking the input.            
            while (WrongInput)
            {
                WrongInput = false;
                char[] UsableCharsInput = { ' ', '.', ',', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the sentence");
                InputText = Console.ReadLine();
                Console.Clear();
                for (int i = 0; i < InputText.Length; i++)
                {
                    if (!(UsableCharsInput.Contains(Convert.ToChar(InputText[i]))))
                    {
                        Console.WriteLine("Please just use English alphabet with ',' and '.'");

                        WrongInput = true;
                        break;
                    }
                    else
                    {

                    }

                }
            }
            //Splitting text to the words.
            SplittedInputText = InputText.Split('.', ',', ' ');
            LowerWords = (InputText.ToLower()).Split('.', ',', ' ');
            //Finding the same words. So we can eliminating them.
            for (int i = 0; i < LowerWords.Length; i++)
            {
                for (int j = i+1; j < LowerWords.Length; j++)
                {
                    if (LowerWords[i] == LowerWords[j])
                    {
                        LowerWords[i]="%";
                        SplittedInputText[i] = "%";
                    }
                }
            }
                    
            bool WrongPattern = true;
            //Taking and controlling the pattern.
            while (WrongPattern)
            {
                WrongPattern = false;
                char[] UsableCharsPattern = { '*', '-', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please enter the pattern");
                InputPattern = Console.ReadLine();
                Console.Clear();


                for (int i = 0; i < InputPattern.Length; i++)
                {
                    if (!(UsableCharsPattern.Contains(Convert.ToChar(InputPattern[i]))))
                    {

                        Console.WriteLine("Please just use English alphabet with '*' and '-'");
                        WrongPattern = true;
                        break;

                    }

                }
            }
            if (!WrongPattern)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Text: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(InputText);
                Console.ForegroundColor = ConsoleColor.Blue;      //Just cosmetics :).
                Console.Write("Pattern: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(InputPattern);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Words:");
                Console.ForegroundColor = ConsoleColor.White;
            }
            InputPattern = InputPattern.ToLower();
            string newInputPattern = InputPattern;
            int starindex2 = 0;
            int starindex1 = 0;
            //Seeking and printing words for '*' pattern.
            for (int i = 0; i < InputPattern.Length; i++)
            {
                if(InputPattern[i] =='*')
                {
                    starcounter++;
                    if(starcounter == 1)        //Finding how many '*' pattern we have.
                    {
                        starindex1 = i;
                    }
                    else if(starcounter==2)
                    {
                        starindex2 = i;
                    }
                    
                }
            }
            if (InputPattern[0] == '*' && InputPattern.Length != 1)
            {
                
                for (int i = 0; i < SplittedInputText.Length; i++)
                {

                    if (starcounter == 1)
                    {
                        string Endswith = (InputPattern.Remove(0, 1));
                        if (LowerWords[i].EndsWith(Endswith))
                        {

                            if (starcounter == 1)
                            {

                                Console.WriteLine(SplittedInputText[i]);
                            }                           
                        }
                    }
                    else if (starcounter == 2)
                    {
                        
                        string Contains = (InputPattern.Remove(0, 1));
                        Contains = Contains.Remove(starindex2-1, InputPattern.Length-starindex2);
                        string LastEndswith = InputPattern.Remove(0, starindex2 + 1);                                             
                        if (LowerWords[i].Contains(Contains) &&LowerWords[i].EndsWith(LastEndswith))
                        {
                            
                            Console.WriteLine(SplittedInputText[i]);
                        }
                    }

                }
            }
            else if (InputPattern[0] == '*' && InputPattern.Length == 1)
            {
                for (int i = 0; i < SplittedInputText.Length; i++)
                {
                    Console.WriteLine(SplittedInputText[i]);
                }
            }
            else if (InputPattern[InputPattern.Length - 1] == '*' && InputPattern.Length != 1)
            {                
               
                for (int i = 0; i < SplittedInputText.Length; i++)
                {

                    if (starcounter == 1)
                    {
                        string Startswith = (InputPattern.Remove(0, 1));
                        if (LowerWords[i].EndsWith(Startswith))
                        {                           
                            Console.WriteLine(SplittedInputText[i]);
                        }
                    }
                    else if (starcounter == 2)
                    {
                        string Contains = (InputPattern.Remove(0, starindex1+1));
                        Contains = Contains.Remove(Contains.Length-1,1);
                        string LastStartswith = InputPattern.Remove(starindex1, InputPattern.Length-starindex1);
                        if (LowerWords[i].Contains(Contains) && LowerWords[i].StartsWith(LastStartswith))
                        {
                          
                            Console.WriteLine(SplittedInputText[i]);
                        }
                    }
                }
            }
            else if(InputPattern[0]!='*'&& InputPattern[InputPattern.Length-1] != '*'&&InputPattern.Contains('*'))
            {
                              
                for (int i = 0; i < LowerWords.Length; i++)
                {
                    if (starcounter == 1)
                    {
                        string Startswith = (InputPattern.Remove(starindex1, InputPattern.Length - starindex1));
                        string Endswith = (InputPattern.Remove(0, starindex1 + 1));
                        if (LowerWords[i].StartsWith(Startswith) && LowerWords[i].EndsWith(Endswith))
                        {
                            Console.WriteLine(SplittedInputText[i]);
                        }
                    }
                    else if (starcounter == 2)
                    {
                        string Contains = (InputPattern.Remove(0, starindex1 + 1));
                        Contains = Contains.Remove(starindex2-starindex1-1, InputPattern.Length-starindex2);
                        string LastStartswith = InputPattern.Remove(starindex1, InputPattern.Length - starindex1);
                        string LastEndswith = InputPattern.Remove(0, starindex2 +1);                       
                        if (LowerWords[i].Contains(Contains) && LowerWords[i].StartsWith(LastStartswith)&& LowerWords[i].EndsWith(LastEndswith))
                        {

                            Console.WriteLine(SplittedInputText[i]);
                        }
                    }
                }
            }
            //Seeking words for '-' pattern.
            else if (InputPattern.Contains('-'))
                {
                for (int i = 0; i < InputPattern.Length; i++) //Finding how many '-' we have.
                {
                    if (InputPattern[i] == '-')
                    {


                        Charactercounter++;
                    }                                       
                }
                int[] character = new int[Charactercounter];               
                for (int i = 0; i < InputPattern.Length; i++)
                {
                    if (InputPattern[i] == '-')
                    {
                        character[ArrayIndex] = i;//Finding which indexes have '-' pattern.

                        ArrayIndex++;
                    }
                }   
                for (int j = 0; j < LowerWords.Length; j++)
                {
                    
                    if (LowerWords[j].Length == InputPattern.Length)
                    {
                        WordsRemoveCounter = 0;
                        for (int m = 0; m < character.Length; m++)   //Removing letters in words and pattern for comparing each other. So we can finding the words that we want.
                        {
                            
                            LowerWords[j] = LowerWords[j].Remove(character[m]- WordsRemoveCounter, 1);
                            if (InputRemoveCounter < character.Length)
                            {
                                newInputPattern = newInputPattern.Remove(character[m] - InputRemoveCounter, 1);
                                InputRemoveCounter++;
                            }

                            WordsRemoveCounter++;
                        }

                    }
                }           
                //Printing words for '-' pattern.
                for (int y = 0; y < LowerWords.Length; y++)
                {
                                      
                    if (newInputPattern==LowerWords[y]&&SplittedInputText[y].Length==InputPattern.Length)
                    {
                        Console.WriteLine(SplittedInputText[y]);
                    }
                }               
            }  
            Console.ReadLine(); //For the not close automatically.
        }
    }
}
