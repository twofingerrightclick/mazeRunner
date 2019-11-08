using System;
using System.Collections.Generic;

namespace MazeComponents
{
    internal class QuestionFactory
    {
        internal Queue<Question> getQuestions(string[] questionArgs, int numberOfQuestionsToReturn)
        {
            // question args are for type of question. perhaps make enum. like sports+difficult. 
            // what sort of questions to inlude in the returned list.
            
            //mock code:
            var questions = new Queue<Question>();
            for (int i = 0; i < numberOfQuestionsToReturn; i++) {
                questions.Enqueue(new Question(i));
            }

            return questions;
            //end mock code
           
        }
    }
}