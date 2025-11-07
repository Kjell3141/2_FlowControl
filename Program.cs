using System.Text.RegularExpressions;

namespace FlowControlApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            bool quitProgram = false;

            while (!quitProgram)
            {
                ShowMenu();
                string menuSelection = (Console.ReadLine() ?? string.Empty).Trim();
                Console.WriteLine("");

                switch (menuSelection)
                {
                    case "1":
                        int age = GetAge();
                        Console.WriteLine(CinemaPriceRules.GetCinemaPriceAsText(age));
                        Console.WriteLine("\n");
                        break;

                    case "2":
                        int numberOfPersons = GetNumberOfPersons();
                        decimal totalCost = 0;
                        for (int i = 1; i <= numberOfPersons; i++)
                        {
                            totalCost += CinemaPriceRules.GetCinemaPrice(GetAge(i));
                        }
                        Console.WriteLine($"Antal personer i sällskapet: {numberOfPersons}");
                        Console.WriteLine($"Totalkostnad för sällskapet: {totalCost} kr");
                        Console.WriteLine("\n");
                        break;

                    case "3":
                        const int NumberOfTimesToRepeat = 10;
                        Console.Write($"Text som ska visas {NumberOfTimesToRepeat} gånger: ");
                        string text = Console.ReadLine() ?? string.Empty;
                        for (int i = 1; i <= NumberOfTimesToRepeat; i++)
                        {
                            Console.Write($"{i}. {text}{(i != NumberOfTimesToRepeat ? ", " : string.Empty)}");
                        }
                        Console.WriteLine("\n\n");
                        break;

                    case "4":
                        const int SerialNumberOfWordToShow = 3;
                        string[] words = GetWords(SerialNumberOfWordToShow);
                        Console.WriteLine($"Ord nummer {SerialNumberOfWordToShow} är \"{words[SerialNumberOfWordToShow - 1]}\".");
                        Console.WriteLine("\n");
                        break;

                    case "0":
                        quitProgram = true;
                        break;

                    default:
                        Console.WriteLine(menuSelection == string.Empty
                            ? "Vänligen välj ett menyalternativ."
                            : "Felaktigt menyval, vänligen välj menyalternativ på nytt.");
                        Console.WriteLine("\n");
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine($"Huvudmeny\n{new string('-', 9)}\n");
            Console.WriteLine("Välj en siffra för den funktion du önskar testa:");
            Console.WriteLine("1. Pris för biobesök: En person");
            Console.WriteLine("2. Pris för biobesök: Ett sällskap");
            Console.WriteLine("3. Upprepa tio gånger");
            Console.WriteLine("4. Det tredje ordet");
            Console.WriteLine("0. Avsluta programmet");
            Console.WriteLine("");
        }

        private static int GetAge(int serialNumberOfPerson = 0)
        {
            const int ValueMeaningNoSerialNumberOfPerson = 0;
            const int MaxAge = 125;
            int age;
            string ageAsString;
            bool validAge;
            do
            {
                Console.Write(serialNumberOfPerson == ValueMeaningNoSerialNumberOfPerson
                    ? "Biobesökarens ålder: "
                    : $"Ålder på biobesökare nr {serialNumberOfPerson}: ");
                ageAsString = (Console.ReadLine() ?? string.Empty).Trim();
                validAge = int.TryParse(ageAsString, out age) && age >= 0 && age <= MaxAge;
                if (!validAge)
                {
                    Console.WriteLine(
                        ageAsString == string.Empty
                            ? "Vänligen ange ålder."
                            : "Vänligen ange ålder på nytt, uppgiften var felaktig.");
                }
            } while (!validAge);

            return age;
        }

        private static int GetNumberOfPersons()
        {
            const int MaxNumberOfPersons = 500;
            int numberOfPersons;
            string numberOfPersonsAsString;
            bool validNumberOfPersons;
            do
            {
                Console.Write("Antal personer i sällskapet som ska på bio: ");
                numberOfPersonsAsString = (Console.ReadLine() ?? string.Empty).Trim();
                validNumberOfPersons =
                    int.TryParse(numberOfPersonsAsString, out numberOfPersons) &&
                    numberOfPersons >= 0 && numberOfPersons <= MaxNumberOfPersons;
                if (!validNumberOfPersons)
                {
                    Console.WriteLine(
                        numberOfPersonsAsString == string.Empty
                            ? "Vänligen ange antal personer."
                            : "Vänligen ange antal personer på nytt, uppgiften var felaktig.");
                }
            } while (!validNumberOfPersons);

            return numberOfPersons;
        }

        private static string[] GetWords(int minNumberOfWords)
        {
            string[] words;
            bool validSentence;
            do
            {
                Console.Write($"Mening bestående av minst {minNumberOfWords} ord: ");
                string sentence = Console.ReadLine() ?? string.Empty;
                // Byt ut alla enstaka och multipla white space-tecken till ett enstaka
                // mellanslag (och ta bort inledande och avslutande mellanslag).
                sentence = WhiteSpaceCharactersRegex.Replace(sentence, " ").Trim();
                words = sentence.Split(' ');
                int numberOfWords = words.Length;
                if (numberOfWords == 1 && words[0] == string.Empty)
                    numberOfWords = 0;
                validSentence = numberOfWords >= minNumberOfWords;
                if (!validSentence)
                {
                    Console.WriteLine(
                        numberOfWords == 0
                            ? "Vänligen ange en mening."
                            : $"Vänligen ange en längre mening, inte endast {numberOfWords} ord.");
                }
            } while (!validSentence);

            return words;
        }

        [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
        private static partial Regex WhiteSpaceCharactersRegex { get; }
    }
}
