using Microsoft.AspNetCore.Mvc;
using mvc_game.Data;
using mvc_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_game.Controllers
{
    public class GameController : Controller
    {
        private Service serv;
        private static Game game;
        //private mvc_gameContext _context;

        public GameController(mvc_gameContext context)
        {
            if (game == null) game = new Game();
            serv = new Service(context);
        }

        public IActionResult Index()
        {
            if(!game.GameStart)serv.GameStart(ref game);
            return View(game);
        }


        [HttpPost]
        public IActionResult Index(string ans_btn)
        {
            serv.GameControl(ref game,ans_btn);
            return View(game);
        }



        [HttpPost]

        public IActionResult ChangeCount(Game _game)
        {
            game.NextQuestionCount = _game.NextQuestionCount;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Restart()
        {
            serv.GameStart(ref game);
            return RedirectToAction("Index");
        }

        public IActionResult Help()
        {
            serv.Help(ref game);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult QuestAndAns(string ans_btn)
        //{
        //    serv.GameControl(ref game, ans_btn);
        //    return View(game);
        //}

    }
}
