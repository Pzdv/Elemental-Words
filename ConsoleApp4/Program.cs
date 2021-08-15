// Preloaded for you:
// Dictionary<string, string> ELEMENTS
// e.g. ELEMENTS["H"] == "Hydrogen"

using static Preloaded.Elements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{

    public class ElementalWords
    {
        private static List<string[]> AllElementalForm = new List<string[]>();
        private static List<string> ElementalForm = new List<string>();
        private static string TryFindInElements(string subString)
        {
            return ELEMENTS.ContainsKey(subString) ? ELEMENTS[subString] : string.Empty;
        }
        private static void FindForm(string word)
        {
            if (word.Length == 0)
            {
                AllElementalForm.Add((string[])ElementalForm.ToArray().Clone());
                ElementalForm.RemoveAt(ElementalForm.Count - 1);
                return;
            }

            for (int j = 1; j < 4 && j <= word.Length; j++)
            {

                var subString = word.Substring(0, j);
                subString = string.Join("", subString.Select(x => subString.IndexOf(x) == 0 ? x.ToString().ToUpper() : x.ToString().ToLower()));
                var Element = TryFindInElements(subString);
                if (Element == string.Empty)
                {
                    continue;
                }
                else
                {
                    ElementalForm.Add($"{Element} ({subString})");
                    FindForm(word.Remove(0, j));
                }
            }
            if (ElementalForm.Count != 0)
                ElementalForm.RemoveAt(ElementalForm.Count - 1);
        }
        public static string[][] ElementalForms(string word)
        {
            if (word.Length == 0) return new string[0][];
            FindForm(word);
            var result = (string[][])AllElementalForm.ToArray().Clone();
            AllElementalForm.Clear();
            return result;
        }
    }
}