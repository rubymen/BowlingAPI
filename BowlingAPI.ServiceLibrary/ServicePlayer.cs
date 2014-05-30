using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingService.Business;
using System.Runtime.Serialization;


namespace BowlingAPI.ServiceLibrary
{
    public class ServicePlayer : IServicePlayer
    {
        public game createGame(List<player> players)
        {
           Repository<game> games = new Repository<game>();
           game g = new game();
           g.Created_at = DateTime.Now;
           g.players = players;
           games.Add(g);
           games.Save();
           var game = (from ga in games.GetAll()
                       select ga).ToList();
           return game.Last();

        }

        public void addPlayer(player p, string gId)
        {
            game g = this.findGame(gId);
            Repository<game> games = new Repository<game>();
            g.players.Add(p);
            games.Save();
        }

        public void deletePlayer(string id)
        {
            int idP = int.Parse(id);
            Repository<player> players = new Repository<player>();
            player p = players.FindBy(x => x.Id == idP).SingleOrDefault();
            players.Delete(p);

            players.Save();
        }


        public player find(string id)
        {
            int idP = int.Parse(id);
            Repository<player> players = new Repository<player>();

            return players.FindBy(g => g.Id == idP).FirstOrDefault();
        }

        public List<player> findAll()
        {
            Repository<player> players = new Repository<player>();
            List<player> list = (List<player>)players.GetAll().ToList();
            
            return list;
        }


        public game findGame(string id)
        {
            int idG = int.Parse(id);
            var games = new Repository<game>();
            game ga = games.FindBy(g => g.Id == idG).Single();
            ga.lane = ga.getLane();
            ga.players = ga.getPlayers();

            foreach (player p in ga.players)
            {
                p.turns = p.getTurns();

                foreach (turn t in p.turns)
                {
                    t.throws = t.GetThrows();
                }
            }
            return ga;
        }

        public void updatePlayer(player p)
        {
            var players = new Repository<player>();
            player pl = players.FindBy(x => x.Id == p.Id).SingleOrDefault();

            players.Edit(pl);
            pl.Pseudo = p.Pseudo;
            players.Save();
        }
    }
}
