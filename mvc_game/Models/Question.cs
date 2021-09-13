using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_game.Models
{
    public class Question
    {
        [DisplayName("question")]
        public string question { get; set; }
        public int Id { get; set; }
        [DisplayName("IdAnswer")]
        public int IdAnswer { get; set; }
    }
}
