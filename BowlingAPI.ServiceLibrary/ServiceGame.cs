using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingService.Business;

namespace BowlingAPI.ServiceLibrary
{
    public class ServiceGame : IServiceGame
    {
        public void assignToLane(game g)
        {          
            g.assignToLane();
        }

        public game find(string id)
        {
            int idG = int.Parse(id);
            var games = new Repository<game>();
            return games.FindBy(g => g.Id == idG).Single();
        }

        public List<game> findAll()
        {
            var games = new Repository<game>();
            return games.GetAll().ToList();
        }
    }
}
