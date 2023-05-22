using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // 1. Aggregate
            int sum = numbers.Aggregate((a, b) => a + b);
            Console.WriteLine(sum); // Output: 55

            int product = numbers.Aggregate((a, b) => a * b);
            Console.WriteLine(product); // Output: 3628800

            // 2. All
            bool allGreaterThanZero = numbers.All(n => n > 0);
            Console.WriteLine(allGreaterThanZero); // Output: True

            bool allEven = numbers.All(n => n % 2 == 0);
            Console.WriteLine(allEven); // Output: False

            // 3. Any
            bool anyGreaterThanFive = numbers.Any(n => n > 5);
            Console.WriteLine(anyGreaterThanFive); // Output: True

            bool anyLessThanZero = numbers.Any(n => n < 0);
            Console.WriteLine(anyLessThanZero); // Output: False

            // 4. Average
            double average = numbers.Average();
            Console.WriteLine(average); // Output: 5.5

            double evenAverage = numbers.Where(n => n % 2 == 0).Average();
            Console.WriteLine(evenAverage); // Output: 6

            // 5. Concat
            int[] moreNumbers = { 11, 12, 13 };
            IEnumerable<int> concatenatedNumbers = numbers.Concat(moreNumbers);
            Console.WriteLine(string.Join(", ", concatenatedNumbers)); // Output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13

            // 6. Contains
            bool containsSeven = numbers.Contains(7);
            Console.WriteLine(containsSeven); // Output: True

            bool containsThirteen = numbers.Contains(13);
            Console.WriteLine(containsThirteen); // Output: False

            // 7. Count
            int count = numbers.Count();
            Console.WriteLine(count); // Output: 10

            int evenCount = numbers.Count(n => n % 2 == 0);
            Console.WriteLine(evenCount); // Output: 5

            // 8. DefaultIfEmpty
            int[] emptyNumbers = { };
            IEnumerable<int> nonEmptyNumbers = emptyNumbers.DefaultIfEmpty(0);
            Console.WriteLine(string.Join(", ", nonEmptyNumbers)); // Output: 0

            IEnumerable<int> nonEmptyNumbers2 = numbers.Concat(emptyNumbers).DefaultIfEmpty(0);
            Console.WriteLine(string.Join(", ", nonEmptyNumbers2)); // Output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10

            // 9. Distinct
            int[] duplicateNumbers = { 1, 2, 3, 2, 1 };
            IEnumerable<int> distinctNumbers = duplicateNumbers.Distinct();
            Console.WriteLine(string.Join(", ", distinctNumbers)); // Output: 1, 2, 3

            // 10. ElementAt
            int thirdNumber = numbers.ElementAt(2);
            Console.WriteLine(thirdNumber); // Output: 3

            // 11. ElementAtOrDefault
            int eleventhNumber = numbers.ElementAtOrDefault(10);
            Console.WriteLine(eleventhNumber); // Output: 0 (default value for int)

            // 12. Except
            int[] exceptNumbers = { 2, 4, 6 };
            IEnumerable<int> exceptResult = numbers.Except(exceptNumbers);
            Console.WriteLine(string.Join(", ", exceptResult)); // Output: 1, 3, 5, 7, 8, 9, 10

            // 13. First
            int firstNumber = numbers.First();
            Console.WriteLine(firstNumber); // Output: 1

            int firstEvenNumber = numbers.First(n => n % 2 == 0);
            Console.WriteLine(firstEvenNumber); // Output: 2

            // 14. FirstOrDefault
            int firstNegativeNumber = numbers.FirstOrDefault(n => n < 0);
            Console.WriteLine(firstNegativeNumber); // Output: 0 (default value for int)

            // 15. GroupBy
            string[] fruits = { "apple", "banana", "cherry", "date", "elderberry", "fig" };
            var fruitGroups = fruits.GroupBy(f => f.Length);
            foreach (var group in fruitGroups)
            {
                Console.WriteLine($"Words with {group.Key} letters:");
                foreach (var word in group)
                {
                    Console.WriteLine($"  {word}");
                }
            }
            // Output:
            // Words with 5 letters:
            //   apple
            //   fig
            // Words with 6 letters:
            //   banana
            //   cherry
            // Words with 4 letters:
            //   date
            // Words with 10 letters:
            //   elderberry

            // 16. Intersect
            int[] intersectNumbers = { 2, 4, 6 };
            IEnumerable<int> intersectResult = numbers.Intersect(intersectNumbers);
            Console.WriteLine(string.Join(", ", intersectResult)); // Output: 2, 4, 6

            // 17. Join

            string[] fruits22 = { "apple", "banana", "cherry", "date" };
            string[] colors = { "red", "yellow", "red", "brown" };
            var joined = fruits22.GroupJoin(colors, f => f, c => c, (f, cs) => new { Fruit = f, Colors = cs });
            foreach (var result in joined)
            {
                Console.WriteLine("{0}: {1}", result.Fruit, string.Join(", ", result.Colors));
            }


            // Output:
            // John lives in New York
            // Mary lives in New York
            // Bob lives in New York

            // 18. Last
            int lastNumber = numbers.Last();
            Console.WriteLine(lastNumber); // Output: 10

            int lastEvenNumber = numbers.Last(n => n % 2 == 0);
            Console.WriteLine(lastEvenNumber); // Output: 10

            // 19. LastOrDefault
            int lastNegativeNumber = numbers.LastOrDefault(n => n < 0);
            Console.WriteLine(lastNegativeNumber); // Output: 0 (default value for int)

            // 20. Max
            int maxNumber = numbers.Max();
            Console.WriteLine(maxNumber); // Output: 10

            int evenMax = numbers.Where(n => n % 2 == 0).Max();
            Console.WriteLine(evenMax); // Output: 10

            // 21. Min
            int minNumber = numbers.Min();
            Console.WriteLine(minNumber); // Output: 1

            int evenMin = numbers.Where(n => n % 2 == 0).Min();
            Console.WriteLine(evenMin); // Output: 2

            // 22. OfType
            object[] mixedObjects = { 1, "two", 3.0, "four", 5 };
            IEnumerable<int> integers = mixedObjects.OfType<int>();
            Console.WriteLine(string.Join(", ", integers)); // Output: 1, 5

            // 23. OrderBy
            string[] names = { "bob", "alice", "charlie" };
            var orderedNames = names.OrderBy(n => n.Length);
            Console.WriteLine(string.Join(", ", orderedNames)); // Output: bob, alice, charlie

            // 24. Reverse
            IEnumerable<int> reversedNumbers = numbers.Reverse();
            Console.WriteLine(string.Join(", ", reversedNumbers)); // Output: 10, 9, 8, 7, 6, 5, 4, 3, 2, 1

            // 25. Select
            IEnumerable<double> squares = numbers.Select(n => Math.Pow(n, 2));
            Console.WriteLine(string.Join(", ", squares)); // Output: 1, 4, 9, 16, 25, 36, 49, 64, 81, 100

            // 26. SelectMany
            string[] words = { "hello", "world", "how", "are", "you" };
            IEnumerable<char> letters = words.SelectMany(w => w);
            Console.WriteLine(string.Join(", ", letters)); // Output: h, e, l, l, o, w, o, r, l, d, h, o, w, a, r, e, y, o, u

            // 27. Single
            int onlyNumber = new[] { 1 }.Single();
            Console.WriteLine(onlyNumber); // Output: 1

            int onlyEvenNumber = numbers.Where(n => n % 2 == 0).Single();
            Console.WriteLine(onlyEvenNumber); // Output: InvalidOperationException

            // 28. SingleOrDefault
            int singleNegativeNumber = numbers.SingleOrDefault(n => n < 0);
            Console.WriteLine(singleNegativeNumber); // Output: 0 (default value for int)

            // 29. Skip
            IEnumerable<int> skippedNumbers = numbers.Skip(5);
            Console.WriteLine(string.Join(", ", skippedNumbers)); // Output: 6, 7, 8, 9, 10

            // 30. SkipWhile
            IEnumerable<int> skippedWhileLessThanSix = numbers.SkipWhile(n => n < 6);
            Console.WriteLine(string.Join(", ", skippedWhileLessThanSix)); // Output: 6, 7, 8, 9, 10

            // 31. Sum
            int sum2 = numbers.Sum();
            Console.WriteLine(sum2); // Output: 55

            int evenSum = numbers.Where(n => n % 2 == 0).Sum();
            Console.WriteLine(evenSum); // Output: 30

            // 32. Take
            IEnumerable<int> firstFiveNumbers = numbers.Take(5);
            Console.WriteLine(string.Join(", ", firstFiveNumbers)); // Output: 1, 2, 3, 4, 5

            // 33. TakeWhile
            IEnumerable<int> firstNumbersLessThanSix = numbers.TakeWhile(n => n < 6);
            Console.WriteLine(string.Join(", ", firstNumbersLessThanSix)); // Output: 1, 2, 3, 4, 5

            // 34. ThenBy
            string[] names2 = { "bob", "alice", "charlie", "david", "eve", "frank" };
            var orderedNames2 = names2.OrderBy(n => n.Length).ThenBy(n => n);
            Console.WriteLine(string.Join(", ", orderedNames2)); // Output: bob, eve, alice, frank, david, charlie

            // 35. ToArray
            int[] numbersArray = numbers.ToArray();
            Console.WriteLine(string.Join(", ", numbersArray)); // Output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10

            // 36. ToDictionary
            var fruits2 = new[]
            {
                new { Name = "Apple", Color = "Red" },
                new { Name = "Banana", Color = "Yellow" },
                new { Name = "Cherry", Color = "Red" }
            };

            var fruitsDictionary = fruits2.ToDictionary(f => f.Name, f => f.Color);
            foreach (var kvp in fruitsDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                // Output:
                // Apple: Red
                // Banana: Yellow
                // Cherry: Red

                // 37. ToList
                List<int> numbersList = numbers.ToList();
                Console.WriteLine(string.Join(", ", numbersList)); // Output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10

                // 38. Union
                int[] moreNumbers2 = { 5, 6, 7, 8, 9 };
                IEnumerable<int> unionResult = numbers.Union(moreNumbers2);
                Console.WriteLine(string.Join(", ", unionResult)); // Output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10

                // 39. Where
                IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0);
                Console.WriteLine(string.Join(", ", evenNumbers)); // Output: 2, 4, 6, 8, 10

                IEnumerable<int> oddNumbersGreaterThanFive = numbers.Where(n => n % 2 == 1 && n > 5);
                Console.WriteLine(string.Join(", ", oddNumbersGreaterThanFive)); // Output: 7, 9

                // 40. Zip
                int[] moreNumbers3 = { 2, 4, 6, 8, 10 };
                IEnumerable<int> zippedNumbers = numbers.Zip(moreNumbers3, (n1, n2) => n1 + n2);
                Console.WriteLine(string.Join(", ", zippedNumbers)); // Output: 3, 6, 9, 12, 15

                // 41. GroupJoin
                var persons2 = new[]
                {
                new { Name = "John", Age = 25 },
                new { Name = "Mary", Age = 30 },
                new { Name = "Bob", Age = 25 }
            };

                var cities2 = new[]
                {
                new { Name = "New York", Population = 8405837 },
                new { Name = "Los Angeles", Population = 3990456 },
                new { Name = "Chicago", Population = 2705994 }
            };

                var groupedData = cities2.GroupJoin(persons2, c => c.Population, p => p.Age,
                    (c, p) => new { City = c.Name, Population = c.Population, Persons = p.Select(x => x.Name) });

                foreach (var city in groupedData)
                {
                    Console.WriteLine($"City: {city.City}, Population: {city.Population}");
                    Console.WriteLine("Persons:");
                    foreach (var person in city.Persons)
                    {
                        Console.WriteLine("  " + person);
                    }
                }

                // Output:
                // City: New York, Population: 8405837
                // Persons:
                //   John
                //   Bob
                // City: Los Angeles, Population: 3990456
                // Persons:
                // City: Chicago, Population: 2705994
                // Persons:
                //   Mary

                // 42. ToLookup
                var personsLookup = persons2.ToLookup(p => p.Age);
                foreach (var group in personsLookup)
                {
                    Console.WriteLine($"Age: {group.Key}");
                    foreach (var person in group)
                    {
                        Console.WriteLine($"  {person.Name}");
                    }
                }

                // Output:
                // Age: 25
                //   John
                //   Bob
                // Age: 30
                //   Mary

                // 43. DefaultIfEmpty
                int[] emptyNumbers2 = { };
                IEnumerable<int> defaultNumbers = emptyNumbers2.DefaultIfEmpty(0);
                Console.WriteLine(string.Join(", ", defaultNumbers)); // Output: 0

                IEnumerable<int> defaultNumbers2 = numbers.Where(n => n > 10).DefaultIfEmpty(0);
                Console.WriteLine(string.Join(", ", defaultNumbers2)); // Output: 0

                // 44. Except
                int[] moreNumbers4 = { 5, 6, 7, 8, 9 };
                IEnumerable<int> exceptResult2 = numbers.Except(moreNumbers4);
                Console.WriteLine(string.Join(", ", exceptResult2)); // Output: 1, 2, 3, 4

                // 45. Intersect
                IEnumerable<int> intersectResult2 = numbers.Intersect(moreNumbers2);
                Console.WriteLine(string.Join(", ", intersectResult2)); // Output: 5, 6, 7, 8, 9


                // 43. DefaultIfEmpty
                int[] emptyNumbers3 = { };
                IEnumerable<int> defaultNumbers3 = emptyNumbers3.DefaultIfEmpty(0);
                Console.WriteLine(string.Join(", ", defaultNumbers)); // Output: 0

                IEnumerable<int> defaultNumbers4 = numbers.Where(n => n > 10).DefaultIfEmpty(0);
                Console.WriteLine(string.Join(", ", defaultNumbers2)); // Output: 0

                // 44. Except
                int[] moreNumbers5 = { 5, 6, 7, 8, 9 };
                IEnumerable<int> exceptResult4 = numbers.Except(moreNumbers5);
                Console.WriteLine(string.Join(", ", exceptResult4)); // Output: 1, 2, 3, 4

                // 45. Intersect
                IEnumerable<int> intersectResult4 = numbers.Intersect(moreNumbers5);
                Console.WriteLine(string.Join(", ", intersectResult4)); // Output: 5, 6, 7, 8, 9

                // 43. DefaultIfEmpty
                int[] emptyNumbers4 = { };
                IEnumerable<int> defaultNumbers6 = emptyNumbers4.DefaultIfEmpty(0);
                Console.WriteLine(string.Join(", ", defaultNumbers6)); // Output: 0

                IEnumerable<int> defaultNumbers5 = numbers.Where(n => n > 10).DefaultIfEmpty(0);
                Console.WriteLine(string.Join(", ", defaultNumbers5)); // Output: 0

                // 44. Except
                int[] moreNumbers6 = { 5, 6, 7, 8, 9 };
                IEnumerable<int> exceptResult7 = numbers.Except(moreNumbers6);
                Console.WriteLine(string.Join(", ", exceptResult7)); // Output: 1, 2, 3, 4

                // 45. Intersect
                IEnumerable<int> intersectResult6 = numbers.Intersect(moreNumbers6);
                Console.WriteLine(string.Join(", ", intersectResult6)); // Output: 5, 6, 7, 8, 9

                // 46.OfType
                object[] objects = { 1, "Hello", 2.5, "World", true };
                IEnumerable<string> strings = objects.OfType<string>();
                Console.WriteLine(string.Join(", ", strings)); // Output: Hello, World

                // 47. Reverse
                IEnumerable<int> reversedNumbers2 = numbers.Reverse();
                Console.WriteLine(string.Join(", ", reversedNumbers2)); // Output: 10, 9, 8, 7, 6, 5, 4, 3, 2, 1

                // 48. SequenceEqual
                int[] numbersCopy = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                bool areEqual = numbers.SequenceEqual(numbersCopy);
                Console.WriteLine(areEqual); // Output: True

                // 49. ToHashSet
                var fruits3 = new[]
                {
                    new { Name = "Apple", Color = "Red" },
                    new { Name = "Banana", Color = "Yellow" },
                    new { Name = "Cherry", Color = "Red" }
                };

                var fruitsHashSet = fruits3.ToHashSet();
                Console.WriteLine(string.Join(", ", fruitsHashSet.Select(f => f.Name))); // Output: Apple, Banana, Cherry

            }
        }
    }
}