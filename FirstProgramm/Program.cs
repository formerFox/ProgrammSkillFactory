using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FirstProgramm;

Console.WriteLine("=== СРАВНЕНИЕ ПРОИЗВОДИТЕЛЬНОСТИ List<T> vs LinkedList<T> ДЛЯ ТЕКСТА ===\n");

// Чтение текста из файла (или использование демо-текста)
string[] words = FileService.GetTextWords();

Console.WriteLine($"Загружено слов: {words.Length}");
Console.WriteLine($"Примеры: {string.Join(", ", words.Take(5))}...\n");

// Тестируем разные сценарии вставки
InputProcessor.TestAddToEnd(words);
InputProcessor.TestInsertAtBeginning(words);
InputProcessor.TestInsertAtMiddle(words);
InputProcessor.TestRandomInsert(words);
