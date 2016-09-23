using KcptunLauncher.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace KcptunLauncher
{
    public class Configuration
    {
        [JsonIgnore]
        public static string CONFIG_FILE_NAME = "config.json";

        [JsonIgnore]
        public static string CONFIG_FILE_PATH = AppDomain.CurrentDomain.BaseDirectory + @"\" + CONFIG_FILE_NAME;

        [JsonProperty(PropertyName = "servers", NullValueHandling = NullValueHandling.Ignore)]
        public static List<Server> Servers;

        [JsonProperty(PropertyName = "enabledServer", NullValueHandling = NullValueHandling.Ignore)]
        public static List<string> EnabledServerList;

        public static JObject GetConfigFile()
        {
            try
            {
                using (StreamReader reader = File.OpenText(CONFIG_FILE_PATH))
                {
                    return (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return null;
            }
        }

        public static void Load()
        {
            if (Servers == null)
            {
                Servers = new List<Server>();
            }

            try
            {
                if (!File.Exists(CONFIG_FILE_PATH))
                {
                    File.Create(CONFIG_FILE_PATH).Close();
                    SaveConfigFile(new JObject()
                    {
                        ["servers"] = new JArray(),
                        ["enabledServer"] = new JArray()
                    });
                }

                using (StreamReader reader = File.OpenText(CONFIG_FILE_PATH))
                {
                    JObject jObj = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                    if (jObj["servers"] != null)
                    {
                        JArray jArr = jObj["servers"] as JArray;
                        if (jArr == null)
                        {
                            jObj.Remove("servers");
                            jObj.Add("servers", new JArray());
                        }
                        Servers = JsonConvert.DeserializeObject<List<Server>>(jObj["servers"].ToString());
                    }

                    if (jObj["enabledServer"] != null)
                    {
                        JArray enableServerArrray = jObj["enabledServer"] as JArray;
                        if (enableServerArrray == null)
                        {
                            jObj.Remove("enabledServer");
                            jObj.Add("enabledServer", new JArray());
                        }
                        EnabledServerList = JsonConvert.DeserializeObject<List<string>>(jObj["enabledServer"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public static void SaveConfigFile(JObject cfgJObj)
        {
            using (StreamWriter sw = new StreamWriter(File.Open(CONFIG_FILE_PATH, FileMode.Create)))
            {
                string jsonString = JsonConvert.SerializeObject(cfgJObj, Formatting.Indented);
                sw.Write(jsonString);
                sw.Flush();
                sw.Close();
            }
        }

        public static void UpdateEnabledServerName(string serverName, string newServerName)
        {
            JObject cfgJObj = GetConfigFile();
            for (int i = 0, n = (cfgJObj["enabledServer"] as JArray).Count; i < n; i++)
            {
                if ((cfgJObj["enabledServer"] as JArray)[i].ToString().Equals(serverName))
                {
                    (cfgJObj["enabledServer"] as JArray)[i] = newServerName;
                    SaveConfigFile(cfgJObj);
                    break;
                }
            }
        }

        public static void UpdateEnabledServerList()
        {
            JObject cfgJObj = GetConfigFile();
            cfgJObj.Remove("enabledServer");
            JArray eslJArr = new JArray();
            if (EnabledServerList.Count > 0)
                foreach (string enabledServer in EnabledServerList)
                    eslJArr.Add(enabledServer);
            cfgJObj.Add("enabledServer", eslJArr);
            SaveConfigFile(cfgJObj);
        }

        public static void AddServer(Server server)
        {
            JObject cfgJObj = GetConfigFile();
            (cfgJObj["servers"] as JArray).Add(JObject.Parse(JsonConvert.SerializeObject(server)));
            SaveConfigFile(cfgJObj);
            Servers.Add(server);
        }

        public static void RemoveServer(Server server)
        {
            JObject cfgJObj = GetConfigFile();
            if (cfgJObj["servers"] != null)
            {
                foreach (JObject jObj in (cfgJObj["servers"] as JArray))
                {
                    if (Equals(jObj["name"].ToString(), server.Name))
                    {
                        (cfgJObj["servers"] as JArray).Remove(jObj);
                        break;
                    }
                }
            }
            SaveConfigFile(cfgJObj);
            Servers.Remove(server);
        }

        public static void NotifyServersChanged()
        {
            JObject cfgJObj = GetConfigFile();
            if (cfgJObj["servers"] != null)
            {
                cfgJObj["servers"] = JArray.Parse(JsonConvert.SerializeObject(Servers));
            }
            else
            {
                cfgJObj.Add("servers", JArray.Parse(JsonConvert.SerializeObject(Servers)));
            }
            SaveConfigFile(cfgJObj);
        }
    }
}
