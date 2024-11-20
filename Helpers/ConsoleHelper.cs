using System;
using System.Collections.Generic;

namespace TextAnalyzerApp.Helpers
{
    public static class ConsoleHelper
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Bienvenue dans l'Analyseur de Texte !");
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erreur : {message}");
            Console.ResetColor();
        }

        public static void PrintAnalysisResults(int lineCount, int wordCount, int charCount, Dictionary<string, int> mostFrequentWords)
        {
            Console.WriteLine("\n--- Résultats de l'analyse ---");
            Console.WriteLine($"Nombre de lignes : {lineCount}");
            Console.WriteLine($"Nombre de mots : {wordCount}");
            Console.WriteLine($"Nombre de caractères : {charCount}");
            Console.WriteLine("\nMots les plus fréquents :");
            foreach (var word in mostFrequentWords)
            {
                Console.WriteLine($"- {word.Key} : {word.Value} fois");
            }
        }
    }
}
