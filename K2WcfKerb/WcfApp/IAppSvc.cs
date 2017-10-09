using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAppSvc
    {
        // TODO: Add your service operations here
        List<K2UserInfo> GetUsers();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    //DisplayName="Denallix Administrator" Manager="DENALLIX\Jonno" Email="administrator@denallix.com" Fqn="K2:DENALLIX\Administrator" Username="DENALLIX\Administrator
    [DataContract]
    public class K2UserInfo
    {
        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string Manager { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Fqn { get; set; }

        [DataMember]
        public string Username { get; set; }

    }
}
