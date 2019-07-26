﻿using System;

namespace 观察者
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.FallsIll += OnFallsIll;
            person.OnFallsIll();
            person.FallsIll -= OnFallsIll;
        }

        private static void OnFallsIll(object sender, FallsIllEventArgs eventArgs)
        {
            Console.WriteLine($"A doctor has been called to {eventArgs.str}");
        }
    }
}
