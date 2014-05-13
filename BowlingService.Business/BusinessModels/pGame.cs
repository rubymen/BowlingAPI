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
        public void assignToLane()
        {
            using (var db = new bowlingEntities())
            {
                lane lane = (from l in db.lanes
                             where l.State == "available"
                             select l).SingleOrDefault();

                db.games.Attach(this);
                db.Entry(this).State = EntityState.Modified;

                if (lane != null)
                {
                    this.Lane_id = lane.Id;
                }
                else
                {
                    this.assignReservation();
                }

                db.SaveChanges();
            }
        }

        public void assignReservation()
        {
            using (bowlingEntities db = new bowlingEntities())
            {
                lane lane = (from l in db.lanes
                             join g in db.games on l.Id equals g.Lane_id
                             where g.State != "finished"
                             select l).SingleOrDefault();

                db.games.Attach(this);
                db.Entry(this).State = EntityState.Modified;

                if (lane != null)
                    this.Lane_id = lane.Id;
                else
                    this.Lane_id = (from l in db.lanes select l).SingleOrDefault().Id;
            }
        }
    }
}
