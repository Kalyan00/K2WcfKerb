using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AppSvc" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AppSvc.svc or AppSvc.svc.cs at the Solution Explorer and start debugging.
    public class AppSvc : IAppSvc
    {
        public List<K2UserInfo> GetUsers()
        {
            K2UserInfo ui1 = new K2UserInfo()
            {
                DisplayName = "Denallix Administrator",
                Manager = "DENALLIX\\Jonno",
                Email = "administrator@denallix.com",
                Fqn = "K2:DENALLIX\\Administrator",
                Username = "DENALLIX\\Administrator"
            };
            K2UserInfo ui2 = new K2UserInfo()
            {
                DisplayName = "Mike Talley",
                Manager = "DENALLIX\\Anthony",
                Email = "Mike@denallix.com",
                Fqn = "K2:DENALLIX\\Mike",
                Username = "DENALLIX\\Mike"
            };
            List<K2UserInfo> ret = new List<K2UserInfo>() { ui1, ui2 };
            return ret;
        }
    }
}
