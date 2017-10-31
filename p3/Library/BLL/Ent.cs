using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BLL
{
    /// <summary>
    /// BLL入口
    /// </summary>
    public class Ent
    {        
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool userLogin(string userName,string passWord)
        {
            Login log = new Login();
            return log.userLogin(userName, passWord);
        }
    }
}
