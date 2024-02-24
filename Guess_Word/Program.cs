namespace Guess_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            Func.Choice choice;
            bool guessComplete = false, charCorrect = false, charWrong = false, ansWrong = false, invalid = false, personaChange = false, sameChar = false, charGuessComplete = false;
            int charTryTime = 4, ansTryTime = 3, sameCharTime = 0, notGuessChar = 0;
            char thisChar = '\0', preChar = '\0';

            Dialogue.PrintList(Words.word_list);

            Dialogue.Start();

            Dialogue.Loading();

            string guessWord = Words.RandomWord();
            string word = guessWord;

            guessWord = Words.HideWord(guessWord);

            while (!guessComplete && ansTryTime > 1)
            {
                if (charTryTime > 4) { charTryTime = 4; }

                Console.WriteLine(guessWord + '\n');

                if (!personaChange)
                {
                    if (charCorrect)
                    {
                        charCorrect = false;
                        if (notGuessChar <= 3)
                        {
                            Dialogue.AlmostGuessByChar();
                        }
                        else
                        {
                            Dialogue.CharCorrect();
                        }
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else if (sameChar)
                    {
                        sameChar = false;
                        Dialogue.SameChar();
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else if (charWrong)
                    {
                        charTryTime--;
                        charWrong = false;
                        Dialogue.CharWrong();
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else if (ansWrong)
                    {
                        ansTryTime--;
                        ansWrong = false;
                        Dialogue.AnsWrong();
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else if (charTryTime <= 0)
                    {
                        Dialogue.NoCharTry();
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else
                    {
                        Dialogue.StartGuessing();
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                }
                else
                {
                    if (charCorrect)
                    {
                        charCorrect = false;
                        Func.Print(".\n\n", 100);
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else if (sameChar)
                    {
                        sameChar = false;
                        Func.Print("....\n\n", 100);
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else if (charWrong)
                    {
                        charTryTime--;
                        charWrong = false;
                        Func.Print("....\n\n", 100);
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else if (ansWrong)
                    {
                        ansTryTime--;
                        ansWrong = false;
                        Func.Print("....\n\n", 100);
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else if (charTryTime <= 0)
                    {
                        Func.Print("....\n\n", 100);
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                    else
                    {
                        Dialogue.StartGuessing();
                        Dialogue.CharOrAns(charTryTime, ansTryTime);
                    }
                }

                int c = Func.Choose();
                choice = (Func.Choice)c;
                Console.Clear();

                switch(choice)
                {
                    case Func.Choice.character:
                        {
                            if (charTryTime <= 0) break;
                            
                            string temp;
                            int invalidTime = -1;
                            do
                            {
                                invalidTime++;

                                if (invalidTime == 3)
                                {
                                    Dialogue.NullInputManyTimes();
                                }
                                else if(invalidTime == 4)
                                {
                                    Func.Print("...: ", 30);
                                }
                                else if (invalidTime == 5)
                                {
                                    Func.Print("Bye.", 30);
                                    Thread.Sleep(1000);
                                    Environment.Exit(0);
                                }
                                else
                                {                                  
                                    Dialogue.TypeChar();
                                }
                                
                                temp = Console.ReadLine();
                                Console.Clear();
                            } while (Func.InvalidInput(temp, ref thisChar));

                            int i = Words.CheckSameChar(thisChar, preChar, ref sameCharTime, ref personaChange);
                            if (i == 1) { Environment.Exit(0); }

                            Dialogue.Loading();

                            Words.CheckGuessedChar(ref guessWord, word, thisChar, ref charTryTime, ref charCorrect, ref sameChar, ref charWrong);

                            if (Words.CheckWordComplete(guessWord, ref charGuessComplete, ref notGuessChar)) guessComplete = true;

                            break;
                        }

                    case Func.Choice.answer:
                        {
                            int invalidTime = -1;
                            string ans;
                            do
                            {
                                invalidTime++;

                                if (invalidTime == 0 && !personaChange)
                                {
                                    Dialogue.TypeAns();
                                }
                                else if (invalidTime > 0 && !personaChange)
                                {
                                    Func.Print("?: ", 30);
                                }
                                else
                                {
                                    Func.Print("....: ", 30);
                                }
                                ans = Console.ReadLine();
                                Console.Clear();
                            } while (ans == null || ans.Length == 0);

                            Dialogue.Loading();

                            guessComplete = Words.CheckAns(ans, word);
                            if (!guessComplete) ansWrong = true;

                            break;
                        }

                    default:
                        {
                            break;
                        }
                }

                preChar = thisChar;
            }

            if (guessComplete && !charGuessComplete)
            {
                Console.WriteLine(word + '\n');
                Dialogue.AnsCorrect();
                Func.Pause();
            }
            else if (charGuessComplete)
            {
                Console.WriteLine(word + '\n');
                Dialogue.GuessByChar();
                Func.Pause();
            }
            else if (!personaChange)
            {
                Console.WriteLine(word + '\n');
                Dialogue.Lose();
                Func.Pause();
            }
            else
            {
                Func.Print("It's \"" + word + "\".\n\n");
                Func.Pause();
            }
        }
    }
}