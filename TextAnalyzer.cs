using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using TextAnalyzerApp;
using TextAnalyzerApp.Helpers;

namespace TextAnalyzerApp
{
    public static class TextAnalyzer
    {
        public static int CountLines(string text)
        {
            return text.Split('\n').Length;
        }

        public static int CountWords(string text)
        {
            char[] delimiters = { ' ', '\n', '\t', ',', '.', ';', ':', '!', '?' };
            return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int CountCharacters(string text)
        {
            return text.Length;
        }

        public static Dictionary<string, int> GetMostFrequentWords(string text, int topCount)
        {
            // Liste des séparateurs communs
            char[] delimiters = { ' ', '\n', '\t', ',', '.', ';', ':', '!', '?' };

            // Séparer les mots et supprimer les entrées vides
            string[] words = text
                .ToLower() // Convertir tout en minuscules pour éviter les doublons
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Filtrer les mots non pertinents (optionnel)
            words = words.Where(word => word.Length > 1).ToArray();

            // Compter les occurrences des mots
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordFrequency.ContainsKey(word))
                    wordFrequency[word]++;
                else
                    wordFrequency[word] = 1;
            }

            // Trier les mots par fréquence décroissante et retourner les "topCount" premiers
            return wordFrequency
                .OrderByDescending(w => w.Value)
                .Take(topCount)
                .ToDictionary(w => w.Key, w => w.Value);
        }

    }
}
