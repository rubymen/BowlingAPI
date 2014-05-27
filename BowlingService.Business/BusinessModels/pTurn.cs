using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingService.Business
{
    public partial class turn
    {
        public List<@throw> GetThrows()
        {
            var throws = new Repository<@throw>();
            List<@throw> lst = (from t in throws.GetAll()
                                where t.Turn_id == this.Id
                                select t).ToList();

            return lst;
        }
    }
}
