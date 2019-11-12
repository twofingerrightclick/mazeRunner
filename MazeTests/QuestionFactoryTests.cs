
using MazeComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MazeTests
{
    [TestClass]
    public class QuestionFactoryTests
    {

        [TestMethod]
        public void Question_Factory_DB_Test()
        {

            QuestionFactory q = new QuestionFactory();
            string [] fakeArgs = null;

            Queue<Question> list= q.getQuestions(fakeArgs, 1);
            list.Dequeue();

        }

       

       




        

      






    }
}
