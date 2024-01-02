using System;
using ManageQA;

class Program
{
    static void Main()
    {
        QuestionManager questionManager = new QuestionManager();
        TestGenerator testGenerator = new TestGenerator(questionManager);

        int choice;
        do
        {
            Console.WriteLine("--Chương trình quản lý đề thi----");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Quản lý câu hỏi/trả lời.");
            Console.WriteLine("2. Quản lý đề thi.");
            Console.WriteLine("3. Thoát.");
            Console.Write("#Chọn: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ManageQuestionsAnswers(questionManager);
                    break;
                case 2:
                    ManageTests(questionManager, testGenerator);
                    break;
                case 3:
                    Console.WriteLine("Chương trình kết thúc. Chúc thành công!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }

        } while (choice != 3);
    }

    static void ManageQuestionsAnswers(QuestionManager questionManager)
    {
        int choiceQA;
        do
        {
            Console.WriteLine("======Quản lý Câu hỏi/Trả lời=======");
            Console.WriteLine("1. Xem danh sách Q/A");
            Console.WriteLine("2. Cập nhật Q/A");
            Console.WriteLine("3. Tạo mới một Q/A");
            Console.WriteLine("0. Trở về menu chính.");
            Console.Write("#Chọn: ");
            choiceQA = Convert.ToInt32(Console.ReadLine());

            switch (choiceQA)
            {
                case 1:
                    DisplayCategoriesAndQuestions(questionManager);
                    break;
                case 2:
                    questionManager.UpdateQuestion();
                    break;
                case 3:
                    questionManager.CreateQuestion();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }

        } while (choiceQA != 0);
    }

    static void DisplayCategoriesAndQuestions(QuestionManager questionManager)
    {
        int choiceDisplay;
        do
        {
            Console.WriteLine("======Danh sách các câu hỏi=========");
            questionManager.DisplayQuestionsByCategory();
            Console.WriteLine("0. Trở về menu trước.");
            Console.Write("#Chọn: ");
            choiceDisplay = Convert.ToInt32(Console.ReadLine());

            switch (choiceDisplay)
            {
                case 0:
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }

        } while (choiceDisplay != 0);
    }

    static void ManageTests(QuestionManager questionManager, TestGenerator testGenerator)
    {
        int choiceTest;
        do
        {
            Console.WriteLine("====Quản lý đề thi=================");
            Console.WriteLine("1. Xem đề thi");
            Console.WriteLine("2. Tạo đề thi");
            Console.WriteLine("0. Trở về menu chính");
            Console.Write("#Chọn: ");
            choiceTest = Convert.ToInt32(Console.ReadLine());

            switch (choiceTest)
            {
                case 1:
                    DisplayTests(questionManager);
                    break;
                case 2:
                    GenerateAndSaveTest(questionManager, testGenerator);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }

        } while (choiceTest != 0);
    }

    static void DisplayTests(QuestionManager questionManager)
    {
        Console.Write("Nhập tên file đề thi: ");
        string fileName = Console.ReadLine();
        questionManager.LoadQuestionsFromFile(fileName);
        Console.WriteLine("===============================");
        foreach (Question question in questionManager.GetQuestions())
        {
            Console.WriteLine($"- Câu {question.QuestionCode}: {question.QuestionText} [{question.Score}d]");
            foreach (Answer answer in question.Answers)
            {
                Console.WriteLine($"{(answer.IsCorrect == 'D' ? '*' : ' ')} {answer.Text}");
            }
            Console.WriteLine("===============================");
        }
    }

    static void GenerateAndSaveTest(QuestionManager questionManager, TestGenerator testGenerator)
    {
        Console.WriteLine("====Tạo đề thi===================");
        Console.WriteLine("1. Đề thi theo số lượng câu hỏi");
        Console.WriteLine("2. Đề thi theo tổng số điểm");
        Console.WriteLine("0. Trở về menu trước");
        Console.Write("#Chọn: ");
        int choiceGenerate = Convert.ToInt32(Console.ReadLine());

        switch (choiceGenerate)
        {
            case 1:
                GenerateAndSaveTestByQuantity(questionManager, testGenerator);
                break;
            case 2:
                GenerateAndSaveTestByPoints(questionManager, testGenerator);
                break;
            case 0:
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                break;
        }
    }

    static void GenerateAndSaveTestByQuantity(QuestionManager questionManager, TestGenerator testGenerator)
    {
        Console.Write("Nhập số lượng câu hỏi: ");
        int numberOfQuestions = Convert.ToInt32(Console.ReadLine());
        List<Question> generatedTest = testGenerator.GenerateTestByQuantity(numberOfQuestions);

        DisplayGeneratedTest(generatedTest);

        Console.Write("Bạn có muốn lưu đề này?(Y/N) ");
        char saveChoice = Convert.ToChar(Console.ReadLine());

        if (saveChoice == 'Y')
        {
            Console.Write("Nhập tên file: ");
            string fileName = Console.ReadLine();
            questionManager.SaveQuestionsToFile(fileName, generatedTest);
            Console.WriteLine($"Đã lưu đề vào file {fileName}.");
        }
    }

    static void GenerateAndSaveTestByPoints(QuestionManager questionManager, TestGenerator testGenerator)
    {
        Console.Write("Nhập tổng số điểm: ");
        double targetPoints = Convert.ToDouble(Console.ReadLine());
        List<Question> generatedTest = testGenerator.GenerateTestByPoints(targetPoints);

        DisplayGeneratedTest(generatedTest);

        Console.Write("Bạn có muốn lưu đề này?(Y/N) ");
        char saveChoice = Convert.ToChar(Console.ReadLine());

        if (saveChoice == 'Y')
        {
            Console.Write("Nhập tên file: ");
            string fileName = Console.ReadLine();
            questionManager.SaveQuestionsToFile(fileName, generatedTest);
            Console.WriteLine($"Đã lưu đề vào file {fileName}.");
        }
    }

    static void DisplayGeneratedTest(List<Question> generatedTest)
    {
        Console.WriteLine("===============================");
        foreach (Question question in generatedTest)
        {
            Console.WriteLine($"- Câu {question.QuestionCode}: {question.QuestionText} [{question.Score}d]");
            foreach (Answer answer in question.Answers)
            {
                Console.WriteLine($"{(answer.IsCorrect == 'D' ? '*' : ' ')} {answer.Text}");
            }
            Console.WriteLine("===============================");
        }
    }
}
