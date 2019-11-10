
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MazeComponents
{
    public class QuestionFactory
    {
        private int _EasyQuestionRowId = 1;
        private int _MediumQuestionRowId = 1;
        private int _HardQuestionRowId = 1; // keeps track of what questiosn have been already used from database.

        //string _Database = $"Data Source={Environment.CurrentDirectory}\\QuestionsForMazeRunner.db; Version=3;";
        string _Database = @"Data Source=C:\Users\saffron\source\repos\mazeRunner\mazeRunner_Console\QuestionsForMazeRunner.db; Version=3;";



        public Queue<Question> getQuestions(string[] questionArgs, int numberOfQuestionsToReturn)
        {
            // question args are for type of question. perhaps make enum. like sports+difficult. 
            // what sort of questions to inlude in the returned list.

            //mock code:
            using SQLiteConnection sql_conn = new SQLiteConnection(_Database);



            sql_conn.Open();
            var questions = new Queue<Question>();

            int newRowID=1;

            using (SQLiteCommand cmd = sql_conn.CreateCommand())
            {
                SQLiteDataReader reader;
                for (int i = _EasyQuestionRowId; i < _EasyQuestionRowId + numberOfQuestionsToReturn; i++)
                {





                    cmd.CommandText = @"select * from EasyQuestions where ID=" + i;
                    //cmd.Parameters.Add(new SQLiteParameter("@userId") { Value = userId });
                    cmd.CommandType = System.Data.CommandType.Text;

                   
                    reader = cmd.ExecuteReader();




                    if (reader.Read())
                    {
                        
                      
                        int ID = Convert.ToInt32(reader["ID"]);
                        string type= (reader["Type"].ToString());
                        string category = (reader["Category"].ToString());
                        string difficulty = (reader["Difficulty"].ToString());
                        string question = (System.Web.HttpUtility.HtmlDecode(reader["Question"].ToString()));
                        
                        string correctAnswer= (reader["CorrectAnswer"].ToString());

                        string[] incorrectAnswers = reader["IncorrectAnswers"].ToString().Split("|");


                        questions.Enqueue(new Question(difficulty, category, type, question, correctAnswer, incorrectAnswers));

                    }
                    //Console.WriteLine(reader);
                    reader.Close();
                    newRowID = i;
                }

                _EasyQuestionRowId = newRowID+1;

                //sql_cmd.ExecuteNonQuery();

                //questions.Enqueue(new Question(i));
            }

            sql_conn.Close();

            return questions;
            //end mock code

        }
    }
}