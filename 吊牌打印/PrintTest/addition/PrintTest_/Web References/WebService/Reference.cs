﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.34209 版自动生成。
// 
#pragma warning disable 1591

namespace PrintTest.WebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="LabelPrintSoap", Namespace="http://tempuri.org/")]
    public partial class LabelPrint : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback listOperationCompleted;
        
        private System.Threading.SendOrPostCallback orderDetailOperationCompleted;
        
        private System.Threading.SendOrPostCallback orderItemOperationCompleted;
        
        private System.Threading.SendOrPostCallback ItemInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback BarCodeOrderIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback BarCodeDetailOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public LabelPrint() {
            this.Url = global::PrintTest.Properties.Settings.Default.PrintTest_WebService_LabelPrint;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event listCompletedEventHandler listCompleted;
        
        /// <remarks/>
        public event orderDetailCompletedEventHandler orderDetailCompleted;
        
        /// <remarks/>
        public event orderItemCompletedEventHandler orderItemCompleted;
        
        /// <remarks/>
        public event ItemInfoCompletedEventHandler ItemInfoCompleted;
        
        /// <remarks/>
        public event BarCodeOrderIdCompletedEventHandler BarCodeOrderIdCompleted;
        
        /// <remarks/>
        public event BarCodeDetailCompletedEventHandler BarCodeDetailCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/list", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string list(System.DateTime datestart, System.DateTime dateend) {
            object[] results = this.Invoke("list", new object[] {
                        datestart,
                        dateend});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void listAsync(System.DateTime datestart, System.DateTime dateend) {
            this.listAsync(datestart, dateend, null);
        }
        
        /// <remarks/>
        public void listAsync(System.DateTime datestart, System.DateTime dateend, object userState) {
            if ((this.listOperationCompleted == null)) {
                this.listOperationCompleted = new System.Threading.SendOrPostCallback(this.OnlistOperationCompleted);
            }
            this.InvokeAsync("list", new object[] {
                        datestart,
                        dateend}, this.listOperationCompleted, userState);
        }
        
        private void OnlistOperationCompleted(object arg) {
            if ((this.listCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.listCompleted(this, new listCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/orderDetail", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string orderDetail(int id) {
            object[] results = this.Invoke("orderDetail", new object[] {
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void orderDetailAsync(int id) {
            this.orderDetailAsync(id, null);
        }
        
        /// <remarks/>
        public void orderDetailAsync(int id, object userState) {
            if ((this.orderDetailOperationCompleted == null)) {
                this.orderDetailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnorderDetailOperationCompleted);
            }
            this.InvokeAsync("orderDetail", new object[] {
                        id}, this.orderDetailOperationCompleted, userState);
        }
        
        private void OnorderDetailOperationCompleted(object arg) {
            if ((this.orderDetailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.orderDetailCompleted(this, new orderDetailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/orderItem", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string orderItem(int id) {
            object[] results = this.Invoke("orderItem", new object[] {
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void orderItemAsync(int id) {
            this.orderItemAsync(id, null);
        }
        
        /// <remarks/>
        public void orderItemAsync(int id, object userState) {
            if ((this.orderItemOperationCompleted == null)) {
                this.orderItemOperationCompleted = new System.Threading.SendOrPostCallback(this.OnorderItemOperationCompleted);
            }
            this.InvokeAsync("orderItem", new object[] {
                        id}, this.orderItemOperationCompleted, userState);
        }
        
        private void OnorderItemOperationCompleted(object arg) {
            if ((this.orderItemCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.orderItemCompleted(this, new orderItemCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ItemInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ItemInfo(int id) {
            object[] results = this.Invoke("ItemInfo", new object[] {
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ItemInfoAsync(int id) {
            this.ItemInfoAsync(id, null);
        }
        
        /// <remarks/>
        public void ItemInfoAsync(int id, object userState) {
            if ((this.ItemInfoOperationCompleted == null)) {
                this.ItemInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnItemInfoOperationCompleted);
            }
            this.InvokeAsync("ItemInfo", new object[] {
                        id}, this.ItemInfoOperationCompleted, userState);
        }
        
        private void OnItemInfoOperationCompleted(object arg) {
            if ((this.ItemInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ItemInfoCompleted(this, new ItemInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BarCodeOrderId", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string BarCodeOrderId(string barcode) {
            object[] results = this.Invoke("BarCodeOrderId", new object[] {
                        barcode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void BarCodeOrderIdAsync(string barcode) {
            this.BarCodeOrderIdAsync(barcode, null);
        }
        
        /// <remarks/>
        public void BarCodeOrderIdAsync(string barcode, object userState) {
            if ((this.BarCodeOrderIdOperationCompleted == null)) {
                this.BarCodeOrderIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBarCodeOrderIdOperationCompleted);
            }
            this.InvokeAsync("BarCodeOrderId", new object[] {
                        barcode}, this.BarCodeOrderIdOperationCompleted, userState);
        }
        
        private void OnBarCodeOrderIdOperationCompleted(object arg) {
            if ((this.BarCodeOrderIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BarCodeOrderIdCompleted(this, new BarCodeOrderIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BarCodeDetail", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string BarCodeDetail(string barcode) {
            object[] results = this.Invoke("BarCodeDetail", new object[] {
                        barcode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void BarCodeDetailAsync(string barcode) {
            this.BarCodeDetailAsync(barcode, null);
        }
        
        /// <remarks/>
        public void BarCodeDetailAsync(string barcode, object userState) {
            if ((this.BarCodeDetailOperationCompleted == null)) {
                this.BarCodeDetailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBarCodeDetailOperationCompleted);
            }
            this.InvokeAsync("BarCodeDetail", new object[] {
                        barcode}, this.BarCodeDetailOperationCompleted, userState);
        }
        
        private void OnBarCodeDetailOperationCompleted(object arg) {
            if ((this.BarCodeDetailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BarCodeDetailCompleted(this, new BarCodeDetailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void listCompletedEventHandler(object sender, listCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class listCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal listCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void orderDetailCompletedEventHandler(object sender, orderDetailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class orderDetailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal orderDetailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void orderItemCompletedEventHandler(object sender, orderItemCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class orderItemCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal orderItemCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void ItemInfoCompletedEventHandler(object sender, ItemInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ItemInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ItemInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void BarCodeOrderIdCompletedEventHandler(object sender, BarCodeOrderIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BarCodeOrderIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BarCodeOrderIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void BarCodeDetailCompletedEventHandler(object sender, BarCodeDetailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BarCodeDetailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BarCodeDetailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591