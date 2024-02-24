namespace Guess_Word
{
    static class Words
    {
        public static List<string> word_list = new List<string>
        {
            "programming",
            "hangman",
            "computer",
            "software",
            "algorithm",
            "developer",
            "challenge",
            "language",
            "creativity",
            "coding"
        };

        public static string RandomWord()
        {
            return word_list[Func.Random(0, word_list.Count - 1)];
        }

        public static string HideWord(string word)
        {
            char[] hidden = new char[word.Length];

            for (int i = 0;  i < word.Length; i++)
            {
                hidden[i] = '_';
            }

            return new string(hidden);
        }

        public static void CheckGuessedChar(ref string guessword, string word, char c, ref int chartry, ref bool charCorrect, ref bool sameChar, ref bool charWrong)
        {
            c = char.ToLower(c);
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == c && guessword[i] == '_')
                {
                    charCorrect = true;
                    guessword = guessword.Remove(i, 1).Insert(i, c.ToString());
                }
                else if (word[i] == c && guessword[i] != '_')
                {
                    sameChar = true;
                }
                else
                {
                    charWrong = true;
                }
            }

            if (charCorrect) chartry++;
        }

        public static bool CheckWordComplete(string guessWord, ref bool charGuessComplete, ref int notGuessChar)
        {
            notGuessChar = 0;

            foreach (char c in guessWord)
            {
                if (c == '_') notGuessChar++;
            }

            if (notGuessChar > 0) return false;

            charGuessComplete = true;
            return true;
        }

        public static bool CheckAns(string guess, string word)
        {
            guess.ToLower();
            return guess == word;
        }

        public static int CheckSameChar(char thisChar, char preChar, ref int sameChar, ref bool personaChange)
        {
            if (preChar == null)
            {
                return 0;
            }

            if (thisChar == preChar)
            {
                sameChar++;
            }

            if(sameChar >= 3)
            {
                personaChange = true;
            }

            if (personaChange)
            {
                Dialogue.Angry();
                int a = Func.Choose();

                if (a == 1)
                {
                    Func.Print("...", 700);
                    Thread.Sleep(1000);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
