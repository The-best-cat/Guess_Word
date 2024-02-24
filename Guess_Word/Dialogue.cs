namespace Guess_Word
{
    static class Dialogue
    {
        public static void PrintList(List<string> list)
        {
            foreach (string item in list)
            {
                Func.Print(item + '\n', 25);
            }
            Console.WriteLine();
        }

        public static void Start()
        {
            Func.Print("Press <Enter>, ", 30);
            Thread.Sleep(300);
            Func.Print("I'll randomly choose a word.\n\n", 30);
            Func.Pause();
        }

        public static void Loading()
        {
            for (int i = 0; i < 4; i++)
            {
                Func.Print("...", 95);
                Console.Clear();
            }
        }

        public static void StartGuessing()
        {
            Func.Print("Start guessing~\n\n", 30);
        }

        public static void CharOrAns(int charTry, int ansTry)
        {
            Func.Print("Let me guess a character (" + charTry + " chances)[1]    I know the answer (" + ansTry + " chances)[2]\n", 30);
        }

        public static void TypeChar()
        {
            Func.Print("Good. Tell me the character you guess: ", 30);
        }

        public static void CharCorrect()
        {
            Thread.Sleep(500);
            List<string> list = new List<string> { "Not bad.\n\n", "Keep going.\n\n", "I'm impressed.\n\n" };
            Func.Print(list[Func.Random(0, list.Count - 1)], 30);
            Thread.Sleep(300);
        }

        public static void CharWrong()
        {
            Thread.Sleep(500);
            List<string> list = new List<string> { "Whoops...\n\n", "Don't blame you.\n\n", "Unlucky.\n\n" };
            Func.Print(list[Func.Random(0, list.Count - 1)], 30);
            Thread.Sleep(300);
        }

        public static void TypeAns()
        {
            Func.Print("Let's go: ", 30);
        }

        public static void AnsCorrect()
        {
            Func.Print("Smart! I knew you can do it. \n", 30);
            Thread.Sleep(300);
        }

        public static void AnsWrong()
        {
            Thread.Sleep(500);
            Func.Print("Not quite. ", 30);
            Thread.Sleep(300);
            Func.Print("Don't worry, you got this.\n\n", 30);
            Thread.Sleep(300);
        }

        public static void NoCharTry()
        {
            Func.Print("Sorry, you ran out of chance. ", 30);
            Thread.Sleep(200);
            Func.Print("Try your best to guess the answer.\n\n", 30);
        }

        public static void Lose()
        {
            Func.Print("I know you tried your best.\n\n", 30);
        }

        public static void Angry()
        {
            Thread.Sleep(400);
            Func.Print("...Are you guessing it wrong on purpose?\n\n", 100);
            Thread.Sleep(200);
            Func.Print("Yes[1]   No[2]\n", 60);
        }

        public static void SameChar()
        {
            Func.Print("Already got that one, try again.\n\n", 30);
            Thread.Sleep(300);
        }

        public static void GuessByChar()
        {
            Func.Print("Well, you just figured it out by guessing the characters, well done!\n", 25);
            Thread.Sleep(300);
        }

        public static void AlmostGuessByChar()
        {
            List<string> list = new List<string> { "You are getting it!\n\n", "Almost there!\n\n", "Come on you can do it!\n\n" };
            Func.Print(list[Func.Random(0, list.Count - 1)], 30);
            Thread.Sleep(300);
        }

        public static void NullInputManyTimes()
        {
            Func.Print("JESUS CHRIST JUST INPUT A CHARACTER IS IT THAT HARD??????: ", 25);
        }
    }
}
