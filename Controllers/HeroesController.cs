using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeroesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {

        private readonly HeroesService _heroesService;

        public HeroesController(HeroesService heroesService)
        {
            _heroesService = heroesService;
        }

        // GET api/heroes
        [HttpGet]
        public ActionResult<List<Heroes>> Get()
        {
            return _heroesService.GetListOfHeroes();
        }

        // GET api/heroes/"ObjectId.toString()"
        [HttpGet("{id}", Name = "GetHero")]
        public ActionResult<Heroes> Get(string id)
        {
     
            var hero = _heroesService.GetHero(id);

            if(hero == null)
            {
                return NotFound();
            }
            return hero;
        }

        // POST api/heroes/create/
        [Route("~/api/heroes/create/")]
        [HttpPost]
        public ActionResult<Heroes> Create([FromBody] Heroes hero)
        {
            _heroesService.CreateHero(hero);

            return CreatedAtRoute("GetHero", new { id = hero._Id }, hero);
        }

        // PUT api/heroes/update/5
        [Route("~/api/heroes/update/")]
        [HttpPut]
        public IActionResult Update([FromBody] Heroes heroIn)
        {
           
            var hero = _heroesService.GetHero(heroIn._Id);

            if(hero == null)
            {
                return NotFound();
            }

            _heroesService.UpdateHero(heroIn);

            return NoContent();
        }

        // DELETE api/heroes/delete/5
        [Route("~/api/heroes/delete/{id}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var hero = _heroesService.GetHero(id);

            if(hero == null)
            {
                return NotFound();
            }

            _heroesService.RemoveByHeroId(hero._Id);

            return NoContent();
        }
    }
}
