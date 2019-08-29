using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;


namespace Nextech
{
    public partial class HackerNews : System.Web.UI.Page
    {
         public static string newestStoryID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNewestStoryID();
                GetNewestStory(newestStoryID);
            }            
        }

        private void GetNewestStory(string StoryID)
        {
            string strURL = string.Format("https://hacker-news.firebaseio.com/v0/item/{0}.json", StoryID);

            WebRequest requestObject = WebRequest.Create(strURL);
            requestObject.Method = "GET";

            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();
            using (Stream stNews = responseObject.GetResponseStream())
            {
                StreamReader srNews = new StreamReader(stNews);
                string strNews = srNews.ReadToEnd();
                HackerProperty results = JsonConvert.DeserializeObject<HackerProperty>(strNews);
                if (results != null)
                {
                    hlTitle.Text = results.Title;
                    hlTitle.NavigateUrl = results.Url;
                    lblAuthor.Text = results.By;
                }
                else
                {
                    hlTitle.Text = "Newest Story doesn't have Title Yet";
                     lblAuthor.Text = "Newest Story doesn't have Author Yet";
                }             
            }
           

        }
        /*Get the newest story ID which will be pass to get the Story later*/
        private void GetNewestStoryID()
        {
            string strURL = string.Format("https://hacker-news.firebaseio.com/v0/newstories.json");

            WebRequest requestObject = WebRequest.Create(strURL);
            requestObject.Method = "GET";

            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();

            using (Stream streamData = responseObject.GetResponseStream())
            {
                StreamReader srData = new StreamReader(streamData);
                string strData = srData.ReadToEnd();

                List<int> results = JsonConvert.DeserializeObject<List<int>>(strData);
                newestStoryID = results[0].ToString();

                //string[] array = strData.Split(',');
                //newestStoryID = array[0].Substring(1);
                srData.Close();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {

            GetNewestStoryID();
            GetNewestStory(newestStoryID);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}