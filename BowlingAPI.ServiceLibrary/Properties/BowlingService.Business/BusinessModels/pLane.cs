using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingService.Business
{
    public partial class lane
    {
        public bool isAvalaible()
        {
            return this.State == "available";
        }

        public game getCurrentGame()
        {
            using (var db = new bowlingEntities())
            {
                if (!this.isAvalaible())
                    return db.games.Where(x => x.State == "in progress" && x.Lane_id == this.Id).SingleOrDefault();
                else
                    return null;
            }
        }
    }
}
