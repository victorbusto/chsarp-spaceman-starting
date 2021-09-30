using System;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
      Game game = new Game();
      game.Greet();
      do {
        game.Display();
        game.Ask();
      } while (!game.DidWin() || !game.DidLose());

      Console.WriteLine("You {0}", game.DidWin() ? "win" : "lose");
    }
  }
}
