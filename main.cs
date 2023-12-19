using System;
using System.Collections.Generic;

class GameAccount
{
    public string UserName { get; private set; } // Властивість для імені користувача
    public int CurrentRating { get; private set; } // Властивість для поточного рейтингу користувача
    public int GamesCount { get; private set; } // Властивість для лічильника ігор користувача
    private List<GameResult> gameHistory; // Приватний список результатів ігор користувача

    public GameAccount(string userName, int initialRating)
    {
        UserName = userName; // Ініціалізація імені користувача
        CurrentRating = initialRating; // Ініціалізація початкового рейтингу
        GamesCount = 0; // Ініціалізація лічильника ігор
        gameHistory = new List<GameResult>(); // Створення порожнього списку результатів ігор
    }

    public void WinGame(string opponentName, int rating)
    {
        CurrentRating += rating; // Збільшення рейтингу при перемозі
        GamesCount++; // Збільшення лічильника ігор
        gameHistory.Add(new GameResult(opponentName, true, rating)); // Додавання результату гри до історії
    }

    public void LoseGame(string opponentName, int rating)
    {
        CurrentRating -= rating; // Зменшення рейтингу при поразці
        GamesCount++; // Збільшення лічильника ігор
        gameHistory.Add(new GameResult(opponentName, false, rating)); // Додавання результату гри до історії
    }

    public void GetStats()
    {
        Console.WriteLine($"Історія ігор для користувача {UserName}:");
        for (int i = 0; i < gameHistory.Count; i++)
        {
            string result = gameHistory[i].IsWin ? "перемога" : "поразка";
            Console.WriteLine($"Гра {i + 1}: Проти {gameHistory[i].OpponentName}, Результат: {result}, Рейтинг гри: {gameHistory[i].Rating}");
        }
    }

    private class GameResult
    {
        public string OpponentName { get; } // Властивість для імені суперника
        public bool IsWin { get; } // Властивість, що показує, чи виграна гра
        public int Rating { get; } // Властивість для рейтингу гри

        public GameResult(string opponentName, bool isWin, int rating)
        {
            OpponentName = opponentName; // Ініціалізація імені суперника
            IsWin = isWin; // Ініціалізація результату гри (перемога чи поразка)
            Rating = rating; // Ініціалізація рейтингу гри
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GameAccount player1 = new GameAccount("Гравець1", 1000); // Створення об'єкта гравця з початковим рейтингом
        player1.WinGame("Гравець2", 50); // Гравець переміг гру з іншим гравцем
        player1.LoseGame("Гравець3", 30); // Гравець програв гру іншому гравцю
        player1.WinGame("Гравець4", 40); // Гравець знову переміг гру
        player1.GetStats(); // Виведення статистики ігор користувача
    }
}
