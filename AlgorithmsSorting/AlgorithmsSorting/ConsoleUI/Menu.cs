﻿using System;
using System.Collections.Generic;

namespace AlgorithmsSorting.ConsoleUI
{
    public abstract class Menu
    {
        public string Name { get; }

        public Menu(string name)
        {
            Name = name;
        }
    }

    public class ReturnMenu : Menu
    {
        public ReturnMenu(string name) : base(name) { }
    }

    public class MenuCategory : Menu
    {
        public Menu[] Items { get; }

        public MenuCategory(string name, Menu[] items) : base(name)
        {
            Items = items;
        }
    }

    public class MenuAction : Menu
    {
        public Action<Menu> Action { get; }

        public MenuAction(string name, Action<Menu> action) : base(name)
        {
            Action = action;
        }
    }

    public class MenuApplicationTest : Menu
    {
        public Action Action { get; }

        public MenuApplicationTest(string name, Action action) : base(name)
        {
            Action = action;
        }
    }
}
