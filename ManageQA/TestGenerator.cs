using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageQA
{
    public class TestGenerator
    {
        private QuestionManager questionManager;

        public TestGenerator(QuestionManager manager)
        {
            questionManager = manager;
        }

        public List<Question> GenerateTestByPoints(double targetPoints)
        {
            List<Question> selectedQuestions = new List<Question>();
            double totalPoints = 0;

            List<Question> shuffledQuestions = questionManager.GetShuffledQuestions();

            foreach (Question question in shuffledQuestions)
            {
                if (totalPoints + question.Score <= targetPoints)
                {
                    selectedQuestions.Add(question);
                    totalPoints += question.Score;
                }

                if (totalPoints >= targetPoints)
                {
                    break;
                }
            }

            return selectedQuestions;
        }
        public List<Question> GenerateTestByQuantity(int targetQuantity)
        {
            List<Question> selectedQuestions = new List<Question>();
            int totalQuantity = 0;

            List<Question> shuffledQuestions = questionManager.GetShuffledQuestions();

            foreach (Question question in shuffledQuestions)
            {
                if (totalQuantity + 1 <= targetQuantity)
                {
                    selectedQuestions.Add(question);
                    totalQuantity += 1;
                }

                if (totalQuantity >= targetQuantity)
                {
                    break;
                }
            }

            return selectedQuestions;
        }
    }
}