#region XD World Lyric V 2.8
// FileName: toprecipexml.cs
// Author: Dexter Zafra
// Date Created: 5/28/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VGuitar.UI;
using System.Xml;
using System.Text;
using System.IO;
using VGuitar.BL;

public partial class toplyricxml : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;

        //Note: You need to change the domain name "myasp-net.com and ex-designz.net" to your site domain
        Response.Clear();
        Response.ContentType = "text/xml";
        XmlTextWriter objX = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
        objX.WriteStartDocument();
        objX.WriteStartElement("rss");
        objX.WriteAttributeString("version", "2.0");
        objX.WriteStartElement("channel");
        objX.WriteElementString("title", "VGuitar.net những bài hát yêu thích nhất RRS");
        objX.WriteElementString("link", "http://thlb.biz");
        objX.WriteElementString("description", "Lyric database from around the world");
        objX.WriteElementString("copyright", "(c) 2009, thlb.biz");
        objX.WriteElementString("ttl", "10");

        //Get datatable
        IDataReader dr = Blogic.ActionProcedureDataProvider.GetRSSMostPopularLyric;

        //loop through all record, and write XML for each item.
        for (i = 0; i <= 20 - 1; i++)
        {
            dr.Read();
            objX.WriteStartElement("item");
            objX.WriteElementString("title", dr["Name"].ToString());
            objX.WriteElementString("link", "http://thlb.biz?rid=" + (int)dr["ID"]);
            objX.WriteElementString("pubDate", Convert.ToDateTime(dr["Date"]).ToShortDateString());
            objX.WriteEndElement();
        }

        dr.Close();

        //End of XML file
        objX.WriteEndElement();
        objX.WriteEndElement();
        objX.WriteEndDocument();

        //Close the XmlTextWriter object
        objX.Flush();
        objX.Close();
        Response.End();  
    }
}
