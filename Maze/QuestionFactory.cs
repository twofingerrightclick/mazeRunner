
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MazeComponents
{
    public class QuestionFactory
    {
        private int _EasyQuestionRowId = 0;
        private int _MediumQuestionRowId = 0;
        private int _HardQuestionRowId = 0; // keeps track of what questiosn have been already used from database.

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

            int newRowID=0;

            using (SQLiteCommand cmd = sql_conn.CreateCommand())
            {
                for (int i = _EasyQuestionRowId; i < _EasyQuestionRowId + numberOfQuestionsToReturn; i++)
                {





                    cmd.CommandText = @"select Category from EasyQuestions where ID=" + i + 1;
                    //cmd.Parameters.Add(new SQLiteParameter("@userId") { Value = userId });
                    cmd.CommandType = System.Data.CommandType.Text;

                    SQLiteDataReader reader;
                    reader = cmd.ExecuteReader();




                    if (reader.Read())
                    {
                        Console.WriteLine("-------");
                        //Console.WriteLine(reader["ID"].ToString());
                        Console.WriteLine(reader["Category"].ToString());
                        //Console.WriteLine(reader["Type"].ToString());
                        //Console.WriteLine(reader["Question"].ToString());
                        //Console.WriteLine(reader["CorrectAnswer"].ToString());

                    }
                    reader.Close();
                    newRowID = i;
                }

                _EasyQuestionRowId = newRowID;

                //sql_cmd.ExecuteNonQuery();

                //questions.Enqueue(new Question(i));
            }

            sql_conn.Close();

            return questions;
            //end mock code

        }
    }
}