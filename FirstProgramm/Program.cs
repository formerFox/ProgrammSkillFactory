using FirstProgramm;

List<User> users = new() 
{ 
    new User("25938","Ivan", true),
    new User("25694","Petr", false),
    new User("68594","Georg", true),
    new User("12574","John", false),
    new User("98564","Alex", true),
};

foreach (var user in users)
{
    if (user.IsPremium)
    {
        Console.WriteLine($"Hi, {user.Name}! Welcome back, premium user!");
    }
    else
    {
        Console.WriteLine($"Hi, {user.Name}!");
        User.ShowAds();
    }
    Console.WriteLine(new string('-', 50)); // Разделитель
}