using System;
using System.Collections.Generic;

namespace Exercises
{
    public class SecuritySystem
    {
        private List<List<string>> people;

        public SecuritySystem()
        {
            people = new List<List<string>>
            {
                new List<string> { "Paul", "enter" },
                new List<string> { "Jen", "enter" },
                new List<string> { "Paul", "enter" },
                new List<string> { "Curt", "enter" },
                new List<string> { "Mon", "enter" },
                new List<string> { "Mon", "exit" },
                new List<string> { "Jen", "exit" },
                new List<string> { "Paul", "exit" }
            };
            people = new List<List<string>>
            {
                new List<string> { "Paul", "enter" },
                new List<string> { "Jen", "enter" },
                new List<string> { "Paul", "enter" }
            };
        }

        public void CheckEntrance()
        {
            var entranceRegistry = new Dictionary<string, bool>();
            var enterRegistry = new Dictionary<string, bool>();
            var exitRegistry = new Dictionary<string, bool>();
            var peopleWhoExitedWithoutBadge = 0;
            var peopleWhoEnteredWithoutBadge = 0;

            for (var i = 0; i < people.Count; i++)
            {
                var person = people[i][0];
                var action = people[i][1];

                if (action == "enter")
                {
                    var personWasAlreadyIn = entranceRegistry.ContainsKey(person);
                    if (personWasAlreadyIn)
                    {
                        if (!enterRegistry.ContainsKey(person))
                        {
                            peopleWhoExitedWithoutBadge++;
                            enterRegistry.Add(person, true);
                        }
                    }
                    else
                    {
                        entranceRegistry.Add(person, true);
                    }
                }
                else
                {
                    var personWasAlreadyIn = entranceRegistry.ContainsKey(person);
                    if (personWasAlreadyIn)
                    {
                        entranceRegistry.Remove(person);
                    }
                    else
                    {
                        if (!exitRegistry.ContainsKey(person))
                        {
                            peopleWhoEnteredWithoutBadge++;
                            exitRegistry.Add(person, true);
                        }
                    }
                }
            }

            peopleWhoExitedWithoutBadge += entranceRegistry.Count;
        }
    }
}
