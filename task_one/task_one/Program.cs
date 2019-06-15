﻿using System;

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
                    int position = (int)c;
                    if ((position < 97 || position > 122) && (position < 48 || position > 57))
                    {
                        return false;
                    }
                }
                // проверка на последовательность
                for (int i = login.Length - 2; i > 0; i--)
                {
                    int position = login[i];
                    int previosPosition = login[i+1];
                    if (position > 47 && position < 58) //буква
                    {
                        if (previosPosition > 96 && previosPosition < 123)
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
