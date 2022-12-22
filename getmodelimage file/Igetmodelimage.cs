using getmodelimage_file.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace getmodelimage_file
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Igetmodelimage" in both code and config file together.
    [ServiceContract]
    public interface Igetmodelimage
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getfileupload", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<clsViewFile> GetFiles();

    }
}
