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
    public interface IServiceLane
    {
        [WebGet(UriTemplate = "{id}/available")]
        [OperationContract]
        bool isAvalaible(string id);

        [WebGet(UriTemplate = "{id}/game")]
        [OperationContract]
        game getCurrentGame(string id);

        [WebGet(UriTemplate = "{id}")]
        [OperationContract]
        lane find(string id);

        [WebGet(UriTemplate = "")]
        [OperationContract]
        List<lane> findAll();
    }
}
