namespace Guess_Word
{
    static class Func
    {
        public enum Choice
        {
            character = 1,
            answer = 2
        };

        public static void Pause()
        {
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            Console.Clear();
        }

        public static int Choose()
        {
            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (char.IsDigit(key.KeyChar))
                {
                    int number = int.Parse(key.KeyChar.ToString());
                    if (number == 1 || number == 2)
                    {
                        return number;
                    }
                }
            }
        }

        public static void Print(string text, int delay)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        public static int Random(int x,  int y)
        {
            Random random = new Random();
            return random.Next(x, y);
        }

        public static bool InvalidInput(string character, ref char thisChar)
        {
            if (character == null || character.Length == 0)
            {
                return true;
            }

            if (char.TryParse(character, out char charValue))
            {
                thisChar = charValue;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
