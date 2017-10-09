using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WcfApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AppSvc" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AppSvc.svc or AppSvc.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AppSvc : IAppSvc
    {
        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public List<K2UserInfo> GetUsers()
        {
            K2UserInfo ui1 = new K2UserInfo()
            {
                DisplayName = "Denallix Administrator",
                Manager = WindowsIdentity.GetCurrent().Name,
                Email = "administrator@denallix.com",
                Fqn = "K2:DENALLIX\\Administrator",
                Username = "DENALLIX\\Administrator"
            };
            K2UserInfo ui2 = new K2UserInfo()
            {
                DisplayName = "Mike Talley",
                Manager = WindowsIdentity.GetCurrent().Name,
                Email = "Mike@denallix.com",
                Fqn = "K2:DENALLIX\\Mike",
                Username = "DENALLIX\\Mike"
            };
            List<K2UserInfo> ret = new List<K2UserInfo>() { ui1, ui2 };

            try
            {
                var client = new K2RestSvcRef.IdentityServiceClient();
                //https://k2.denallix.com/K2Services/REST.svc/Identity/Users
                client.Endpoint.Address = new EndpointAddress("https://k2.denallix.com/K2Services/REST.svc");
                var tt = client.GetAllUsers();
                if (tt?.Length > 0)
                {
                    tt.ToList().ForEach(x => ret.Add(new K2UserInfo()
                    {
                        DisplayName = x.DisplayName,
                        Email = x.Email,
                        Fqn = x.Fqn,
                        Manager = x.Manager,
                        Username = x.Username
                    }));
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ret;
        }
    }
}
