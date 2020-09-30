using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

interface AirplaneModel : INotifyPropertyChanged
{
    void connect(string ip, string port);
    void disconnect();

    void start();

    bool ISClientConcted
    {
        get;
    }
    void SetIsProgremRun();

    bool ISProgremRun
    {
        get;
    }
    string Error
    {
        get;
        set;
    }
    void SetIsClientConcted(string ip,string port);
    void moveSThrottle(double value);
    void moveSAileron(double value);
    double Throttle
    {
        get;
        set;
    }
    double Aileron
    {
        get;
        set;
    }

     double Elevator { get; set; }

     double Rudder { get; set; }

     double Latitude { get; set; }

     double Longtitude { get; set; }

     double Air_speed { get; set; }

     double Altitude { get; set; }

     double Roll { get; set; } 

     double Pitch { get; set; }

     double Altimeter { get; set; }

     double Heading { get; set; }

     double Ground_speed { get; set; }

     double Vertical_speed { get; set; }

}

