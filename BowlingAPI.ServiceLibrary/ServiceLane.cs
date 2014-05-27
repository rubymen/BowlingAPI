using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingService.Business;

namespace BowlingAPI.ServiceLibrary
{
    public class ServiceLane : IServiceLane
    {
        public bool isAvalaible(string id)
        {
            int idL = int.Parse(id);
            var lanes = new Repository<lane>();
            lane lane = lanes.FindBy(l => l.Id == idL).Single();
            return lane.isAvalaible();
        }

        public game getCurrentGame(string id)
        {
            int idl = int.Parse(id);
            var lanes = new Repository<lane>();
            var games = new Repository<game>();
            lane l = lanes.FindBy(x => x.Id == idl).Single();
            game g = games.GetAll().Where(x => x.Lane_id == l.Id && x.State == "in progress").SingleOrDefault();
            g.players = g.getPlayers();
            g.lane = g.getLane();

            foreach (player p in g.players)
            {
                p.turns = p.getTurns();

                foreach (turn t in p.turns)
                {
                    t.throws = t.GetThrows();
                }
            }
            return g;
        }


        public lane find(string id)
        {
            int idL = int.Parse(id);
            var lanes = new Repository<lane>();
            lane lan =  lanes.FindBy(l => l.Id == idL).Single();
            lan.games = lan.getGames();

            foreach (game item in lan.games)
            {
                item.players = item.getPlayers();
                foreach (player p in item.players)
                {
                    p.turns = p.getTurns();

                    foreach (turn t in p.turns)
                    {
                        t.throws = t.GetThrows();
                    }
                }
            }

            return lan;
        }

        public List<lane> findAll()
        {
            var lanes = new Repository<lane>();
            List<lane> lst = lanes.GetAll().ToList();
            foreach (lane l in lst)
            {
                l.games = l.getGames();

                foreach (game item in l.games)
                {
                    item.players = item.getPlayers();
                    foreach (player p in item.players)
                    {
                        p.turns = p.getTurns();

                        foreach (turn t in p.turns)
                        {
                            t.throws = t.GetThrows();
                        }
                    }
                }
            }

            return lst;
        }

        public void updateState(string id, string state)
        {
            int idLane = int.Parse(id);

            var lanes = new Repository<lane>();
            lane l = lanes.FindBy(x => x.Id == idLane).SingleOrDefault();
            l.State = state;

            lanes.Save();
        }
    }
}
