using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BowlingService.Business;
using System.ServiceModel.Web;

namespace BowlingAPI.ServiceLibrary
{   
    [ServiceContract]
    public interface IServiceGame
    {
        [OperationContract]
        void assignToLane(int id);

        [WebInvoke(Method = "POST", UriTemplate = "new")]
        [OperationContract]
        game createGame();

        [WebGet(UriTemplate = "recents")]
        [OperationContract]
        List<game> findAllfrom24H();

        [WebGet(UriTemplate = "{id}")]
        [OperationContract]
        game find(string id);

        [WebGet(UriTemplate = "pages/{number}?filter={filter}&param={param}")]
        [OperationContract]
        List<game> findAll(string number, string filter = "", string param = "");

        [WebInvoke(Method = "POST", UriTemplate = "{id}/player")]
        [OperationContract]
        void addPlayer(string id, player p);

        [WebInvoke(Method = "PUT", UriTemplate = "{id}/state")]
        [OperationContract]
        void updateState(string id, string state);
    }
}
