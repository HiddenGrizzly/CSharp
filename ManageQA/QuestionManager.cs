using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageQA
{
    public class QuestionManager
    {
        private List<Question> questions = new List<Question>();

        public void CreateQuestion()
        {
            Question question = new Question();

            Console.Write("Nhập mã danh mục: ");
            question.CategoryCode = Console.ReadLine();

            Console.Write("Nhập tên danh mục: ");
            question.CategoryName = Console.ReadLine();

            Console.Write("Nhập mã câu hỏi: ");
            question.QuestionCode = Console.ReadLine();

            Console.WriteLine("Nhập câu hỏi:");
            question.QuestionText = Console.ReadLine();

            Console.Write("Điểm số: ");
            question.Score = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập đáp án cho câu hỏi:");
            Answer.AddMultipleAnswers(question.Answers);

            char saveChoice;
            do
            {
                Console.Write("Bạn có muốn lưu câu hỏi này không? (Y/N): ");
                saveChoice = Convert.ToChar(Console.ReadLine());

                if (saveChoice == 'Y')
                {
                    questions.Add(question);
                    Console.WriteLine("Câu hỏi đã được lưu.");
                }
                else if (saveChoice == 'N')
                {
                    Console.WriteLine("Câu hỏi không được lưu.");
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn 'Y' hoặc 'N'.");
                }
            } while (saveChoice != 'Y' && saveChoice != 'N');
        }

        public void UpdateQuestion()
        {
            Console.Write("Nhập mã danh mục của câu hỏi cần cập nhật: ");
            string categoryCode = Console.ReadLine();

            Console.Write("Nhập mã câu hỏi cần cập nhật: ");
            string questionCode = Console.ReadLine();

            Question questionToUpdate = questions.FirstOrDefault(q => q.CategoryCode == categoryCode && q.QuestionCode == questionCode);

            if (questionToUpdate == null)
            {
                Console.WriteLine("Không tìm thấy câu hỏi cần cập nhật.");
                return;
            }
            Console.WriteLine("Nhập các thông tin cần cập nhật:");
            Console.Write("Câu hỏi mới: ");
            questionToUpdate.QuestionText = Console.ReadLine();

            Console.Write("Điểm số mới: ");
            questionToUpdate.Score = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Cập nhật đáp án:");
            Answer.UpdateAnswers(questionToUpdate.Answers);
            Console.WriteLine("Câu hỏi đã được cập nhật.");
        }

        public void DisplayQuestionsByCategory()
        {
            var groupedQuestions = questions.GroupBy(q => q.CategoryCode);

            foreach (var categoryGroup in groupedQuestions)
            {
                Console.WriteLine($"Danh mục: {categoryGroup.Key}");

                foreach (var question in categoryGroup)
                {
                    DisplayQuestionDetails(question);
                }
                Console.WriteLine();
            }
        }
        public void DisplayQuestionDetails(Question question)
        {
            question.DisplayQuestionDetails();
        }
        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }

        public void SaveQuestionsToFile(string fileName, List<Question> generatedTest)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Question question in questions)
                {
                    writer.WriteLine($"{question.CategoryName},{question.QuestionCode},{question.QuestionText},{question.Score},{string.Join(",", question.Options)},{question.CorrectAnswer}");
                }
            }
        }

       public void LoadQuestionsFromFile(string fileName)
{
    questions.Clear();
    try
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                // Parse the options
                List<Answer> options = parts[4].Split(',')
                    .Select(optionText => new Answer { Text = optionText })
                    .ToList();

                // Parse the correct answer
                Answer correctAnswer = options.FirstOrDefault(option => option.IsCorrect == 'D');

                Question question = new Question
                {
                    CategoryName = parts[0],
                    QuestionCode = parts[1],
                    QuestionText = parts[2],
                    Score = double.Parse(parts[3]),
                    Options = options,
                    CorrectAnswer = correctAnswer
                };

                questions.Add(question);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading questions: {ex.Message}");
    }
}


        public List<Question> GetQuestions()
        {
            return questions;
        }

        public List<Question> GetShuffledQuestions()
        {
            Random random = new Random();
            return questions.OrderBy(q => random.Next()).ToList();
        }
    }
}