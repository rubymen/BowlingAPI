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
            int idL = int.Parse(id);
            var lanes = new Repository<lane>();
            lane lane = lanes.FindBy(l => l.Id == idL).Single();
            return lane.getCurrentGame();
        }


        public lane find(string id)
        {
            int idL = int.Parse(id);
            var lanes = new Repository<lane>();
            return lanes.FindBy(l => l.Id == idL).Single();
        }

        public List<lane> findAll()
        {
            var lanes = new Repository<lane>();
            return lanes.GetAll().ToList();
        }
    }
}
