using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingService.Business
{
    public partial class player 
    {
        public game createGame()
        {
            using (var db = new bowlingEntities())
            {
                db.players.Attach(this);
                db.Entry(this).State = EntityState.Modified;

                game game = new game();
                game.players.Add(this);

                try
                {
                    db.games.Add(game);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error", e);
                }

                return game;
            }
        }

        public void addPlayer(player p)
        {
            using (var db = new bowlingEntities())
            {
                this.game.players.Add(p);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error", e);
                }
            }
        }

        public void deletePlayer()
        {
            using (var db = new bowlingEntities())
            {
                this.game.players.Remove(this);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Error", e);
                }
            }             
        }
    }
}
