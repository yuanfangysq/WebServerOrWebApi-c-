using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserInfoController : ApiController

    {
        // 查 api/userinfo
        public IHttpActionResult Get() //如果采用Get方式，使用复杂类型接收的话，需要在参数前面加[FromUri]
        {
            T_UserInfo tl = new T_UserInfo() {Id = 1, Sex = "女"};

            return Json<T_UserInfo>(tl);
        }
        //dynamic
        //用PostMan调试
        [HttpPost]
        public IHttpActionResult AddData(dynamic obj) //obj的值是一个Josn对象 {"Id": 4, "Name": "张三" }
        {
            var id = obj.Id.Value; 
            var name = obj.Name.Value;

            if (id == 123456)
            {
                T_UserInfo tl = new T_UserInfo() { Id = 1, Sex = "成功",Message="Api调用成功" };
                return Json<T_UserInfo>(tl);
            }

            return Json<int>(1);


        }


        class T_UserInfo
        {
            public int Id { get; set; }
            public string Sex { get; set; }

            public string Message{ get; set; }
        }
    }
}