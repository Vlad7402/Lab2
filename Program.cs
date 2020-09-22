using System;

namespace Lab2
{
    class Program
    {
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Пожалуйста, введите координаты коня до хода и после.");
                Console.WriteLine("Пример ввода:С3 Е2");
                string Enter;
                Enter = Console.ReadLine();
                bool Ent = IsEnterCorrect(Enter);
                if (Ent)
                {
                    bool chose = IsChoseCorrect(Enter);
                    if (chose)
                    {
                        Console.WriteLine("Ход конём верен.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ход конём не верен, пожалуйста, повторите попытку.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка в формате ввода. Пожалуйста, повторите попытку.");
                }
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            }

        }
        static bool IsEnterCorrect(string str)
        {
            byte LettersResult = 0;
            bool Nums = false;
            bool Result = false;
            string Letters = "ABCDEFGHIJ";
            char[] LettersChar = Letters.ToCharArray();
            if (str.Length >= 5)
            {
                if (char.IsDigit(str[1]) && char.IsDigit(str[4]))
                {
                    Nums = true;
                }
                for (int i = 0; i < 4;)
                {
                    for (int y = 0; y < 10;)
                    {
                        if (LettersChar[y] == str[i])
                        {
                            LettersResult++;
                        }
                        y++;
                    }
                    i = i + 3;
                }
            }
            if (Nums && LettersResult == 2)
            {
                Result = true;
            }
            return (Result);
        }
        static bool IsChoseCorrect(string str)
        {
            bool Result = false;
            char FirstCoordinate = str[1];
            char SecCoordinate = str[4];
            int GorisontalFirst = Convert.ToInt32(char.GetNumericValue(FirstCoordinate));
            int GorisontalSec = Convert.ToInt32(char.GetNumericValue(SecCoordinate));
            int VerticalFirst = GetCoordinate(str, 0);
            int VerticalSec = GetCoordinate(str, 3);
            int VerticalDelta = GetDelta(VerticalFirst, VerticalSec);
            int GorisontalDelta = GetDelta(GorisontalFirst, GorisontalSec);
            if (VerticalDelta <= 2 &&
                GorisontalDelta <= 2 &&
                (VerticalDelta + GorisontalDelta) == 3
                )
            {
                Result = true;
            }
            return (Result);
        }
        static int GetCoordinate(string str, int ID)
        {
            string Letters = "ABCDEFGHIJ";
            char[] LettersChar = Letters.ToCharArray();
            int Coordinate = 0;
            for (int y = 0; y <= 9;)
            {
                if (LettersChar[y] == str[ID])
                {
                    Coordinate = y;
                }
                y++;
            }
            return (Coordinate);
        }
        static int GetDelta(int a, int b)
        {
            int Result = a - b;
            return (Math.Abs(Result));
        }
    }
}
