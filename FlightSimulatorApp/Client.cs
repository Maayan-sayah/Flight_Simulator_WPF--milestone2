using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



class Client
{
    Dictionary<string, string> commandsDic = new Dictionary<string, string>();

    TcpClient tcp;

    private static Mutex mutex = new Mutex();
    void intializeDic()
    {
        commandsDic.Add("throttle", " /controls/engines/current-engine/throttle");
        commandsDic.Add("aileron", " /controls/flight/aileron");
        commandsDic.Add("elevator", " /controls/flight/elevator");
        commandsDic.Add("rudder", " /controls/flight/rudder");
        commandsDic.Add("latitude", " /position/latitude-deg");

        commandsDic.Add("longitude", " /position/longitude-deg");
        commandsDic.Add("air_speed", " /position/latitude-deg");
        commandsDic.Add("altitude", " /instrumentation/gps/indicated-altitude-ft");
        commandsDic.Add("pitch", " /instrumentation/attitude-indicator/internal-pitch-deg");
        commandsDic.Add("altimeter", " /instrumentation/altimeter/indicated-altitude-ft");

        commandsDic.Add("heading", " /instrumentation/heading-indicator/indicated-heading-deg");
        commandsDic.Add("ground_speed", " /instrumentation/gps/indicated-ground-speed-kt");
        commandsDic.Add("vertical_speed", " /instrumentation/gps/indicated-vertical-speed");
        commandsDic.Add("roll", " /instrumentation/attitude-indicator/internal-roll-deg");
    }


    public Client(TcpClient t)
    {
        this.tcp = t;
        intializeDic();
    }

    public string reciveValue(string key)
    {
        string command = commandsDic[key];
        try
        {
            write("get" + command+"\n");
        }
        catch (Exception e)
        {
            throw new Exception("No connection with the server");
        }

        try
        {
            string value = read();
            return value;
        }
        catch (TimeoutException e)
        {
            throw new TimeoutException();
        }
        
    }

    public void sendValue(string key, double value)
    {
        string command = commandsDic[key];
        write("set" + command + value);
        Console.WriteLine("set" + command + value);
        write("get" + command+"\n");

        try
        {
            string tempvalue = read();
        }
        catch (TimeoutException e)
        {
            throw new TimeoutException();
        }

    }

    public string read()
    {
       tcp.ReceiveTimeout = 1000;
        try
        {
            byte[] buffer = new byte[1024];
            tcp.GetStream().Read(buffer, 0, 1024);
            string data = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
            return data;
        }
        catch(IOException e)
        {
            throw new TimeoutException();
        }

    }

    public void write(string send)
    {
        Byte[] sendBytes;
        sendBytes = Encoding.UTF8.GetBytes(send);
        try
        {
            tcp.GetStream().Write(sendBytes, 0, sendBytes.Length);
        }
        catch (IOException e)
        {
            throw new Exception("No connection with the server");
        }
        
    }

}

