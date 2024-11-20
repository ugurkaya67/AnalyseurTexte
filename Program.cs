using System;
using System.IO;
using TextAnalyzerApp;
using TextAnalyzerApp.Helpers;


namespace TextAnalyzerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.PrintWelcomeMessage();

            Console.Write("Veuillez entrer le chemin du fichier texte à analyser : ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                ConsoleHelper.PrintError("Le fichier spécifié n'existe pas.");
                return;
            }

            try
            {
                string text = File.ReadAllText(filePath);

                int lineCount = TextAnalyzer.CountLines(text);
                int wordCount = TextAnalyzer.CountWords(text);
                int charCount = TextAnalyzer.CountCharacters(text);
                var mostFrequentWords = TextAnalyzer.GetMostFrequentWords(text, 5);

                ConsoleHelper.PrintAnalysisResults(lineCount, wordCount, charCount, mostFrequentWords);
            }
            catch (Exception ex)
            {
                ConsoleHelper.PrintError($"Erreur lors de l'analyse du fichier : {ex.Message}");
            }
        }
    }
}
