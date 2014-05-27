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
        game createGame(List<player> players);

        [WebInvoke(Method = "POST", UriTemplate = "game/{gId}/add", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        void addPlayer(player p, string gId);

        [WebInvoke(Method = "DELETE", UriTemplate = "{id}")]
        [OperationContract]
        void deletePlayer(string id);

        [WebGet(UriTemplate = "{id}")]
        [OperationContract]
        player find(string id);

        [WebGet(UriTemplate = "")]
        [OperationContract]
        List<player> findAll();

        [OperationContract]
        game findGame(string id);

        [WebInvoke(Method = "PUT", UriTemplate = "players")]
        [OperationContract]
        void updatePlayer(player p);
    }
}
