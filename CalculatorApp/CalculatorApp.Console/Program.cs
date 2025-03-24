using System;
using CalculatorApp.Logic;   
using CalculatorApp.Data;    

class Program
{
    static void Main(string[] args)
    {
        var kalkulator = new Calculator();


        var wynikDodawania = kalkulator.Add(5, 3);
        Console.WriteLine($"Wynik dodawania 5 + 3: {wynikDodawania.Result} ({wynikDodawania.Operation})");

        var wynikOdejmowania = kalkulator.Subtract(5, 3);
        Console.WriteLine($"Wynik odejmowania 5 - 3: {wynikOdejmowania.Result} ({wynikOdejmowania.Operation})");

        var wynikMnozenia = kalkulator.Multiply(5, 3);
        Console.WriteLine($"Wynik mnożenia 5 * 3: {wynikMnozenia.Result} ({wynikMnozenia.Operation})");

        var wynikDzielenia = kalkulator.Divide(5, 2);
        Console.WriteLine($"Wynik dzielenia 5 / 2: {wynikDzielenia.Result} ({wynikDzielenia.Operation})");


        Console.ReadLine();
    }
}
