using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using LiLanzModel;

namespace PrintTest
{
    class common
    {
        static public Dictionary<string, OrderLabelInfo> List2Dict(List<OrderLabelInfo> Labels)
        {
            Dictionary<string, OrderLabelInfo> DictLabel
            = new Dictionary<string, OrderLabelInfo>();
            foreach (OrderLabelInfo lable in Labels)
            {
                if(!DictLabel.ContainsKey(lable.Sphh))
                    DictLabel.Add(lable.Sphh, lable);
            }
            return DictLabel;
        }
    }
}
