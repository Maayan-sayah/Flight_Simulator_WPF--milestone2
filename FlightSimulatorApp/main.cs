//using System;
//using System.Net.Sockets;
//using System.Text;


//class main
//{
//    static void Main(string[] args)
//    {
//        //AirplanViewModel A = new AirplanViewModel(new MyFlightSimulator());
//        AirplaneModel A = new MyFlightSimulator();
//        A.connect("127.0.0.1", 5402);
//        A.start();
//        //byte[] read = Encoding.ASCII.GetBytes("get /controls/flight/rudder\n"
//        //    + "get /controls/engines/current-engine/throttle\n");
//        //t.GetStream().Write(read, 0, read.Length);
//        //byte[] buffer = new byte[1024];
//        //t.GetStream().Read(buffer, 0, 1024);
//        //string data = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
//        //Console.WriteLine(data);
//        ////Console.WriteLine("end");
//    }
//}