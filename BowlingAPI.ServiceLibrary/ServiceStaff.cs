using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingService.Business;

namespace BowlingAPI.ServiceLibrary
{
    public class ServiceStaff : IServiceStaff
    {
        public game createGame(staff s)
        {
            return s.createGame();
        }

        public void addPlayer(staff s, game g, player p)
        {
            s.addPlayer(g, p);
        }

        public void removePlayer(staff s, game g, player p)
        {
            s.removePlayer(g, p);
        }

        public void startGame(staff s, game g)
        {
            s.startGame(g);
        }

        public void cancelGame(staff s, game g)
        {
            s.cancelGame(g);
        }

        public bool connect(staff s, string pseudo, string password)
        {
            return s.connect(pseudo, password);
        }

        public staff find(int id)
        {
            var staffs = new Repository<staff>();
            return staffs.FindBy(s => s.Id == id).Single();
        }

        public List<staff> findAll()
        {
            var staffs = new Repository<staff>();
            return staffs.GetAll().ToList();
        }
    }
}
