using mvc_game.Data;
using mvc_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_game
{
    
    public class Service
    {
        private Repository repos;
        private mvc_gameContext context;
        Random rnd;

        public Service(mvc_gameContext _context)
        {
            context = _context;
            repos = new Repository(context);
            rnd = new Random();
        }

        public void GameStart(ref Game game)
        {
            game.QuestionCount = game.NextQuestionCount;
            game.CurrentPoints = 0;
            game.Step = game.MaxPoint / game.QuestionCount;
            game.PossiblePoints = game.Step;
            game.GameStart = true;
            game.HelpUsed = false;
            game.QuestionCounter = 0;
            game.GameWin = false;
            

            int temp;
            game.QustionOrder = new List<int>();
            for(int i = 0; i < game.QuestionCount; i++)
            {
                do
                {
                    temp = rnd.Next(1, context.Question.Count());
                } while (game.QustionOrder.Contains(temp));
                game.QustionOrder.Add(temp);
            }

            getQA(ref game);
        }

        public void GameControl(ref Game game,string ans_btn)
        {        
            if (Convert.ToInt32(ans_btn) == game.question.IdAnswer)
            {
                game.QuestionCounter++;
                if (game.QuestionCounter == game.QuestionCount)
                {
                    game.CurrentPoints = 1000000;
                    game.GameWin = true;
                }
                else
                {
                    game.CurrentPoints += game.Step;
                    if (game.QuestionCounter == game.QuestionCount - 1) game.PossiblePoints = 1000000;
                    else game.PossiblePoints += game.Step;
                    getQA(ref game);
                }
            }
            else game.GameStart = false;
        }
    
        public void getQA(ref Game game)
        {
            game.question = repos.GetQuestion(game.QustionOrder[0]);
            game.answers = repos.GetAnswers(game.QustionOrder[0]);
            game.QustionOrder.RemoveAt(0);
        }

        public void Help(ref Game game)
        {
            if (game.HelpUsed == false)
            {

                int temp;

                for (int i = 0; i < 2; i++)
                {
                    do
                    {
                        temp = rnd.Next(0, game.answers.Count - 1);
                    } while (game.answers[temp].Id == game.question.IdAnswer);
                    Console.WriteLine(temp);
                    game.answers.RemoveAt(temp);
                }

                game.HelpUsed = true;
            }
        }
    }
}
