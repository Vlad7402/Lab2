using System;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            string Enter;
            bool Ent;
            bool Chose;
            int Figer = 0;
            string FigerStr;
            while (true)
            {
                Console.WriteLine("Пожалуйста, выбереите фигуру.");
                Console.WriteLine("Введите 1 для выбора пешки.");
                Console.WriteLine("Введите 2 для выбора коня.");
                Console.WriteLine("Введите 3 для выбора слона.");
                Console.WriteLine("Введите 4 для выбора лодьи.");
                Console.WriteLine("Введите 5 для выбора короля.");
                Console.WriteLine("Введите 6 для выбора ферзя.");
                FigerStr = Console.ReadLine();
                int.TryParse(FigerStr, out Figer);
                Console.WriteLine("Пожалуйста, введите координаты до хода и после.");
                Console.WriteLine("Пример ввода:С3 Е2");
                Enter = Console.ReadLine();
                Ent = IsEnterFigerCorrect(FigerStr);
                if (Ent)
                {
                    if (Figer == 1) { FigerStr = "пешкой"; }else
                    if (Figer == 2) { FigerStr = "конём"; }else
                    if (Figer == 3) { FigerStr = "слоном"; }else
                    if (Figer == 4) { FigerStr = "лодьёй"; }else
                    if (Figer == 5) { FigerStr = "королём"; }else
                    if (Figer == 6) { FigerStr = "ферзьём"; }
                    Ent = IsEnterCoordinateCorrect(Enter);
                    if (Ent)
                    {
                        Chose = Choosing(Enter, Figer);
                        if (Chose)
                        {
                            Console.WriteLine("Ход "+ FigerStr +" верен.");
                        }
                    }
                    else { Console.WriteLine("Ошибка в формате ввода координат. Пожалуйста, повторите попытку."); }
                }
                else { Console.WriteLine("Ошибка при выборе фигуры. Пожалуйста, повторите попытку."); }
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            }

        }
        static bool IsEnterCoordinateCorrect(string str)
        {
            byte LettersResult = 0;
            bool Nums = false;
            bool Result = false;
            string Letters = "ABCDEFGH";
            char[] LettersChar = Letters.ToCharArray();
            if (str.Length >= 5)
            {
                if (char.IsDigit(str[1]) && char.IsDigit(str[4]))
                {
                    if (char.GetNumericValue(str[1]) <= 8 &&
                        char.GetNumericValue(str[4]) <= 8 &&
                        char.GetNumericValue(str[1]) != 0 &&
                        char.GetNumericValue(str[4]) != 0)
                    {
                        Nums = true;
                    }
                }
                for (int i = 0; i < 4;)
                {
                    for (int y = 0; y < 8;)
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
        static bool IsEnterFigerCorrect(string str)
        {
            bool Result = false;
            int Figer;
            int.TryParse(str, out Figer);
            if (Figer >0 && Figer< 7)
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
        static bool Choosing(string str, int FigNomber)
        {
            bool Result = false;
            if (FigNomber == 1) { Result = IsPawnCorrect(str); } else 
            if (FigNomber == 2) { Result = IsHorseCorrect(str); } else 
            if (FigNomber == 3) { Result = IsElephantkCorrect(str); } else 
            if (FigNomber == 4) { Result = IsRookCorrect(str); } else 
            if (FigNomber == 5) { Result = IsKingCorrect(str); } else 
            if (FigNomber == 6) { Result = IsRookCorrect(str) || IsElephantkCorrect(str); }
            return (Result);
        }
        static bool IsRookCorrect(string str)
        {
            bool Result = false;
            int GorisontalFirst = Convert.ToInt32(str[1]);
            int GorisontalSec = Convert.ToInt32(str[4]);
            int VerticalFirst = GetCoordinate(str, 0);
            int VerticalSec = GetCoordinate(str, 3);
            int VerticalDelta = GetDelta(VerticalFirst, VerticalSec);
            int GorisontalDelta = GetDelta(GorisontalFirst, GorisontalSec);
            if (VerticalDelta > 0 ^ GorisontalDelta > 0 )
            {
                Result = true;
            }
            return (Result);
        }
        static bool IsElephantkCorrect(string str)
        {
            bool Result = false;
            int GorisontalFirst = Convert.ToInt32(str[1]);
            int GorisontalSec = Convert.ToInt32(str[4]);
            int VerticalFirst = GetCoordinate(str, 0);
            int VerticalSec = GetCoordinate(str, 3);
            int VerticalDelta = GetDelta(VerticalFirst, VerticalSec);
            int GorisontalDelta = GetDelta(GorisontalFirst, GorisontalSec);
            if (VerticalDelta == GorisontalDelta)
            {
                Result = true;
            }
            return (Result);
        }
        static bool IsHorseCorrect(string str)
        {
            bool Result = false;
            int GorisontalFirst = Convert.ToInt32(str[1]);
            int GorisontalSec = Convert.ToInt32(str[4]);
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
        static bool IsPawnCorrect(string str)
        {
            bool Result = false;
            int GorisontalFirst = Convert.ToInt32(str[1]);
            int GorisontalSec = Convert.ToInt32(str[4]);
            int VerticalFirst = GetCoordinate(str, 0);
            int VerticalSec = GetCoordinate(str, 3);
            int VerticalDelta = GetDelta(VerticalFirst, VerticalSec);
            int GorisontalDelta = GetDelta(GorisontalFirst, GorisontalSec);
            if (VerticalDelta == 0 && GorisontalDelta == 1)
            {
                Result = true;
            }
            return (Result);
        }
        static bool IsKingCorrect(string str)
        {
            bool Result = false;
            int GorisontalFirst = Convert.ToInt32(str[1]);
            int GorisontalSec = Convert.ToInt32(str[4]);
            int VerticalFirst = GetCoordinate(str, 0);
            int VerticalSec = GetCoordinate(str, 3);
            int VerticalDelta = GetDelta(VerticalFirst, VerticalSec);
            int GorisontalDelta = GetDelta(GorisontalFirst, GorisontalSec);
            if (VerticalDelta <= 1 && GorisontalDelta <= 1 &&
                    (VerticalDelta + GorisontalDelta) == 1 || (VerticalDelta + GorisontalDelta) == 2)
            {
                Result = true;
            }
            return (Result);
        }
    }
}
