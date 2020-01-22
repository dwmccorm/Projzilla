using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Diagnostics;
using Microsoft.Win32;

namespace ProjectBugzilla
{
    public class Flex
    {
        private short[] _key = new short[LEN];
        private string _name = "";
        private string _email = "";
        private string _company = "";
        private const int LEN = 322;
        private const string regkey = "f7a6c899-2eef-4d98-9191-6af69f5990ed";

        #region Flex
        public Flex()
        {
            CallHome();
        }
        public Flex(string file)
        {
            CallHome();
            Load(file);
        }
        #endregion

        #region Accessors
        public string Key
        {
            get
            {
                char[] retval = new char[LEN];
                for (int i = 0; i < LEN; i++)
                {
                    retval[i] = (char)_key[i];
                }
                return(new String(retval));
            }
        }
        public string Email
        {
            get
            {
                return (_email);
            }
        }
        public string Name
        {
            get
            {
                return (_name);
            }
        }
        public string Company
        {
            get
            {
                return (_company);
            }
        }
        #endregion

        #region CallHome
        private void CallHome()
        {
            string comp = System.Web.HttpUtility.HtmlEncode(System.Windows.Forms.SystemInformation.ComputerName);
            string dom = System.Web.HttpUtility.HtmlEncode(System.Windows.Forms.SystemInformation.UserDomainName);
            string usr = System.Web.HttpUtility.HtmlEncode(System.Windows.Forms.SystemInformation.UserName);

            HTTPPost("http://www.projzilla.com/flex/flex.php", "comp=" + comp + "&dom=" + dom + "&usr=" + usr);
        }
        #endregion

        #region HTTPPost
        private string HTTPPost(string uri, string parameters)
        {
            try
            {
                // parameters: name1=value1&name2=value2	
                WebRequest webRequest = WebRequest.Create(uri);
                //string ProxyString = 
                //   System.Configuration.ConfigurationManager.AppSettings
                //   [GetConfigKey("proxy")];
                //webRequest.Proxy = new WebProxy (ProxyString, true);
                //Commenting out above required change to App.Config
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                byte[] bytes = Encoding.ASCII.GetBytes(parameters);
                Stream os = null;
                try
                { // send the Post
                    webRequest.ContentLength = bytes.Length;   //Count bytes to send
                    os = webRequest.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);         //Send it
                }
                catch (WebException)
                {
                    return null;
                }
                finally
                {
                    if (os != null)
                    {
                        os.Close();
                    }
                }

                try
                { // get the response
                    WebResponse webResponse = webRequest.GetResponse();
                    if (webResponse == null)
                    { return null; }
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                    return sr.ReadToEnd().Trim();
                }
                catch (WebException)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        } // end HttpPost 
        #endregion

        #region Init
        public void Load(string file)
        {
            string stringKey;
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = null; 
            doc.Load(file);
            XmlNode node = doc.SelectSingleNode("/license");
            stringKey = node.SelectNodes("key")[0].InnerText;
            _name = node.SelectNodes("name")[0].InnerText;
            _email = node.SelectNodes("email")[0].InnerText;
            _company = node.SelectNodes("company")[0].InnerText;

            for (int i = 0; i < LEN; i++)
            {
                int value = Convert.ToInt32(stringKey.Substring(i*2,2), 16);
                // Get the character corresponding to the integral value.
                _key[i] = (short) value;
            }
        }
        #endregion

        #region IsTrialLicense
        public bool IsTrialLicense()
        {
            string keyLocation = "SOFTWARE\\" + regkey;
            RegistryKey myKey;
            
            myKey = Registry.LocalMachine.OpenSubKey(keyLocation, false);
            if (null == myKey)
            {
                myKey = Registry.LocalMachine.CreateSubKey(keyLocation);
                DateTime exp = System.DateTime.Now;
                exp = exp.AddDays(15);
                myKey.SetValue("Install", exp.ToString());
                return (true);
            }

            string myValue = (string)myKey.GetValue("Install");
            string nowStr = System.DateTime.Now.ToString();
            return(System.DateTime.Compare(Convert.ToDateTime(myValue),System.DateTime.Now) >= 0);
        }   
        #endregion

        #region TrialDaysLeft
        public int TrialDaysLeft()
        {
            RegistryKey myKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\" + regkey);
            string myValue = (string)myKey.GetValue("Install");
            TimeSpan span = Convert.ToDateTime(myValue) - System.DateTime.Now;
            if (span.TotalDays < 0)
            {
                return 0;
            }
            else
            {
                return ((int) span.TotalDays);
            }
        }
        #endregion

