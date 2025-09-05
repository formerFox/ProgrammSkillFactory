using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProgramm
{
    public static class FileService
    {
        /// Сервис для работы с файлами: чтение текста и разбивка на слова, вернет массив слов
        public static string[] GetTextWords()
        {
            string filePath = "input.txt";
            string text = "";

            // Проверки существования файлп не будет, т.к. файл в проекте
            
            // Читаем весь текст из файла
            text = File.ReadAllText(filePath);
            
            // Массив разделителей
            char[] separators = {
            ' ',      // пробел
            ',',      // запятая
            '-',      // дефис
            '.',      // точка
            '!',      // восклицательный знак
            '?',      // вопросительный знак
            ';',      // точка с запятой
            ':',      // двоеточие
            '\n',     // перевод строки (новая строка)
            '\r',     // возврат каретки
            '\t'      // табуляция
        };

            // Разбиваем текст на слова используя разделители
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);// StringSplitOptions.RemoveEmptyEntries удаляет пустые строки из результата
        }
    }
}
