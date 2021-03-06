﻿using System;

namespace NullableValueTypes
{

    class DatabaseReader
    {
        // Nullable data field
        public int? numericValue = null;
        public bool? boolValue = true;

        // Note the nullable return type
        public int? GetIntFromDatabase()
        {
            return numericValue;
        }

        // Not the nullable return type
        public bool? GetBoolFromDatabase() => boolValue;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Compiler errors!
            // Values types cannot be set to null!
            // bool myBool = null;
            // int myInt = null;
            Console.WriteLine("***** Fun with Nullable Value Types *****\n");
            DatabaseReader dr = new DatabaseReader();

            // Get int from "database".
            int? i = dr.GetIntFromDatabase();
            if (i.HasValue)
            {
                Console.WriteLine("Value of 'i' is: {0}", i);
            }
            else
            {
                Console.WriteLine("Value of 'i' is undefined.");
            }

            // Get bool from "database".
            bool? b = dr.GetBoolFromDatabase();
            if (b != null)
            {
                Console.WriteLine("Value of 'b' is: {0}", b.Value);
            }
            else
            {
                Console.WriteLine("Value of 'b' is undefined.");
            }

            // If the value from GetIntFromDatabase() is null,
            // assign local variable to 100
            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);

            //Null-coalescing assignment operator
            int? nullableInt = null;
            nullableInt ??= 12;
            nullableInt ??= 14;
            Console.WriteLine(nullableInt);



            Console.ReadLine();
        }

        static void TesterMethodBefore(string[] args)
        {
            // We should check for null before accessing the array data!
            if (args != null)
            {
                Console.WriteLine($"You sent me {args.Length} arguments.");
            }
        }

        static void TesterMethod(string[] args)
        {
            // We should check for null before accessing the array data!
            Console.WriteLine($"You sent me {args?.Length ?? 0} arguments.");
        }

#pragma warning disable
        static void LocalNullableVariables()
        {
            // Define some local nullable variables.
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];
        }

#pragma warning disable
        static void LocalNullableVariablesUsingNullable()
        {
            // Define some local nullable types using Nullable<T>.
            Nullable<int> nullableInt = 10;
            Nullable<double> nullableDouble = 3.14;
            Nullable<bool> nullableBool = null;
            Nullable<char> nullableChar = 'a';
            Nullable<int>[] arrayOfNullableInts = new Nullable<int>[10];
        }
    }
}