        #region IsPermanentLicense
        public bool IsPermanentLicense()
        {
            Debug.Assert(null != Email);

            // Need an email address to have a permantenet licnese.
            if (null == Email)
                return (false);

            short[] priv = new short[LEN] 
                {0xE9,0xCD,0x30,0x9C,0x52,0x9F,0x42,0x52,0xA6,0x36,
		        0x4B,0x1A,0x00,0x2F,0x2C,0x5F,0x81,0xD7,0x4D,0x33,
		        0xBF,0x48,0xFF,0x8E,0x12,0xF6,0x30,0x34,0x94,0x0A,
		        0x70,0x35,0x46,0x5B,0x1F,0x59,0xDE,0x4D,0xCA,0xB3,
		        0x46,0xD7,0x48,0xD1,0x1C,0xF3,0x8D,0x58,0xF8,0x59,
		        0x25,0xB1,0x97,0x45,0xB2,0xB6,0x57,0x53,0xE6,0xD1,
		        0x09,0x30,0x16,0x6E,0x7D,0xA1,0xD8,0x3D,0x11,0x4C,
		        0xDC,0xAC,0xAD,0x99,0x96,0x24,0xC0,0x10,0x67,0xE8,
		        0xBF,0x48,0xFF,0x8E,0x12,0xF6,0x30,0x34,0x94,0x0A,
		        0xD1,0x8D,0x46,0xBC,0x82,0x45,0xDF,0xA2,0xD5,0xD6,
		        0x7A,0x9E,0xC1,0x10,0xEA,0x45,0xDF,0xA2,0xD5,0xD6, 
		        0xBF,0x48,0xFF,0x8E,0x12,0xF6,0x30,0x34,0x94,0x0A,
		        0x25,0xB1,0x97,0x45,0xB2,0xB6,0x57,0x53,0xE6,0xD1,
		        0x7A,0x9E,0xC1,0x10,0xEA,0x45,0xDF,0xA2,0xD5,0xD6, 
		        0xBF,0x48,0xFF,0x8E,0x12,0xF6,0x30,0x34,0x94,0x0A,
		        0xBF,0x48,0xFF,0x8E,0x12,0xF6,0x30,0x34,0x94,0x0A,
		        0xD1,0x8D,0x46,0xBC,0x82,0x45,0xDF,0xA2,0xD5,0xD6,
		        0x4B,0x1A,0x00,0x2F,0x2C,0x5F,0x81,0xD7,0x4D,0x33,
		        0x0D,0x42,0xED,0xF6,0x52,0x1D,0x4B,0xC3,0x83,0x7E,
		        0x8B,0x3B,0x23,0xAB,0xEF,0xAC,0xFC,0x80,0x83,0xCD,
		        0x8B,0x3B,0x23,0xAB,0xEF,0xAC,0xFC,0x80,0x83,0xCD,
		        0x0D,0x42,0xED,0xF6,0x52,0x1D,0x4B,0xC3,0x83,0x7E,
		        0x58,0x43,0x46,0x83,0xC8,0xCF,0x91,0x48,0xEF,0x1E,
		        0xBF,0x48,0xFF,0x8E,0x12,0xF6,0x30,0x34,0x94,0x0A,
		        0x0D,0x42,0xED,0xF6,0x52,0x1D,0x4B,0xC3,0x83,0x7E,
		        0x7A,0x9E,0xC1,0x10,0xEA,0x45,0xDF,0xA2,0xD5,0xD6, 
		        0xBF,0x48,0xFF,0x8E,0x12,0xF6,0x30,0x34,0x94,0x0A,
		        0xD1,0x8D,0x46,0xBC,0x82,0x45,0xDF,0xA2,0xD5,0xD6,
		        0x4B,0x1A,0x00,0x2F,0x2C,0x5F,0x81,0xD7,0x4D,0x33,
		        0x0D,0x42,0xED,0xF6,0x52,0x1D,0x4B,0xC3,0x83,0x7E,
		        0x8B,0x3B,0x23,0xAB,0xEF,0xAC,0xFC,0x80,0x83,0xCD,
		        0x58,0x43,0x46,0x83,0xC8,0xCF,0x91,0x48,0xEF,0x1E,
		        0x2D,0x00};

            string repeatEmail = "";
            while (repeatEmail.Length < LEN)
            {
                repeatEmail += repeatEmail + Email;
            }

            char[] decode = new char[LEN];
            int a, b, c = 0;
            for (int i = 0; i < (LEN-1); i++)
            {
                a = (short) _key[i];
                b = (short) priv[i];
                c = (0x100 + a - b) % 0x100;
                decode[i] = (char) c;
                if (repeatEmail[i] != decode[i])
                    return (false);
            }
            return (true);
        }
        #endregion
    }
}