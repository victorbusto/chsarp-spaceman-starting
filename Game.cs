using System;

namespace Spaceman
{
    class Game {
        private string codeword;
        private string currentWord;
        private int numberOfGuesses;
        private int maxNumberOfGuesses;
        private string[] guesses = new string[]{"space", "galaxy", "moon", "star", "planet", "sun", "asteroid", };
        private Ufo ufo = new Ufo();

        public string Codeword { get; set; }
        public string CurrentWord { get; set; }
        public int NumberOfGuesses { get; set; }
        public int MaxNumberOfGuesses { get; set; }

        public Game() {
            Random random = new Random();
            Codeword = guesses[random.Next(guesses.Length)];
            MaxNumberOfGuesses = 3;
            NumberOfGuesses = 0;
            for (int i = 0; i < Codeword.Length; i++)
            {
                CurrentWord += '_';
            }
        }

        public bool DidWin() {
            return Codeword.Equals(CurrentWord);
        }

        public bool DidLose() {
            return NumberOfGuesses >= MaxNumberOfGuesses;
        }

        public void Display() {
            Console.WriteLine(ufo.Stringify());

            Console.WriteLine("Current word: "+CurrentWord);
            Console.WriteLine("Number of guesses: "+NumberOfGuesses+ "/3");
        }

        public void Ask() {
            Console.WriteLine("Guess a letter: ");
            string guess = Console.ReadLine();
            if (guess.Length == 1) {
                Console.WriteLine("You introduced: "+guess);
                if (Codeword.Contains(guess)) {
                    for (int i = 0; i < Codeword.Length; i++) {
                        if (Codeword[i].Equals(guess[0])) {
                            CurrentWord = CurrentWord.Remove(i, 1).Insert(i, guess.ToString());
                            // The replace function exists in the string class but Codecademy says do it this way
                        }
                    }
                } else {
                    Console.WriteLine("Wrong guess! The human was abducted by the alien ship :'(");
                    NumberOfGuesses++;
                    ufo.AddPart();
                }
                
            } else {
                Console.WriteLine("Please enter a single letter.");
                return ;
            }
        }

        public void Greet() {
            Console.WriteLine("================");
            Console.WriteLine("Hello, Spaceman!");
            Console.WriteLine("================");
            Console.WriteLine("How to play: You need to save the human from alien abduction by guessing the letter");
            Console.WriteLine("You have 3 lives, and you can guess wrong 3 times");
            Console.WriteLine("Good luck!");
        }
    }

}