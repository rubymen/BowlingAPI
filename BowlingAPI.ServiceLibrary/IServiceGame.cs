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
        [WebInvoke(Method = "POST", UriTemplate = "lane")]
        [OperationContract]
        void assignToLane(game g);

        [WebGet(UriTemplate = "{id}")]
        [OperationContract]
        game find(string id);

        [WebGet(UriTemplate = "")]
        [OperationContract]
        List<game> findAll();
    }
}
