using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace InterFaceDemo
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

#if  true
         DBOperation dBOperation = new DBOperation();
        [WebMethod(Description = "通过ID查找")]
        public int[] selectAllCaroInfor(int Phone)
        {
            return dBOperation.selectAllCaroInfor(Phone).ToArray();
        }
        [WebMethod(Description = "增加一条信息")]
        public bool insertCargonInfo(int Phone,int Password)
        {
            return dBOperation.insertCargonInfo(Phone, Password);
        }
        [WebMethod(Description = "删除一条信息")]
        public bool deleteCargoInfo(int Phone)
        {
            return dBOperation.deletdCargonInfo(Phone);
        }
        [WebMethod(Description = "增加姓名")]
        public bool insertCargonInfo1(string Name, string Adress)
        { 
        return dBOperation.insertCargonInfo1(Name, Adress);
        }

        [WebMethod(Description = "查找")]
        [ScriptMethod(UseHttpGet =true,ResponseFormat =ResponseFormat.Json)]
        public string[] SerachInfo(string Name)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            
            return dBOperation.SerachInfo(Name).ToArray() ;
        }
        
#endif
    }
}
