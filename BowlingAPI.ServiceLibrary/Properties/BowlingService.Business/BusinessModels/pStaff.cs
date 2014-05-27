using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BowlingService.Business
{
    public partial class staff
    {
        public game createGame()
        {
            bowlingEntities db = new bowlingEntities();
            game g = new game();
            g.State = "pending";
            try
            {
                db.games.Add(g);
                db.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw new Exception("Error", e);
            }

            return g;
        }

        public void addPlayer(game g, player p)
        {
            using (var db = new bowlingEntities())
            {
                try
                {
                    game game = db.games.Find(g.Id);
                    game.players.Add(p);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error", e);
                }
            }
        }

        public void removePlayer(game g, player p)
        {
            using (var db = new bowlingEntities())
            {
                try
                {
                    game game = db.games.Find(g.Id);
                    game.players.Add(p);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error", e);
                }
            }
        }

        public void startGame(game g)
        {
            using (var db = new bowlingEntities())
            {
                try
                {
                    game game = db.games.Find(g.Id);
                    game.State = "in progress";
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error", e);
                }
            }
        }

        public void cancelGame(game g)
        {
            using (var db = new bowlingEntities())
            {
                try
                {
                    game game = db.games.Find(g.Id);
                    game.State = "canceled";
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error", e);
                }
            }
        }

        public bool connect(string pseudo, string password)
        {
            bool connected = false;
            using (var db = new bowlingEntities())
            {
                try
                {
                    string pwd = utils.CalculateMD5Hash(password);
                    staff user = (from s in db.staffs
                                  where s.Pseudo == pseudo
                                  && s.Password == pwd
                                  select s).Single();
                    if (user != null)
                        connected = true;
                    else
                        connected = false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error", e);
                }

                return connected;
            }
        }
    }
}
