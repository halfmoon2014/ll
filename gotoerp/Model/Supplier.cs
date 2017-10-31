using System;
namespace Model
{
    /// <summary>
    /// testsupplier:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Supplier
    {
        public Supplier()
        { }
        #region Model
        private int _id;
        private string _user_name = "";
        private string _password = "";
        private string _role_id = "";
        private int _is_usable = 0;
        private string _real_name = "";
        private string _email = "";
        private string _product = "";
        private string _address = "";
        private string _store_company = "";
        private string _handset = "";
        private string _phone = "";
        private int _franchiser_supplier = 0;
        private DateTime _post_data = DateTime.Now;
        private string _ip = "";
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string role_id
        {
            set { _role_id = value; }
            get { return _role_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int is_usable
        {
            set { _is_usable = value; }
            get { return _is_usable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string real_name
        {
            set { _real_name = value; }
            get { return _real_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string product
        {
            set { _product = value; }
            get { return _product; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string store_company
        {
            set { _store_company = value; }
            get { return _store_company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string handset
        {
            set { _handset = value; }
            get { return _handset; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int franchiser_supplier
        {
            set { _franchiser_supplier = value; }
            get { return _franchiser_supplier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime post_data
        {
            set { _post_data = value; }
            get { return _post_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ip
        {
            set { _ip = value; }
            get { return _ip; }
        }
        #endregion Model

    }
}

