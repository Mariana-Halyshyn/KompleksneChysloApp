using System;

namespace KompleksneChysloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрація роботи з ієрархією класів Strichka та Kompleksne_chyslo");
            Console.WriteLine(new string('-', 70));

            Strichka[] objects = new Strichka[6];

           
            Console.WriteLine("1. Створення та заповнення першої половини масиву:");
            objects[0] = new Strichka { Name = "І" };
            objects[1] = new Kompleksne_chyslo(3, 4);  
            objects[2] = new Kompleksne_chyslo(1, -1);  

            for (int i = 0; i < objects.Length / 2; i++)
            {
                Console.WriteLine($"   [{i}]: {objects[i].GetText()}");
            }
            Console.WriteLine(new string('-', 70));


            Console.WriteLine("2. Клонування першої половини масиву в другу:");
            for (int i = 0; i < objects.Length / 2; i++)
            {
               
                objects[i + objects.Length / 2] = (Strichka)objects[i].Clone();
            }

            Console.WriteLine("\nПовний масив (оригінали та клони):");
            for (int i = 0; i < objects.Length; i++)
            {
                Console.WriteLine($"   [{i}]: {objects[i].GetText()}");
            }
            Console.WriteLine(new string('-', 70));


            Console.WriteLine("3. Спроба сортування змішаного масиву (очікується виняток):");
            try
            {
                Array.Sort(objects);
                Console.WriteLine("Масив успішно відсортовано (це не повинно було статись).");
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   ПОМИЛКА: {ex.Message}");
                Console.WriteLine("   Причина: Неможливо порівняти елементи різних несумісних типів (Strichka та Kompleksne_chyslo).");
                Console.ResetColor();
            }
            Console.WriteLine(new string('-', 70));


            Console.WriteLine("4. Демонстрація сортування на однорідному масиві комплексних чисел:");
            Kompleksne_chyslo[] complexArray = {
                new Kompleksne_chyslo(3, 4), 
                new Kompleksne_chyslo(5, 12),  
                new Kompleksne_chyslo(1, 1),   
                new Kompleksne_chyslo(0, 2)                };

            Console.WriteLine("\nМасив до сортування:");
            foreach (var num in complexArray) Console.WriteLine($"   {num.GetText()}");

            Array.Sort(complexArray); 
            Console.WriteLine("\nМасив після сортування (за зростанням модуля):");
            foreach (var num in complexArray) Console.WriteLine($"   {num.GetText()}");
            Console.WriteLine(new string('-', 70));


            Console.WriteLine("5. Демонстрація обробки винятків при операціях:");

            Kompleksne_chyslo a = new Kompleksne_chyslo(10, 20);
            Kompleksne_chyslo b = null;

            try
            {
                Console.WriteLine($"   Спроба додати null до комплексного числа: {a} + null");
                Kompleksne_chyslo result = a + b;
            }
            catch (ArgumentNullException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"   ПЕРЕХОПЛЕНО ВИНЯТОК: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nДемонстрація парсингу з рядка:");
            Kompleksne_chyslo fromStringValid = new Kompleksne_chyslo("5.5 і -2");
            Console.WriteLine($"   Парсинг коректного рядка '5.5 і -2': {fromStringValid.GetText()}");

            Kompleksne_chyslo fromStringInvalid = new Kompleksne_chyslo("це не число");
            Console.WriteLine($"   Парсинг некоректного рядка 'це не число': {fromStringInvalid.GetText()} (приймає нульове значення)");


            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}