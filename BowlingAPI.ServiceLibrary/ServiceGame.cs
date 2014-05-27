using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingService.Business;
using System.Data.Entity;
using System.Globalization;

namespace BowlingAPI.ServiceLibrary
{
    public class ServiceGame : IServiceGame
    {
        public void assignToLane(string id)
        {
            var lanes = new Repository<lane>();
            var games = new Repository<game>();

            int g_id = int.Parse(id);

            lane lane = (from l in lanes.GetAll()
                         where l.State == "available"
                         select l).SingleOrDefault();

            game g = games.FindBy(q => q.Id == g_id).SingleOrDefault();

            if (g != null && lane != null)
            {
                lane.State = "unavailable";
                g.lane = lane;
            }
            else
            {
                lane la = (from l in lanes.GetAll()
                             join ga in games.GetAll() on l.Id equals ga.Lane_id
                             where ga.State != "finished"
                             select l).SingleOrDefault();

                if (la != null)
                {
                    lane.State = "unavailable";
                    g.Lane_id = la.Id;
                }
                else
                {
                    lane lan = (from l in lanes.GetAll() select l).SingleOrDefault();
                    lan.State = "unavailable";
                    g.Lane_id = lan.Id;
                }
            }
            games.Save();
        }

        

        public game find(string id)
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

        public List<game> findAll(string number, string filter = "", string param = "")
        {
            int num = int.Parse(number);
            num *= 20;
            var games = new Repository<game>();
            var players = new Repository<player>();
            var lanes = new Repository<lane>();
            var turns = new Repository<turn>();
            List<game> lst = new List<game>();
            if (filter == null)
            {
                lst = games.GetAll().OrderBy(x => x.Created_at).Skip(num).Take(num + 20).ToList<game>();
            }
            else if (filter == "date" && param != "")
            {
                DateTime date;
                DateTime nextDay;
                if (DateTime.TryParseExact(param, "dd-MM-yyyy", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                {
                    date = DateTime.ParseExact(param, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    nextDay = date.AddDays(1);
                    lst = games.GetAll().Where(x => x.Created_at.Value >= date && x.Created_at.Value <= nextDay).ToList<game>();
                }
            }
            else if (filter == "state" && param != "")
            {
                lst = games.GetAll().Where(x => x.State == param).OrderBy(x => x.Created_at).Skip(num).Take(num + 20).ToList<game>();
            }

            foreach (game item in lst)
            {
                item.players = item.getPlayers();
                item.lane = item.getLane();

                foreach (player p in item.players)
                {
                    p.turns = p.getTurns();

                    foreach (turn t in p.turns)
                    {
                        t.throws = t.GetThrows();
                    }
                }
            }

            return lst;
        }

        public List<game> findAllfrom24H()
        {
            var games = new Repository<game>();
            var players = new Repository<player>();
            var lanes = new Repository<lane>();
            var turns = new Repository<turn>();

            var dte = DateTime.Today.AddDays(-1);

            List<game> lst = games.GetAll().Where(x => x.Created_at >= dte && x.State != "canceled").ToList<game>();

            foreach (game item in lst)
            {
                item.players = item.getPlayers();
                item.lane = item.getLane();

                foreach (player p in item.players)
                {
                    p.turns = p.getTurns();

                    foreach (turn t in p.turns)
                    {
                        t.throws = t.GetThrows();
                    }
                }
            }

            return lst;
        }

        public game createGame()
        {
            Repository<game> games = new Repository<game>();
            game g = new game();
            g.Created_at = DateTime.Now;
            g.State = "pending";
            g.assignToLane();
            games.Add(g);

            games.Save();

            var gam = (from ga in games.GetAll()
                       select ga).ToList();

            return gam.Last();
        }

        public void addPlayer(string id, player p)
        {
            int idGame = int.Parse(id);
            var games = new Repository<game>();

            game ga = games.FindBy(x => x.Id == idGame).SingleOrDefault();

            ga.players.Add(p);

            games.Save();
        }


        public void updateState(string id, string state)
        {
            int idGame = int.Parse(id);

            var games = new Repository<game>();
            game g = games.FindBy(x => x.Id == idGame).SingleOrDefault();
            g.State = state;
            games.Save();
        }
    }
}
