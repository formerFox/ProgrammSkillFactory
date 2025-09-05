using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProgramm
{
    public static class InputProcessor
    {
        /// Метод для получения топ-N самых частых слов из массива
        /// <param name="words">Массив слов для анализа</param>
        /// <param name="topN">Количество слов для возврата (топ-10, топ-20 и т.д.)</param>
        /// <returns>Упорядоченная коллекция пар "слово-количество"</returns>
        public static List<KeyValuePair<string, int>> GetTopWords(string[] words, int topN)
        {
            // Шаг 1: Создаем словарь для подсчета частоты слов
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();// Ключ - слово, Значение - количество повторений

            // Шаг 2: Проходим по всем словам и подсчитываем частоту
            foreach (string word in words)
            {
                string lowerWord = word.ToLower().Trim();// Приводим слово к нижнему регистру

                if (lowerWord.Length < 2) continue;// Пропускаем слишком короткие слова

                if (wordCounts.ContainsKey(lowerWord)) wordCounts[lowerWord]++; // Если слово уже есть в словаре - увеличиваем счетчик на 1

                else wordCounts[lowerWord] = 1;// Если слова нет в словаре - добавляем его со счетчиком 1
            }

            // Шаг 3: Преобразуем словарь в список пар "слово-количество" для сортировки
            List<KeyValuePair<string, int>> wordList = new();

            // Проходим по всем элементам словаря и добавляем их в список
            foreach (var pair in wordCounts)
            {
                wordList.Add(new KeyValuePair<string, int>(pair.Key, pair.Value));
            }

            // Шаг 4: Сортируем список по количеству повторений (по убыванию)
            wordList.Sort((a, b) => b.Value.CompareTo(a.Value));// Используем метод Sort с лямбда-выражением для сравнения

            // Шаг 5: Берем только первые topN элементов (топ-10)
            List<KeyValuePair<string, int>> topWords = new List<KeyValuePair<string, int>>();

            int count = Math.Min(topN, wordList.Count);// Берем либо все слова, если их меньше topN, либо первые topN
            for (int i = 0; i < count; i++)
            {
                topWords.Add(wordList[i]);
            }

            return topWords;
        }

        /// Метод для вывода топ-слов
        /// <param name="topWords">Коллекция пар "слово-количество"</param>
        public static void PrintTopWords(List<KeyValuePair<string, int>> topWords)
        {
            if (topWords.Count == 0)
            {
                Console.WriteLine("Нет данных для вывода!");
                return;
            }

            Console.WriteLine("\nТОП-10 САМЫХ ЧАСТЫХ СЛОВ:");
            //Красивая рамка
            Console.WriteLine(new string('═', 35));
            Console.WriteLine("Место | Слово           | Количество");
            Console.WriteLine(new string('─', 35));

            // Выводим каждое слово с его частотой и местом в рейтинге
            for (int i = 0; i < topWords.Count; i++)
            {
                // Форматированный вывод с выравниванием:
                // {i + 1,5} - номер места (выравнивание на 5 символов вправо)
                // {topWords[i].Key,-15} - слово (выравнивание на 15 символов влево)  
                // {topWords[i].Value,9} - количество (выравнивание на 9 символов вправо)
                Console.WriteLine($"{i + 1,5} | {topWords[i].Key,-15} | {topWords[i].Value,9}");
            }

            Console.WriteLine(new string('─', 35));

        }
    }

}

