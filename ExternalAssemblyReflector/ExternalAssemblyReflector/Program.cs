﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO; // для использования FileNotFoundException.

namespace ExternalAssemblyReflector
{
    class Program
    {
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Типы в сборке *****");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types) Console.WriteLine("Type: {0}", t);
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** Просмотр внешней сборки *****");
            string asmName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine("\nВведите сборку для оценки");
                Console.Write("или Q для выхода: ");
                // Получение имени сборки.
                asmName = Console.ReadLine();
                // Пользователь хочет выйти?
                if (asmName.ToUpper() == "Q")
                {
                    break;
                }
                // Проверка загрузки сборки.
                try
                {
                    asm = Assembly.LoadFrom(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch
                {
                    Console.WriteLine("Sorry, can’t find assembly.");
                }
            } while (true);
        }
    }
}