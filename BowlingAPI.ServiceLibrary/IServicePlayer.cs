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
    public interface IServicePlayer 
    {
        [WebInvoke(Method = "POST", UriTemplate = "game/create")]
        [OperationContract]
        game createGame(player p);

        [WebInvoke(Method = "POST", UriTemplate = "create", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        void addPlayer(player currentPlayer, player p);

        [WebInvoke(Method = "DELETE", UriTemplate = "{id}")]
        [OperationContract]
        void deletePlayer(string id);

        [WebGet(UriTemplate = "{id}")]
        [OperationContract]
        player find(string id);

        [WebGet(UriTemplate = "")]
        [OperationContract]
        List<player> findAll();
    }
}
