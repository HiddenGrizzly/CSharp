using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageQA
{
    public class Answer
    {
        public string Text { get; set; }
        public char IsCorrect { get; set; }
        public static void AddMultipleAnswers(List<Answer> answers)
        {
            do
            {
                Answer answer = new Answer();

                Console.Write($"Đáp án {answers.Count + 1}: ");
                answer.Text = Console.ReadLine();

                Console.Write("Đúng/Sai? (D/S) ");
                answer.IsCorrect = Convert.ToChar(Console.ReadLine());

                while (answer.IsCorrect != 'D' && answer.IsCorrect != 'S')
                {
                    Console.WriteLine("Invalid input. Please enter 'D' or 'S'.");
                    Console.Write("Đúng/Sai? (D/S) ");
                    answer.IsCorrect = Convert.ToChar(Console.ReadLine());
                }

                answers.Add(answer);

                Console.Write("Bạn muốn thêm đáp án khác không? (Y/N): ");
            } while (Console.ReadLine().ToUpper() == "Y");
        }
        public static void UpdateAnswers(List<Answer> answers)
        {
            Console.WriteLine("Các đáp án hiện tại:");
            DisplayAnswers(answers);

            Console.Write("Bạn muốn sửa đáp án nào? (Nhập số thứ tự hoặc 0 để thoát): ");
            int answerIndex = Convert.ToInt32(Console.ReadLine());

            while (answerIndex != 0 && (answerIndex < 1 || answerIndex > answers.Count))
            {
                Console.WriteLine("Số thứ tự không hợp lệ. Vui lòng nhập lại hoặc nhập 0 để thoát.");
                Console.Write("Bạn muốn sửa đáp án nào? (Nhập số thứ tự hoặc 0 để thoát): ");
                answerIndex = Convert.ToInt32(Console.ReadLine());
            }

            if (answerIndex == 0)
            {
                return;
            }

            Answer answerToUpdate = answers[answerIndex - 1];

            Console.Write($"Sửa đáp án {answerIndex}: ");
            answerToUpdate.Text = Console.ReadLine();

            Console.Write("Đúng/Sai? (D/S) ");
            answerToUpdate.IsCorrect = Convert.ToChar(Console.ReadLine());

            while (answerToUpdate.IsCorrect != 'D' && answerToUpdate.IsCorrect != 'S')
            {
                Console.WriteLine("Nhập sai. Hãy nhập 'D' hoặc 'S'.");
                Console.Write("Đúng/Sai? (D/S) ");
                answerToUpdate.IsCorrect = Convert.ToChar(Console.ReadLine());
            }

            Console.Write("Bạn muốn sửa thêm đáp án không? (Y/N): ");
            char addMoreChoice = Convert.ToChar(Console.ReadLine());

            while (addMoreChoice == 'Y')
            {
                Answer newAnswer = new Answer();

                Console.Write($"Thêm đáp án {answers.Count + 1}: ");
                newAnswer.Text = Console.ReadLine();

                Console.Write("Đúng/Sai? (D/S) ");
                newAnswer.IsCorrect = Convert.ToChar(Console.ReadLine());

                while (newAnswer.IsCorrect != 'D' && newAnswer.IsCorrect != 'S')
                {
                    Console.WriteLine("Nhập sai. Hãy nhập 'D' hoặc 'S'.");
                    Console.Write("Đúng/Sai? (D/S) ");
                    newAnswer.IsCorrect = Convert.ToChar(Console.ReadLine());
                }

                answers.Add(newAnswer);

                Console.Write("Bạn muốn thêm đáp án khác không? (Y/N): ");
                addMoreChoice = Convert.ToChar(Console.ReadLine());
            }
        }

        private static void DisplayAnswers(List<Answer> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {answers[i].Text} (Đúng/Sai: {answers[i].IsCorrect})");
            }
        }
    }
}