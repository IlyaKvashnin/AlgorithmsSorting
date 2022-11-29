using System;
using System.Collections.Generic;

namespace AlgorithmsSorting.ConsoleUI
{
    public class MenuLogic
    {
        private MenuCategory _current;

        public MenuLogic(MenuCategory root)
        {
            _current = root;
        }

        public void Run()
        {
            Stack<MenuCategory> wayBack = new Stack<MenuCategory>();

            int index = 0;

            while (true)
            {
                DrawMenu(0, 0, index);
                switch (System.Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < _current.Items.Length - 1)
                            index++;
                        else
                            index = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        else
                            index = _current.Items.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (_current.Items[index])
                        {
                            case MenuCategory category:
                                wayBack.Push(_current);
                                index = 0;
                                _current = category;
                                ConsoleHelper.CleanScreen();
                                break;
                            case MenuApplicationTextSorting executeAction:
                                executeAction.Action();
                                ReturnToMainMenu(index);
                                break;
                            case MenuApplicationExternalSorting executeAction:
                                executeAction.Action();
                                ReturnToMainMenu(index);
                                break;
                            case MenuAction action:
                                action.Action(action);
                                return;
                            case ReturnMenu back:
                                ConsoleHelper.CleanScreen();
                                if (back.Name == "Выход")
                                {
                                    System.Console.WriteLine("Вы вышли из приложения.");
                                    Environment.Exit(0);
                                }     
                                if (wayBack.Count == 0)
                                    return;
                                MenuCategory parent = wayBack.Pop();
                                index = Array.IndexOf(parent.Items, _current);
                                _current = parent;
                                break;
                            default:
                                throw new InvalidCastException("Неизвестный тип пункта меню");
                        }
                        break;
                }
            }
        }

        public void ReturnToMainMenu(int index)
        {
            System.Console.WriteLine("\n");
            string inputChar;
            do
            {
                System.Console.WriteLine("Введите b/back для возвращения в главное меню, либо любой другой символ для выхода из программы");
                inputChar = System.Console.ReadLine();
                var needInputChar = inputChar?.ToLower();
                if ((needInputChar == "b") || (needInputChar == "back"))
                    break;
                else
                    Environment.Exit(0);
            } while (true);

            ConsoleHelper.CleanScreen();

            DrawMenu(0, 0, index);
        }

        public void DrawMenu(int row, int col, int index)
        {
            System.Console.SetCursorPosition(col, row);
            System.Console.WriteLine(_current.Name);
            System.Console.WriteLine();

            for (int i = 0; i < _current.Items.Length; i++)
            {
                if (i == index)
                {
                    System.Console.BackgroundColor = ConsoleColor.Gray;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }
                System.Console.WriteLine(_current.Items[i].Name);
                System.Console.ResetColor();
            }
            System.Console.WriteLine();
        }
    }
}
