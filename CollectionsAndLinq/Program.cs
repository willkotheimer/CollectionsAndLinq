using System;
using System.Collections.Generic;

namespace CollectionsAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // anything with angle brackets after the type name is a generic type
            // List<T> Generic List
            // Pronounced List of T
            var teachers = new List<string>() { "Nathan", "Jameka", "Dylan" }; // closing of a generic

            var e13 = new List<string>();

            e13.Add("Rob");
            e13.Add("Ryan");
            e13.Add("Bailey");
            e13.Add("Wanda");
            e13.Add("Hunter");
            e13.AddRange(teachers);

            //gets enumerator for a type (give me a copy of an iterator for e13)
            foreach(var student in e13)
            {
                // changes the underlying collection ... unsupported operation:
                //  e13.Add("asdf"); //unsupported operation exception
               /* if (student == "Hunter")
                {
                    e13.Remove("Hunter"); //unsupported operation exception
                }*/

            }

            e13.ForEach(name =>
            {
                Console.WriteLine(name);
            });

            e13.ForEach(Console.WriteLine);

            if(e13.Remove("Wanda"))
            {
                Console.WriteLine("Bye Wanda.");
            };

            //Dictionary<TKey, TValue>
            // Arity (`2) -> how many generic type parameters a type has. Dictionary`2 
            //Dictionaries are good at information retrieval quickly.
            //Very fast information retrieval
            //Slower information storage

            // Good for infrequently updated but often read data
            // Good for loading information at startup.

            // the first parameter is the type for the key, the second is the type for the value
            var words = new Dictionary<string, string>()
            {
                {"soup","a thing that's wet and we eat it" },
                {"cake", "a thing that I don't have right now, but want." }
            };

            words.Add("Arity", "how many generic type parameters a type has");

            words["Arity"] = "A thing Nathan made up";

            if(!words.TryAdd("Arity", "Something"))
            {
                words["Arity"] = "another definition";
            };

            words.Remove("cake");

            foreach(var word in words)
            {
                Console.WriteLine($"{word.Key} means {word.Value}");
            }

            foreach (var (word, definition) in words)
            {
                Console.WriteLine($"{word} means {definition}");
            }

            // Can use a sentence for a string

            // can use a list inside a dictionary
            var complicatedDictionary = new Dictionary<string, List<string>>();

            complicatedDictionary.Add("soup", new List<string>());
            var soupDefinitions = complicatedDictionary["soup"];
            soupDefinitions.Add("This is the definition of soup");
            complicatedDictionary.Add("Arity", new List<string> { "A definition for Arity" });

            foreach(var (word, definitions) in complicatedDictionary)
            {
                foreach(var definition in definitions)
                {
                    Console.WriteLine($"\t{definition}");
                }
            }

            // Hashsets, Queues, and Stacks

            //Hashset<T>
            //Really fast retrieval, no keys
            //Enforces uniqueness but doesn't cause errors for things not unique.
            // Good for: looping, deduplication
            //Good for: when you only want at most one copy of a thing
            // slow for information storage

            var unique = new HashSet<String>();
            unique.Add("Nathan");
            // these are ignored:
            unique.Add("Nathan");
            unique.Add("Nathan");
            unique.Add("Nathan");

            // Will take in a whole collection and remove duplicates
            var unique2 = new HashSet<string>(e13);

            // Queue<T> - FIFO
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(12);
            queue.Enqueue(3);
            queue.Enqueue(1);
            while(queue.Count> 0)
            {
                Console.WriteLine($"currently dequeing: {queue.Dequeue()}");
            }


            //Stack<T> - LIFO

            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(12);
            stack.Push(3);
            stack.Push(1);
            while (stack.Count > 0)
            {
                Console.WriteLine($"currently popping: {stack.Pop()}");
            }




            var a1 = new A<int>();
            var a2 = new A<string>();

            a1.DoStuff(123);
            a2.DoStuff("other stuff");

            
        }
    }

    class A<T>
    {
        public void DoStuff(T thingToDo)
        {
            Console.WriteLine($"stuff {thingToDo}");
        }
    }
}
