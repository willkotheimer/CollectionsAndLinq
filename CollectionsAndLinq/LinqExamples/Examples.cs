using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionsAndLinq.LinqExamples
{
    class Examples
    {
        public void Run()
        {
            // new list of whole numbers
            var numbers = new List<int> { 12, 15, 400, 12, 1, 3208, 400, 19 };
            var badNumbers = new List<int> { 9, 13, 19, 55, 635 };

            //where is like array.filter, returns a new collection of IEnumerable<T>
            var bigNumbers = numbers.Where(number => number > 27);

            //Select is like Array.map , returns a new collection of IEnumerable<T>
            //transforming data , via a passed in function I want to apply

            var biggerNumbers = numbers.Select(number => number + 27);

            var biggestNumber = numbers.Max();

            //the first
            var firstNumber = numbers.First();

            //first number greater than 12
            // var firstMatchingNumber = numbers.Where(number =>number > 12).First()
            var firstGreater12 = numbers.First(numbers => numbers > 12);

            //contains specific expression -> returns boolean
            var hasReallyBigNumbers = numbers.Any(x => x > 10000);

            //complex reference types and linq
            var animals = new List<Animal>
        { //collection initilizer
            new Animal {Type = "Giraffe", HeightInInches= 204, WeightInPounds=1800},
            new Animal {Type = "Tiger", HeightInInches = 40, WeightInPounds= 500},
            new Animal { Type = "Frog", HeightInInches = 3, WeightInPounds = 1},
            new Animal {Type = "Gorilla", HeightInInches = 63, WeightInPounds=3500 }
        };
            //filter data

            var animalsThatStartWithG = animals.Where(animal => animal.Type.StartsWith('G'));

            // transformation

            // deferred execution: as iEnumerable is enumerated, or materialized, the filter happens but not until, so its not 
            // working below until the foreach line:

            var animalDescriptions = animals
                .Select(animal => $"A {animal.Type} is {animal.HeightInInches} inches tall and weighs {animal.WeightInPounds} lbs");

            foreach(var description in animalDescriptions)
            {
                Console.WriteLine(description);
            }

            // to get it to give the whole list, add .toList() to the end of above

            //group a collection by a given key
            var groupAnimals = animals.GroupBy(animal => animal.Type.First());

            foreach(var animalgroup in groupAnimals)
            {
                Console.WriteLine($"Animals that start with {animalgroup.Key}");

                foreach(var animal in animalgroup)
                {
                    Console.WriteLine(animal.Type);
                }
            }

            //group and transform
            var groupAnimalNames = animals.GroupBy(animal => animal.Type.First(), animal => animal.Type);

            foreach (var animalgroup in groupAnimalNames)
            {
                Console.WriteLine($"Animals that start with {animalgroup.Key}");

                foreach (var name in animalgroup)
                {
                    Console.WriteLine(name);
                }
            }

            var filteredAndTransformedAnimals = animals
                .Where(animal => animal.HeightInInches > 20)
                .Select(animal => animal.Type);

            var firstThreeNumbersAndTheSixth = numbers.Take(3).Concat(numbers.Skip(5).Take(1));

            var onlyGoodNumbers = numbers.Except(badNumbers);

            var uniqueNumbers = numbers.Distinct(); //no duplicates



        }
    }
}
