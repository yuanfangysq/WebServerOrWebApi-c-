using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MySoapHeader 的摘要说明
/// </summary>
public class MySoapHeader : System.Web.Services.Protocols.SoapHeader

{
   
     public string UserName { get; set; }

    //WebServices访问密码
    public string Password { get; set; }


    public MySoapHeader()
    {
        //在此处添加构造函数逻辑
    }
    public MySoapHeader(string uname, string upassword)
    {
        init(uname, upassword);
    }

    private void init(string uname, string upassword)
    {
        this.UserName = uname;
        this.Password = upassword;

    }

    //验证用户是否有权访问内部接口
    public bool isValid(string uname, string upassword, out string msg)
    {
        msg = "";
        if (uname == "admin" && upassword == "123456")
        {
            return true;
        }
        else
        {
            msg = "对不起，你无权调用此WebServices";
            return false;

        }

    }
    //验证用户是否有权访问外部接口
    public bool isValid(out string msg)
    {
        return isValid(this.UserName, this.Password, out msg);
    }
}


