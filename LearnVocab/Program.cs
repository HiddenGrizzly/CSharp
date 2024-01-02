using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Vocabulary> vocabularies = new List<Vocabulary>();
    static int maxLearnWords = 5;
    static int minRepetition = 3;
    static int memorizationScore = 100;
    static int maxForgetDays = 2;

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            DisplayMenu();

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        ManageVocabularies();
                        break;
                    case 2:
                        LearnVocabularies();
                        break;
                    case 3:
                        EvaluateResults();
                        break;
                    case 4:
                        ConfigureOptions();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("=========== FPT-Rewise ===========");
        Console.WriteLine("1. Manage vocabularies");
        Console.WriteLine("2. Learn vocabularies");
        Console.WriteLine("3. Evaluate results");
        Console.WriteLine("4. Configure options");
        Console.WriteLine("0. Exit");
        Console.Write("Select option: ");
    }

    static void ManageVocabularies()
    {
        bool backToMenu = false;

        while (!backToMenu)
        {
            Console.WriteLine("======= Manage Vocabularies =======");
            Console.WriteLine("1. Add word");
            Console.WriteLine("2. Edit word");
            Console.WriteLine("3. Delete word");
            Console.WriteLine("4. List all words");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select option: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddWord();
                        break;
                    case 2:
                        EditWord();
                        break;
                    case 3:
                        DeleteWord();
                        break;
                    case 4:
                        ListWords();
                        break;
                    case 0:
                        backToMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void AddWord()
    {
        Console.Write("Enter the word: ");
        string key = Console.ReadLine();
        Console.Write("Enter the description: ");
        string description = Console.ReadLine();

        Console.Write("Do you want to save this word? (Y/N): ");
        if (Console.ReadLine().ToUpper() == "Y")
        {
            vocabularies.Add(new Vocabulary(key, description));
            Console.WriteLine("Word added successfully!");
        }

        Console.Write("Do you want to add another word? (Y/N): ");
        if (Console.ReadLine().ToUpper() != "Y")
        {
            return;
        }
    }

    static void EditWord()
    {
        Console.Write("Enter the word you want to edit: ");
        string keyToEdit = Console.ReadLine();

        Vocabulary vocabularyToEdit = vocabularies.FirstOrDefault(v => v.Key == keyToEdit);

        if (vocabularyToEdit != null)
        {
            Console.Write($"Enter new word (current: {vocabularyToEdit.Key}): ");
            string newKey = Console.ReadLine();
            Console.Write($"Enter new description (current: {vocabularyToEdit.Description}): ");
            string newDescription = Console.ReadLine();

            Console.Write("Do you want to update this word? (Y/N): ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                vocabularyToEdit.Key = newKey;
                vocabularyToEdit.Description = newDescription;
                Console.WriteLine("Word updated successfully!");
            }
        }
        else
        {
            Console.WriteLine($"Word '{keyToEdit}' not found.");
        }
    }

    static void DeleteWord()
    {
        Console.Write("Enter the word you want to delete: ");
        string keyToDelete = Console.ReadLine();

        Vocabulary vocabularyToDelete = vocabularies.FirstOrDefault(v => v.Key == keyToDelete);

        if (vocabularyToDelete != null)
        {
            Console.Write($"Are you sure you want to delete the word '{keyToDelete}'? (Y/N): ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                vocabularies.Remove(vocabularyToDelete);
                Console.WriteLine("Word deleted successfully!");
            }
        }
        else
        {
            Console.WriteLine($"Word '{keyToDelete}' not found.");
        }
    }

    static void ListWords()
    {
        if (vocabularies.Count == 0)
        {
            Console.WriteLine("No words available.");
        }
        else
        {
            Console.WriteLine("======= List of Words =======");
            foreach (var vocabulary in vocabularies)
            {
                Console.WriteLine($"Key: {vocabulary.Key}, Description: {vocabulary.Description}");
            }
        }
    }

    static void LearnVocabularies()
    {
        Console.WriteLine("======= Learn Vocabularies =======");

        if (vocabularies.Count == 0)
        {
            Console.WriteLine("No words available for learning. Please add words first.");
            return;
        }

        Random random = new Random();

        int wordsToLearn = Math.Min(vocabularies.Count, maxLearnWords);

        for (int i = 0; i < wordsToLearn; i++)
        {
            Vocabulary randomVocabulary = vocabularies[random.Next(vocabularies.Count)];

            Console.WriteLine($"Q: {randomVocabulary.Description}");
            Console.Write("A: ");
            string userAnswer = Console.ReadLine();

            Console.WriteLine($"*A: {randomVocabulary.Key}");

            Console.Write("Rate your memorization (1..6): ");
            int memorizationLevel;
            if (int.TryParse(Console.ReadLine(), out memorizationLevel) && memorizationLevel >= 1 && memorizationLevel <= 6)
            {
                // Update statistics based on memorization level
                UpdateStatistics(memorizationLevel, randomVocabulary);
            }
            else
            {
                Console.WriteLine("Invalid input. Memorization level should be between 1 and 6.");
            }
        }

        Console.WriteLine("Congratulations! You have completed your learning session.");
        Console.Write("Do you want to continue learning? (Y/N): ");
        if (Console.ReadLine().ToUpper() != "Y")
        {
            return;
        }
    }

    static void UpdateStatistics(int memorizationLevel, Vocabulary vocabulary)
    {
        // Update statistics based on memorization level
        if (memorizationLevel >= memorizationScore)
        {
            // Memorized well
            Console.WriteLine("Memorized well!");
            vocabulary.Remember();
        }
        else
        {
            // Need more practice
            Console.WriteLine("Need more practice!");
            vocabulary.Forget();
        }
    }

    static void EvaluateResults()
    {
        Console.WriteLine("======= Evaluate Results =======");

        int notReviewedCount = vocabularies.Count(v => !v.Reviewed);
        int memorizedCount = vocabularies.Count(v => v.Memorized);
        int averageMemorization = memorizedCount > 0 ? memorizedCount / vocabularies.Count : 0;

        Console.WriteLine($"Words not reviewed: {notReviewedCount}");
        Console.WriteLine($"Words memorized: {memorizedCount}");
        Console.WriteLine($"Average memorization: {averageMemorization}");
    }

    static void ConfigureOptions()
    {
        Console.WriteLine("======= Configure Options =======");

        Console.Write($"Maximum words to learn per session ({maxLearnWords}..10): ");
        int newMaxLearnWords;
        if (int.TryParse(Console.ReadLine(), out newMaxLearnWords) && newMaxLearnWords >= 2 && newMaxLearnWords <= 10)
        {
            maxLearnWords = newMaxLearnWords;
        }
        else
        {
            Console.WriteLine("Invalid input. Maximum words to learn should be between 2 and 10.");
        }

        Console.Write($"Minimum repetition of a word ({minRepetition}..10): ");
        int newMinRepetition;
        if (int.TryParse(Console.ReadLine(), out newMinRepetition) && newMinRepetition >= 3 && newMinRepetition <= 10)
        {
            minRepetition = newMinRepetition;
        }
        else
        {
            Console.WriteLine("Invalid input. Minimum repetition should be between 3 and 10.");
        }

        Console.Write($"Memorization score ({memorizationScore}..500): ");
        int newMemorizationScore;
        if (int.TryParse(Console.ReadLine(), out newMemorizationScore) && newMemorizationScore >= 50 && newMemorizationScore <= 500)
        {
            memorizationScore = newMemorizationScore;
        }
        else
        {
            Console.WriteLine("Invalid input. Memorization score should be between 50 and 500.");
        }

        Console.Write($"Maximum forgetting days ({maxForgetDays}..10): ");
        int newMaxForgetDays;
        if (int.TryParse(Console.ReadLine(), out newMaxForgetDays) && newMaxForgetDays >= 1 && newMaxForgetDays <= 10)
        {
            maxForgetDays = newMaxForgetDays;
        }
        else
        {
            Console.WriteLine("Invalid input. Maximum forgetting days should be between 1 and 10.");
        }

        Console.Write("Do you want to save these settings? (Y/N/R): ");
        string saveOption = Console.ReadLine().ToUpper();
        if (saveOption == "Y")
        {
            Console.WriteLine("Settings saved successfully!");
        }
        else if (saveOption == "R")
        {
            maxLearnWords = 5;
            minRepetition = 3;
            memorizationScore = 100;
            maxForgetDays = 2;
            Console.WriteLine("Settings reset to default values!");
        }
        else
        {
            Console.WriteLine("Settings not saved.");
        }
    }
}

class Vocabulary
{
    public string Key { get; set; }
    public string Description { get; set; }
    public bool Memorized { get; private set; }
    public bool Reviewed { get; private set; }

    public Vocabulary(string key, string description)
    {
        Key = key;
        Description = description;
        Memorized = false;
        Reviewed = false;
    }

    public void Remember()
    {
        Memorized = true;
        Reviewed = true;
    }

    public void Forget()
    {
        Memorized = false;
        Reviewed = true;
    }
}
