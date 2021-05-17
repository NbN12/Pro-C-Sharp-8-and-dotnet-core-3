﻿using System;

namespace GenericDelegate
{
    // This generic delegate can represent any method
    // returning void and taking a single parameter of type T.
    public delegate void MyGenericDelegate<T>(T arg);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Generic Delegates *****\n");

            // Register targets.
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data");

            //Using the method group conversion syntax
            MyGenericDelegate<int> intTarget = IntTarget;
            intTarget(9);

            Console.ReadLine();
        }

        private static void IntTarget(int arg)
        {
            Console.WriteLine("++arg is: {0}", ++arg);
        }

        private static void StringTarget(string arg)
        {
            Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
        }
    }
}