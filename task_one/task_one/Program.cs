using System;

namespace task_one
{
    class Program
    {
        static void Main(string[] args)
        {
            //Савенко В.
            // проверка логина  от 2 до 10 символов сначала буквы, потом цифры
            Console.WriteLine("Введите логин:");
            string Login = Console.ReadLine();
            //97,122
            //48 - 57
            switch(checkLogin(Login))
            {
                case true:Console.WriteLine("Логин верен!");
                    break;
                case false:
                    Console.WriteLine("Логин не верен!");
                    break;
            }
        }

        // без регулярных выражений
        static bool checkLogin(string log)
        {
            string login = log.ToLower();
           // проверка на длину
            if (log.Length < 2 || log.Length > 10)
            {
                return false;
            }
            else
            {
                // проверка на корретность символов
                foreach(char c in log)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        return false;
                    }
                }
                // проверка на последовательность
                for (int i = login.Length - 2; i >=0; i--)
                {
                    if (char.IsDigit(login[i])) //буква
                    {
                        if (char.IsLetter(login[i+1]))
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
