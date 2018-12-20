using System;
using System.Collections.Generic;
using System.Text;

namespace Allergies
{
    class AllergicPerson
    {
        private string name;
        private int score;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public bool IsAlergic
        {
            get
            {
                if (score > 0)
                {
                    if (score > 255)
                    {
                        Console.WriteLine("Warning!: There are unidentified allergies due to out of test scope");
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public AllergicPerson(string name, int score)
        {
            this.name = name;
            this.score = score;
            GetNameAlergiesList(score);
        }

        private List<string> GetNameAlergiesList(int score)
        {
            Dictionary<string, int> allergyMarks = new Dictionary<string, int>();

            allergyMarks.Add("eggs", 1);
            allergyMarks.Add("peanuts", 2);
            allergyMarks.Add("shellfish", 4);
            allergyMarks.Add("strawberries", 8);
            allergyMarks.Add("tomatoes", 16);
            allergyMarks.Add("chocolate", 32);
            allergyMarks.Add("pollen", 64);
            allergyMarks.Add("cats", 128);

            List<string> nameAlergiesList = new List<string>();
            var marks = GetItems(score);
            foreach (var allergyMark in allergyMarks)
            {
                foreach (var item in marks)
                    if (allergyMark.Value == (int)item)
                    {
                        nameAlergiesList.Add(allergyMark.Key);
                    }
            }
            Console.WriteLine($"\n{this.name} is allergic at:\n");
            foreach (var allergy in nameAlergiesList)
            {
                Console.WriteLine($"{allergy.ToUpper()}");
            }
            return nameAlergiesList;
        }

        static List<double> GetItems(int score)
        {
            List<double> marksList = new List<double>();

            string result;

            result = "";
            while (score > 1)
            {
                int remainder = score % 2;
                result = " " + Convert.ToString(remainder) + result;
                score /= 2;
            }
            result = Convert.ToString(score) + result;
            //Console.WriteLine("{0} ", result);
            var markArray = result.Split(" ");

            for (int i = 0; i < markArray.Length; i++)
            {
                // Console.WriteLine(markArray[i]);
                if (markArray[i] == "1")
                {
                    marksList.Add(Math.Pow(2, markArray.Length - i - 1));
                }
            }
            //Console.WriteLine($"The identified allergy scores are:");
            //foreach (var ex in marksList)
            //{
            //    Console.Write($"{ex} ");
            //}
            //Console.WriteLine();
            return marksList;
        }
        public override string ToString()
        {
            if (IsAlergic)
            {
                return $"{name} is a person with allergies.\n";
            }
            else
            {
                return $"{name} is a person with no allergies.\n";
            }
        }
    }
}


