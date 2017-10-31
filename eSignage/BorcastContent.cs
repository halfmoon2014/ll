using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSignage
{
    public class BorcastContent
    {
        int times;
        /// <summary>
        /// 次数
        /// </summary>
        public int Times
        {
            get { return times; }
            set { times = value; }
        }
        string content;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
