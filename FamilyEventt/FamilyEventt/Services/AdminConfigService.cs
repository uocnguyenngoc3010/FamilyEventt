using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using Newtonsoft.Json;
using System.Text.Json;

namespace FamilyEventt.Services
{
    public class AdminConfigService :IAdminConfig
    {
        public AdminConfigService() { }
        public AdminConfig GetConfig()
        {
            AdminConfig adminConfig = new AdminConfig();

            string filename = "adminConfig.json";

            using (StreamReader sr = File.OpenText(filename))
            {
                var obj = sr.ReadToEnd();
                adminConfig = JsonConvert.DeserializeObject<AdminConfig>(obj);
            }

            return adminConfig;
        }

        public AdminConfig ChangeRule(AdminConfig config)
        {
            AdminConfig adminConfig = new AdminConfig();

            string filename = "adminConfig.json";

            using (StreamReader sr = File.OpenText(filename))
            {
                var obj = sr.ReadToEnd();
                adminConfig = JsonConvert.DeserializeObject<AdminConfig>(obj);
            }

            adminConfig.registDateEvent = config.registDateEvent;
            adminConfig.updateDateEvent = config.updateDateEvent;
            adminConfig.email = config.email;
            adminConfig.phone= config.phone;

            using(StreamWriter sw = File.CreateText(filename))
            {
                var admindata = JsonConvert.SerializeObject(adminConfig);
                sw.WriteLine(admindata);
            }

            return adminConfig;
        }
    }
}
