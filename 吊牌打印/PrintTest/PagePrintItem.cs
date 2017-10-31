using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTest
{
    class PagePrintItem
    {
        private Dictionary<string, int> item = new Dictionary<string, int>();
        public void ItemAdd(string key)
        {
            if (item.ContainsKey(key))
                item[key] = item[key] + 1;
            else
                item.Add(key, 1);
        }
        public Dictionary<string, int> GetAll()
        {
            return item;
        }

    }
    class PageLabelinfo
    {
        public string info = "";
        public Dictionary<int, PagePrintItem> labels = new Dictionary<int, PagePrintItem>();
        public PageLabelinfo(int count)
        {
            for (int i = 0; i < count; i++)
                labels.Add(i, new PagePrintItem());
        }
       
        public void label(int postion, string key)
        {
            PagePrintItem _item = labels[postion];
            _item.ItemAdd(key);
        }
        public Dictionary<int, PagePrintItem> GetAll()
        {
            return labels;
        }
    }
}
