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

        public static void TestAddToEnd(string[] words)
        {
            Console.WriteLine("\nДОБАВЛЕНИЕ В КОНЕЦ:");

            var list = new List<string>();
            var linkedList = new LinkedList<string>();

            // List<T> - добавление в конец
            var stopwatch = Stopwatch.StartNew();
            foreach (string word in words)
            {
                list.Add(word);
            }
            stopwatch.Stop();
            long listTime = stopwatch.ElapsedMilliseconds;

            // LinkedList<T> - добавление в конец
            stopwatch.Restart();
            foreach (string word in words)
            {
                linkedList.AddLast(word);
            }
            stopwatch.Stop();
            long linkedListTime = stopwatch.ElapsedMilliseconds;

            PrintResults(listTime, linkedListTime, words.Length);
            Console.WriteLine($"   List capacity: {list.Capacity}, Count: {list.Count}");
        }

        public static void TestInsertAtBeginning(string[] words)
        {
            Console.WriteLine("\nВСТАВКА В НАЧАЛО:");

            var list = new List<string>();
            var linkedList = new LinkedList<string>();

            // List<T> - вставка в начало (медленно!)
            var stopwatch = Stopwatch.StartNew();
            foreach (string word in words)
            {
                list.Insert(0, word); // O(n) операция!
            }
            stopwatch.Stop();
            long listTime = stopwatch.ElapsedMilliseconds;

            // LinkedList<T> - вставка в начало (быстро!)
            stopwatch.Restart();
            foreach (string word in words)
            {
                linkedList.AddFirst(word); // O(1) операция!
            }
            stopwatch.Stop();
            long linkedListTime = stopwatch.ElapsedMilliseconds;

            PrintResults(listTime, linkedListTime, words.Length);
        }

        public static void TestInsertAtMiddle(string[] words)
        {
            Console.WriteLine("\nВСТАВКА В СЕРЕДИНУ:");

            var list = new List<string>();
            var linkedList = new LinkedList<string>();

            // List<T> - вставка в середину
            var stopwatch = Stopwatch.StartNew();
            foreach (string word in words)
            {
                int middleIndex = list.Count / 2;
                list.Insert(middleIndex, word); // O(n) операция
            }
            stopwatch.Stop();
            long listTime = stopwatch.ElapsedMilliseconds;

            // LinkedList<T> - вставка в середину (требуется поиск позиции)
            stopwatch.Restart();
            LinkedListNode<string> currentNode = null;
            foreach (string word in words)
            {
                if (currentNode == null || linkedList.Count == 0)
                {
                    linkedList.AddFirst(word);
                    currentNode = linkedList.First;
                }
                else
                {
                    // Находим середину (это дорогая операция для LinkedList)
                    int targetIndex = linkedList.Count / 2;
                    var targetNode = GetNodeAt(linkedList, targetIndex);

                    if (targetNode != null)
                    {
                        linkedList.AddAfter(targetNode, word);
                    }
                    else
                    {
                        linkedList.AddLast(word);
                    }
                }
            }
            stopwatch.Stop();
            long linkedListTime = stopwatch.ElapsedMilliseconds;

            PrintResults(listTime, linkedListTime, words.Length);
        }

        public static void TestRandomInsert(string[] words)
        {
            Console.WriteLine("\nСЛУЧАЙНАЯ ВСТАВКА:");

            var list = new List<string>();
            var linkedList = new LinkedList<string>();
            var random = new Random();

            // List<T> - случайная вставка
            var stopwatch = Stopwatch.StartNew();
            foreach (string word in words)
            {
                int randomIndex = list.Count == 0 ? 0 : random.Next(0, list.Count);
                list.Insert(randomIndex, word); // O(n) операция
            }
            stopwatch.Stop();
            long listTime = stopwatch.ElapsedMilliseconds;

            // LinkedList<T> - случайная вставка
            stopwatch.Restart();
            foreach (string word in words)
            {
                if (linkedList.Count == 0)
                {
                    linkedList.AddFirst(word);
                }
                else
                {
                    int randomIndex = random.Next(0, linkedList.Count);
                    var targetNode = GetNodeAt(linkedList, randomIndex);
                    linkedList.AddAfter(targetNode, word); // O(1) после нахождения узла
                }
            }
            stopwatch.Stop();
            long linkedListTime = stopwatch.ElapsedMilliseconds;

            PrintResults(listTime, linkedListTime, words.Length);
        }

        // Вспомогательный метод для получения узла по индексу (O(n) для LinkedList)
        static LinkedListNode<string> GetNodeAt(LinkedList<string> list, int index)
        {
            if (index < 0 || index >= list.Count)
                return null;

            LinkedListNode<string> current = list.First;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        static void PrintResults(long listTime, long linkedListTime, int operationsCount)
        {
            Console.WriteLine($"   List<T>:     {listTime} ms ({operationsCount} операций)");
            Console.WriteLine($"   LinkedList<T>: {linkedListTime} ms ({operationsCount} операций)");

            if (listTime > 0 && linkedListTime > 0)
            {
                double ratio = (double)listTime / linkedListTime;
                Console.WriteLine($"   Соотношение: {ratio:F2}x (List/LinkedList)");

                if (ratio > 1.5)
                    Console.WriteLine("LinkedList быстрее");
                else if (ratio < 0.67)
                    Console.WriteLine("List быстрее");
                else
                    Console.WriteLine("Производительность сравнима");
            }
        }
    }
}
