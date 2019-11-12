﻿
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MazeComponents
{
    public class QuestionFactory
    {
        private int[] _IndexCounters = new int[] { 1, 1, 1 };
        string[] _Tables = new string[] { "EasyQuestions", "MediumQuestions", "HardQuestions" };
        private enum _EnumTable
        {
            EasyQuestion = 0,
            MediumQuestions = 1,
            HardQuestions = 2
        }
        // keeps track of what questiosn have been already used from database.

        //string _Database = $"Data Source={Environment.CurrentDirectory}\\QuestionsForMazeRunner.db; Version=3;";
        string _Database = @"Data Source=C:\Users\saffron\source\repos\mazeRunner\mazeRunner_Console\QuestionsForMazeRunner.db; Version=3;";




        public Queue<Question> getQuestions(string[] questionArgs, int numberOfQuestionsToReturn)
        {

            bool getRandomQuestions = false;



            int currentTableToGetFrom = 0;



            if (questionArgs!= null && questionArgs.Length > 0)
            {
                string args = questionArgs.ToString();
                if (args.Contains("e"))
                {
                    currentTableToGetFrom = (int)_EnumTable.EasyQuestion;


                }
                if (args.Contains("m"))
                {
                    currentTableToGetFrom = (int)_EnumTable.MediumQuestions;

                }
            }

            else { getRandomQuestions = true; }




            // question args are for type of question. perhaps make enum. like sports+difficult. 
            // what sort of questions to inlude in the returned list.

            
            using SQLiteConnection sql_conn = new SQLiteConnection(_Database);

            Random randomInt = new Random();

            sql_conn.Open();
            var questions = new Queue<Question>();

            double percentHard = .1;
            double percentEasy = .7;
            double percentMedium = .2;

            using (SQLiteCommand cmd = sql_conn.CreateCommand())
            {
                SQLiteDataReader reader;
                for (int i = 0; i < numberOfQuestionsToReturn; i++)
                {


                    // gets questions based on percentage of difficulty
                    if (getRandomQuestions == true)
                    {
                        int random = randomInt.Next(100) + 1;
                        if (random / 100 <= percentHard)
                        {
                            currentTableToGetFrom = 2;
                        }
                        if (random / 100 <= percentMedium)
                        {
                            currentTableToGetFrom = 1;
                        }
                        if (random / 100 <= percentEasy)
                        {
                            currentTableToGetFrom = 0;
                        }

                       // Console.WriteLine(currentTableToGetFrom);

                    }



                    cmd.CommandText = $"select * from {_Tables[currentTableToGetFrom]} where ID=" + _IndexCounters[currentTableToGetFrom];
                    cmd.CommandType = System.Data.CommandType.Text;
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        int ID = Convert.ToInt32(reader["ID"]);
                        string type = (reader["Type"].ToString());
                        string category = (reader["Category"].ToString());
                        string difficulty = (reader["Difficulty"].ToString());
                        string question = (System.Web.HttpUtility.HtmlDecode(reader["Question"].ToString()));
                        string correctAnswer = (reader["CorrectAnswer"].ToString());
                        string[] incorrectAnswers = reader["IncorrectAnswers"].ToString().Split("|");
                       // Console.WriteLine(difficulty);
                        //Console.WriteLine(correctAnswer);
                        questions.Enqueue(new Question(difficulty, category, type, question, correctAnswer, incorrectAnswers));

                    }

                    reader.Close();
                    _IndexCounters[currentTableToGetFrom]++;
                }




            }

            sql_conn.Close();

            return questions;


        }


    }
}