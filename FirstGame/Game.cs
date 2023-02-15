using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame;

public enum Winner
{
    None,
    Win,
    Lose
}
class Game
{
    public string RndWord { get; private set; }
    public char UserLetter { get; private set; }
    public string HiddenWord { get; set; }
    public int Counter { get; private set; } = 6;

    // Класс Game, Главный класс для работы с игрой
    public Game()
    {
        string fileName = "words.txt";
        string[] allWords = File.ReadAllLines(fileName);

        RndWord = RandomWord(allWords);
        DisplayCoveredWord(RndWord);
    }

    public string RandomWord(string[] allWords)
    {
        Random random = new Random();
        string randomWord = allWords[random.Next(allWords.Length - 1)];

        RndWord = randomWord;

        return RndWord;

    }

    public void DisplayCoveredWord(string rndWord)
    {
        foreach (char letter in rndWord)
        {
            HiddenWord += "*";
        }
    }
    public void ChooseLetter()
    {

        string? input = Console.ReadLine();
        string temp = "";
        if (input.Length != 0)
        {
            if (input.Length > 1)
            {
                temp = "Вы ввели больше одной буквы, попробуйте еще раз";
                ChooseLetter();
            }
            else
            {
                temp = $"Вы ввели букву - {input}";
                UserLetter = Convert.ToChar(input);
            }
        }
        else
        {
            temp = "Вы не ввели букву, попробуйте еще раз";
            ChooseLetter();
        }
    }


    public void CheckUserInput()
    {
        Console.WriteLine();
        int match = 0;
        string temp = "";
        for (int i = 0; i < RndWord.Length; i++)
        {
            if (RndWord[i] == UserLetter)
            {
                temp += RndWord[i];
                match++;
            }
            else
            {
                if (HiddenWord[i] == '*')
                {
                    temp += "*";
                }
                else
                {
                    temp += HiddenWord[i];
                }
            }
        }
        if (match == 0)
        {
            Counter--;

        }
        HiddenWord = temp;
    }
    public Winner GetWinner()
    {
        if (RndWord == HiddenWord)
        {
            return Winner.Win;
        }
        else
        {
            if (Counter > 0)
            {
                return Winner.None;
            }
            else return Winner.Lose;
        }
    }
}

