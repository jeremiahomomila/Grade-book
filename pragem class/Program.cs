using System;
using System.Collections.Generic;

namespace pragem
{
    public delegate void HelloMessageDelegates(string messaage);
    class Program
    {
        static void Main(string[] args)
        {
            HelloMessageDelegates Del = new HelloMessageDelegates(Hello);
            Del("Hello World");
        }

        public static void Hello(string StrMessage)
        {
            Console.WriteLine(StrMessage);
        }
        
    }
    

    
  

}
