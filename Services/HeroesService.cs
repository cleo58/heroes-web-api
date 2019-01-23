using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HeroesWebApi.Services
{
    public class HeroesService
    {
        private readonly IMongoCollection<Heroes> _heroes;
        public HeroesService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Mongodb"));
            var database = client.GetDatabase("HeroeDB");
            _heroes = database.GetCollection<Heroes>("heroes");
        }

        public List<Heroes> GetListOfHeroes()
        {
            return _heroes.Find(hero => true).ToList();
        }

  
        public Heroes GetHero(string id)
        {
            return _heroes.Find<Heroes>(hero => hero._Id == id).FirstOrDefault();
        }
        public Heroes CreateHero(Heroes hero)
        {
            _heroes.InsertOne(hero);
            return hero;
        }

        public void UpdateHero(Heroes heroIn)
        {   
            _heroes.ReplaceOne(hero => hero._Id == heroIn._Id, heroIn);
        }

        public void RemoveByHeroObj(Heroes heroIn)
        {
            _heroes.DeleteOne(hero => hero._Id == heroIn._Id);
        }

        public void RemoveByHeroId(string id)
        {
            _heroes.DeleteOne(hero => hero._Id == id);
        }
    }
}
