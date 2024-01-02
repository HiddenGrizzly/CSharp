using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageQA
{
    public class Question
    {
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string QuestionCode { get; set; }
        public string QuestionText { get; set; }
        public double Score { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public Answer? CorrectAnswer { get; internal set; }
        public List<Answer> Options { get; internal set; }

        public void DisplayQuestionDetails()
        {
            Console.WriteLine($"Mã danh mục: {CategoryCode}");
            Console.WriteLine($"Tên danh mục: {CategoryName}");
            Console.WriteLine($"Mã câu hỏi: {QuestionCode}");
            Console.WriteLine($"Câu hỏi: {QuestionText}");
            Console.WriteLine($"Điểm số: {Score}");

            Console.WriteLine("Đáp án:");
            foreach (var answer in Answers)
            {
                Console.WriteLine($"- {answer.Text} (Đúng/Sai: {answer.IsCorrect})");
            }
        }
    }
}