//  создаём пустой список с типом данных Contact
using FirstProgramm;

var phoneBook = new List<Contact>()
{ 
    // добавляем контакты
    new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
    new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
    new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
    new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
    new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
    new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
}
    .OrderBy(contact => contact.Name)   // OrderBy - первичная сортировка (по имени)
    .ThenBy(contact => contact.LastName)// ThenBy - вторичная сортировка (по фамилии, если имена одинаковые)
    .ToList();                          // Преобразуем обратно в список

// Бесконечный цикл для постоянной работы программы
while (true)
{
    // Получаем номер страницы от пользователя
    Console.WriteLine("\nВведите номер страницы (1, 2 или 3):");
    char input = Console.ReadKey().KeyChar;
    Console.WriteLine(); // Переход на новую строку после ввода

    switch (input)
    {
        case '1':
        case '2':
        case '3':
            int pageNumber = int.Parse(input.ToString());
            ShowContactsForPage(phoneBook, pageNumber); // Вызываем альтернативный метод
            break;

        case 'q':
        case 'Q':
            Console.WriteLine("Выход из программы...");
            return;

        default:
            Console.WriteLine("Ошибка: введите число от 1 до 3 или 'q' для выхода!");
            break;
    }
}


static void ShowContactsForPage(List<Contact> contacts, int pageNumber)
{
    // 🆕 Switch expression для определения диапазона контактов
    var (skip, take) = pageNumber switch
    {
        1 => (0, 2),  // Страница 1: пропустить 0, взять 2
        2 => (2, 2),  // Страница 2: пропустить 2, взять 2
        3 => (4, 2),  // Страница 3: пропустить 4, взять 2
        _ => (0, 0)   // По умолчанию: ничего не показывать
    };

    // 📱 Получаем контакты для страницы
    var pageContacts = contacts
        .Skip(skip)
        .Take(take)
        .ToList();

    Console.WriteLine($"\n=== Страница {pageNumber} ===");

    if (!pageContacts.Any())
    {
        Console.WriteLine("На этой странице нет контактов!");
        return;
    }

    // Выводим каждый контакт красиво оформленным
    foreach (var contact in pageContacts)
    {
        Console.WriteLine($"{contact.Name} {contact.LastName}");
        Console.WriteLine($"Телефон: {contact.PhoneNumber}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine(); // Пустая строка между контактами
    }
}
