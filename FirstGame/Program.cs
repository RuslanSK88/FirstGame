namespace FirstGame;
class Program
{
    private static Game _game = new Game();
    static void Main()
    {

        while (_game.GetWinner() == Winner.None)
        {
            PrintGame();
            _game.ChooseLetter();
            _game.CheckUserInput();
        }
        if (Winner.Win == _game.GetWinner())
        {
            PrintGame();
            Console.WriteLine();
            Console.WriteLine("Ты победил");
        }
        else
        {
            PrintGame();
            Console.WriteLine();
            Console.WriteLine("Ты проиграл");
            Console.WriteLine($"Правильное слово - {_game.RndWord}");
        }

    }
    static void PrintGame()
    {

        Console.Clear();
        Console.WriteLine("Перед вами игра - Виселица");
        Console.WriteLine($"Число попыток = {_game.Counter}");
        Console.WriteLine(_game.HiddenWord);
        Console.Write("Введите букву: ");
    }
}

