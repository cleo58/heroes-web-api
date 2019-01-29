using HeroesWebApi.HeroesConfig;
using HeroesWebApi.Services;
using HeroesWebApi.TimerFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HeroesWebApi.Controllers
{
    public class HeroController: ControllerBase
    {
        private readonly HeroesService _heroesService;

        private IHubContext<HeroHub> _hub;

        public HeroController(HeroesService heroesService, IHubContext<HeroHub> hub)
        {
            _heroesService = heroesService;
            _hub = hub;
   
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferherodata", _heroesService.GetListOfHeroes()));
            return Ok(new { Message = "Request Completed" });
        }
    }
}
