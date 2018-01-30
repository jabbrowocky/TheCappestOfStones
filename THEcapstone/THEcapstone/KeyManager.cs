using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


namespace THEcapstone
{
    public class KeyManager
    {
        public string SendGridKey { get; set; }
        public KeyManager()
        {
            SetKeys();
        }
        public void SetKeys()
        {
            JObject keyObject = JObject.Parse(File.ReadAllText(@"C:\Users\DalekMyBalls\Desktop\DevCodeCamp\aspdotnet\TheCappestOfStones\THEcapstone\THEcapstone\Json\Keys.Json"));
            SendGridKey = keyObject.GetValue("SendGridKey").ToString();
        }
    }
}