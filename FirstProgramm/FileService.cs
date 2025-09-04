using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProgramm
{
    public static class FileService
    {
        public static string[] GetTextWords()
        {
            // Попробуем прочитать текст из файла, если нет - используем демо-текст
            string filePath = "input.txt";
            string text = "";

            if (File.Exists(filePath))
            {
                text = File.ReadAllText(filePath);
                Console.WriteLine("Текст загружен из файла input.txt");
            }

            // Разбиваем текст на слова
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r', '\t' };
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
