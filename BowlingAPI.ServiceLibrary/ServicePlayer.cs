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
        public game createGame(player p)
        {
           return p.createGame();
        }

        public void addPlayer(player currentPlayer, player p)
        {
            currentPlayer.addPlayer(p);
        }

        public void deletePlayer(string id)
        {
            player p = this.find(id);
           
            p.deletePlayer();
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
    }
}
