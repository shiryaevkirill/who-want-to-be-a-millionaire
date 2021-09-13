using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_game.Models
{
    public class Game
    {
        public Question question { get; set; }
        public List<Answer> answers { get; set; }

        public int CurrentPoints { get; set; }
        public int PossiblePoints { get; set; }

        
        public int QuestionCount { get; set; }

        [Range(1, 12)]
        public int NextQuestionCount { get; set; }

        public int MaxPoint { get; }
        public int Step { get; set; }
        public List<int> QustionOrder { get; set; }

        public bool GameStart { get; set; }
        public bool GameWin { get; set; }
        public bool HelpUsed { get; set; }
        public int QuestionCounter { get; set; }

        public Game()
        {
            MaxPoint = 1000000;
            CurrentPoints = 0;
            NextQuestionCount = 10;
            Step = MaxPoint / NextQuestionCount;
            GameStart = false;
            HelpUsed = false;
        }

    }
}
