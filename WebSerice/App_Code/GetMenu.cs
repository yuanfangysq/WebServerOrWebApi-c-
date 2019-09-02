using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

/// <summary>
/// GetMenu 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
 [System.Web.Script.Services.ScriptService]
public class GetMenu : WebService
{

    public MySoapHeader myheader;


    [WebMethod(Description = "得到报表数据")]
    public string HelloWorld()
    {
        return "菜单2";
    }

    [WebMethod]
    public List<Menu> GetTopMenu()
    {
        return new List<Menu>()
            {
                new Menu{ Mid=1,  Name="双菜鱼头", price=28},
                new Menu{ Mid=2,  Name="香辣虾", price=26},
                new Menu{ Mid=3,  Name="小炒肉", price=15}
            };
    }

    [WebMethod]

    public DataTable GetTopMenu2()
    {
        DataTable da = new DataTable();
        da.TableName = "ceshi";
        da.Columns.Add("ID", typeof(int)).Caption="流水账号";
        da.Columns.Add("SEX", typeof(string)).Caption = "姓名";
        
        da.Rows.Add(1, "杨东");
        da.Rows.Add(2, "杨炎");


        return da;
    }

    [WebMethod (Description="身份验证")]
    [SoapHeader("myheader")]//加入此特性标签的WebService需要验证，不加则为普通WebService无需验证
    public string GetTime()
    {
        string msg = "";

        //验证是否有权访问
        if (myheader.isValid(out msg) == false)
        {
            return msg;
        }

       // 如果有权访问，就返回当前时间
        return DateTime.Now.ToString();

    }

    [WebMethod(Description = "有参数的方法")]
    public DataTable GetValue(String UserName, String Password)
    {
        string msg = "";
        DataTable da = new DataTable();
        da.TableName = "杨东";
        if (UserName == "admin" && Password == "123456")
        {
          
            da.TableName = "ceshi";
            da.Columns.Add("ID", typeof(int)).Caption = "流水账号";
            da.Columns.Add("SEX", typeof(string)).Caption = "姓名";

            da.Rows.Add(1, "杨东");
            da.Rows.Add(2, "杨炎");
            return da;
        }

        return da;
        
    }

}

public class Menu
{
    public int Mid { get; set; }

    public string Name { get; set; }

    public Decimal price { get; set; }
}



