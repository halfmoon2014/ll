using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using System.Threading;

namespace eSignage
{

    class borcast
    {
        string tempalte = "{0} {1} 款已做领料计划第{2}床,请及时领料";
        public Queue<BorcastContent> BorcastList = new Queue<BorcastContent>();
        public ManualResetEvent done = new ManualResetEvent(false);
        public bool isExit = false;
        public borcast()
        {
            Thread thread = new Thread(init);
            thread.IsBackground = true;
            thread.Start();   
        }
        public void init()
        {
            //done.Reset();
            run();      
        }
        public void stop()
        {
            isExit = true;
        }
        private void run()
        {
            if (BorcastList.Count > 0)
            {                
                BorcastContent borcast = BorcastList.Dequeue();
                SpeechSynthesizer reader = new SpeechSynthesizer();
                reader.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(reader_SpeakCompleted);
                reader.SpeakAsync(borcast.Content);
                borcast = null;
            }  
            else
            {
                //Console.WriteLine("开始等待");
                BorcastList.Clear();
                done.Reset();
                done.WaitOne();//队列空在这等待
                run();
            }
        }
        public void add(string gp, string goodcode, string cutsn)
        {
            //Console.WriteLine("队列++");
            string content = string.Format(tempalte, gp, goodcode, cutsn);
            BorcastContent cont = new BorcastContent();
            cont.Content = content;
            cont.Times = 0;
            BorcastList.Enqueue(cont);
            done.Set();
        }
        void reader_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            SpeechSynthesizer reader = (SpeechSynthesizer)sender;
            reader.Dispose();
            reader = null;
            run();
        }
    }
}
