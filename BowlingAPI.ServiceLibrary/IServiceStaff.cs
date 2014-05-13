using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingService.Business;
using System.ServiceModel;

namespace BowlingAPI.ServiceLibrary
{
    [ServiceContract]
    public interface IServiceStaff
    {
        [OperationContract]
        game createGame(staff s);

        [OperationContract]
        void addPlayer(staff s, game g, player p);

        [OperationContract]
        void removePlayer(staff s, game g, player p);

        [OperationContract]
        void startGame(staff s, game g);

        [OperationContract]
        void cancelGame(staff s, game g);

        [OperationContract]
        bool connect(staff s, string pseudo, string password);

        [OperationContract]
        staff find(int id);

        [OperationContract]
        List<staff> findAll();
    }
}
