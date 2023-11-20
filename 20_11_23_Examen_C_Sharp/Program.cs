namespace _20_11_23_Examen_C_Sharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            UserStorage userStorage = new UserStorage();
            FileManager fileManager = new FileManager();

            //Загружать пользователей из файла при запуске
            List<User> users = new List<User>();

            fileManager.LoadFromFile("C:\\Users\\Ж - 17\\Documents\\Feofanov\\20_11_23_Examen_C_Sharp\\20_11_23_Examen_C_Sharp\\bin\\Debug\\net7.0\\users.json");
            foreach (var user in users)
            {
                userStorage.AddUser(user);
            }

            while (true)
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id}, {user.Username}, {user.Email}");
                }
                Console.WriteLine("1. Добавить пользователя");
                Console.WriteLine("2. Получить пользователя");
                Console.WriteLine("3. Обновить пользователя");
                Console.WriteLine("4. Удалить пользователя");
                Console.WriteLine("5. Выход");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите данные пользователя:");
                        Console.Write("Id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        User newUser = new User
                        {
                            Id = id,
                            Username = username,
                            Email = email
                        };
                        userStorage.AddUser(newUser);
                        break;
                    case "2":
                        Console.Write("Введите  Id: ");
                        int userId = Convert.ToInt32(Console.ReadLine());
                        User getUser = userStorage.GetUser(userId);

                        if (getUser != null)
                        {
                            Console.WriteLine($"Пользователь: {getUser.Username}, Email: {getUser.Email}");
                        }
                        else
                        {
                            Console.WriteLine("Не найден Пользователь");
                        }
                        break;
                    case "3":
                        // Update user
                        break;
                    case "4":
                        Console.Write("Введите Id для удаления: ");
                        int deleteUserId = Convert.ToInt32(Console.ReadLine());
                        userStorage.DeleteUser(deleteUserId);
                        break;
                    case "5":
                        // Save users to file before exiting
                        fileManager.SaveToFile(users, "users.json");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!!!");
                        break;
                }
            }

        }
    }
}
