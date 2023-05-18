namespace Ordgåter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] list = CreateWordList();
            int i = 1;
            do
            {
                string randomWord = list[RandomWordIndexMethod(list)];
                string lastThreeLetters = randomWord.Substring(randomWord.Length - 3);

                string similarWord = list.FirstOrDefault(w => w.Substring(0, 3) == lastThreeLetters) ?? "No words ends with this";
                Console.WriteLine($"{randomWord} -> {similarWord}");
                i++;
            } while (i < 200);

            Console.ReadLine();
        }

        private static int RandomWordIndexMethod(string[] list)
        {
            Random random = new Random();
            int randomWordIndex = random.Next(0, list.Length);
            return randomWordIndex;
        }

        static string[] CreateWordList()
        {
            var namesArray = new List<string>();
            string filePath = @"C:\Users\Thomim\OneDrive\Get academy koding\tema_3\uke_3\Ordgåter\ordliste.txt";
            string sep = "\t";
            int size = 20000;
            string[] ordArray2 = File.ReadAllLines(filePath);

            foreach (var line in ordArray2)
            {
                string[] words = line.Split(sep);
                if (namesArray.Count < size)
                {
                    if (words[1].Length is > 6 and < 11 && !namesArray.Contains(words[1]) && !words[1].Contains(' ') &&
                    !words[1].Contains('-'))
                    {
                        namesArray.Add(words[1]);
                    }
                }
                else
                {
                    break;
                }
            }

            return namesArray.ToArray();

        }
    }
}


