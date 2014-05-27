using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingService.Business
{
    public partial class game
    {
        public List<player> getPlayers()
        {
            var players = new Repository<player>();
            List<player> list = (from p in players.GetAll()
                                 where p.Game_id == this.Id
                                 select p).ToList();
            return list;
        }

        public lane getLane()
        {
            var lanes = new Repository<lane>();

            lane l = (from la in lanes.GetAll()
                      where la.Id == this.Lane_id
                      select la).SingleOrDefault();

            return l;
        }

        public void assignToLane()
        {
            using (var db = new bowlingEntities())
            {
                lane lane = (from l in db.lanes
                             where l.State == "available"
                             select l).First();

                if (lane != null)
                {
                    this.Lane_id = lane.Id;
                }
                else
                {
                    this.assignReservation();
                }
            }
        }

        public void assignReservation()
        {
            using (bowlingEntities db = new bowlingEntities())
            {
                List<int> lane_ids = (from l in db.lanes
                                      select l.Id).ToList();

                Random rng = new Random();
                int n = lane_ids.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    int value = lane_ids[k];
                    lane_ids[k] = lane_ids[n];
                    lane_ids[n] = value;
                }

                this.Lane_id = lane_ids.First();
            }
        }

    }
}
