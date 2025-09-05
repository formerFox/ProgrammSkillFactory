using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FirstProgramm;

Console.WriteLine("=== Топ-10 слов в тексте===\n");

// Чтение текста из файла (или использование демо-текста)
string[] words = FileService.GetTextWords();

Console.WriteLine($"Загружено слов: {words.Length}");
Console.WriteLine($"Примеры: {string.Join(", ", words.Take(5))}...\n");

// Получаем топ-10 самых частых слов
var topWords = InputProcessor.GetTopWords(words, 10);

// Выводим результат
InputProcessor.PrintTopWords(topWords);

