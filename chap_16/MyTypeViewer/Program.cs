﻿using System;
using System.Linq;
using System.Reflection;

namespace MyTypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            string typeName = string.Empty;
            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                Console.Write("or enter Q to quit: ");
                // Get name of type.
                typeName = Console.ReadLine();
                // Does user want to quit?
                if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                try
                {
                    Type t = Type.GetType(typeName);
                    if (t == null && typeName.Equals("System.Console", StringComparison.OrdinalIgnoreCase))
                    {
                        t = typeof(System.Console);
                    }
                    Console.WriteLine();
                    ListVariousStats(t);
                    ListFields(t);
                    ListProps(t);
                    ListMethods(t);
                    ListInterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find type");
                }
            } while (true);
        }

        // Display method names of type.
        static void ListMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            // var methodNames = from n in t.GetMethods() select n.Name;
            // foreach (var name in methodNames)
            // {
            //     Console.WriteLine("->{0}", name);
            // }
            // Console.WriteLine();
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                // Get return type
                string retVal = m.ReturnType.FullName;
                string paramInfo = "( ";
                foreach (var pi in m.GetParameters())
                {
                    paramInfo += string.Format("{0} {1} ", pi.ParameterType, pi.Name);
                }
                paramInfo += " )";

                // Now display the basic method sig
                Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo);
            }
            Console.WriteLine();
        }

        // Display field names of type.
        static void ListFields(Type t)
        {
            Console.WriteLine("***** Fields *****");
            var fieldNames = t.GetFields().Select(f => f.Name);
            foreach (var name in fieldNames)
            {
                Console.WriteLine("->{0}", name);
            }
            Console.WriteLine();
        }

        // Display property names of type.
        static void ListProps(Type t)
        {
            Console.WriteLine("***** Properties *****");
            var propNames = t.GetProperties().Select(p => p.Name);
            foreach (var name in propNames)
            {
                Console.WriteLine("->{0}", name);
            }
            Console.WriteLine();
        }

        // Display implemented interfaces.
        static void ListInterfaces(Type t)
        {
            Console.WriteLine("***** Interfaces *****");
            var ifaces = t.GetInterfaces();
            foreach (var i in ifaces)
            {
                Console.WriteLine("->{0}", i.Name);
            }
        }

        // Just for good measure.
        static void ListVariousStats(Type t)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine($"Base class is: {t.BaseType}");
            Console.WriteLine($"Is type abstract? {t.IsAbstract}");
            Console.WriteLine($"Is type sealed? {t.IsSealed}");
            Console.WriteLine($"Is type generic? {t.IsGenericTypeDefinition}");
            Console.WriteLine($"Is type a class type? {t.IsClass}");
            Console.WriteLine();
        }

    }
}
