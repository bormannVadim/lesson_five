using System;
using System.Text;

namespace Task_two
{
    class Program
    {
        static void Main(string[] args)
        {
            // Савенко В.Р.
            // Задание 2 класс Message
            Console.WriteLine("Введите текс:");
            string Text = Console.ReadLine(); // по идеи нужно удалить всё, что не буквы и не пробелы

            string AnalyzeText = Message.RemoveNotLetters(Text);

            Console.WriteLine("Введите длинну слов:");
            int length = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Получившийся текст:");
            Console.WriteLine(Message.PrintWordsFixedLength(AnalyzeText, length));

            Console.WriteLine("Введите символ слова оканчивающиеся на который будут удалены!");
            char ch = (char)Console.Read();

            Console.WriteLine("Получившаяся строка:");
            Console.WriteLine(Message.RemoveCharEnded(AnalyzeText, ch));

            Console.WriteLine("Самое длинное слово:");
            Console.WriteLine(Message.MaxLengthWord(AnalyzeText));

            Console.WriteLine("Предложение из самых длинных слов:");
            Console.WriteLine(Message.CreateMaxLengthWordsSentense(AnalyzeText));

        }
    }

    class Message
    {
        // удаляем все не буквы
        public static string RemoveNotLetters(string text)
        {
            string ResultString = "";
            foreach (char ch in text)
                if (char.IsLetter(ch) || char.IsWhiteSpace(ch))
                {
                    ResultString += ch;
                }
                else
                    ResultString += " ";
            return ResultString;
        }
        public static string PrintWordsFixedLength(string stroka, int length)
        {
            //32 -  пробел
            string[] StrArray = stroka.Split(' ');
            string ResultString = "";
            for (int i = 0; i < StrArray.Length; i++)
            {
                if (StrArray[i].Length <= length)
                {
                    ResultString += StrArray[i] + " ";
                }
            }
            if (ResultString.Length != 0)
               ResultString.Substring(ResultString.Length - 1);

            return ResultString;
        }

        public static string RemoveCharEnded(string text, char chr)
        {
            string[] StrArray = text.Split(' ');
            string ResultString = "";
            for (int i = 0; i < StrArray.Length; i++)
            {
                if (StrArray[i] !="")
                    if (StrArray[i][StrArray[i].Length-1] != chr)
                    {
                        ResultString += StrArray[i] + " ";
                    }
            }
            if (ResultString.Length != 0)
                ResultString.Substring(ResultString.Length - 1);

            return ResultString;

        }

        public static string MaxLengthWord(string text)
        {
            string[] StrArray = text.Split(' ');
            string maxLengthWord = StrArray[0];
            for (int i = 1; i < StrArray.Length; i++)
            {

                if (StrArray[i].Length > maxLengthWord.Length)
                {
                    maxLengthWord = StrArray[i];
                }
            }
            return maxLengthWord;
        }

        public static StringBuilder CreateMaxLengthWordsSentense(string text)
        {
            StringBuilder bl = new StringBuilder();
            string[] StrArray = text.Split(' ');
            string maxLengthWord = StrArray[0];
            // определить длинну максимальных слов

            for (int i = 1; i < StrArray.Length; i++)
            {
                if (StrArray[i].Length > maxLengthWord.Length)
                {
                    maxLengthWord = StrArray[i];
                }
            }

            for (int j = 0; j < StrArray.Length; j++)
            {
                if (StrArray[j] != "")
                if (StrArray[j].Length == maxLengthWord.Length)
                {
                    bl.Append(StrArray[j] + " ");
                }
            }
            
            if (bl.Length != 0)
                bl.Remove(bl.Length-1, 1);
            return bl;
        }
    }
}
