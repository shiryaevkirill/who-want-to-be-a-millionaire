using mvc_game.Data;
using mvc_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_game
{
    public class Repository
    {
        private mvc_gameContext _context;

        public Repository(mvc_gameContext context)
        {
            _context = context;
        }
       

        public Question GetQuestion(int id)
        {
            var quest = _context.Question.Find(id);
            //Console.WriteLine(quest.question);
            return quest;
        }

        public List<Answer> GetAnswers(int id)
        {
            var answers = _context.Answer.Where(ans => ans.IdQuestion == id).ToList();

            return answers;
        }


    }
}
