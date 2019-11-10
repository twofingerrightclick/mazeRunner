
using MazeComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MazeTests
{
    [TestClass]
    public class QuestionFactoryTests
    {



        [TestMethod]
        public void Question_Factory_DB_Test()
        {

            QuestionFactory q = new QuestionFactory();
            string[] fakeArgs = new string[1];

            q.getQuestions(fakeArgs,45);

            q.getQuestions(fakeArgs, 2);

            q.getQuestions(fakeArgs, 2);


        }

       

       




        

      






    }
}
