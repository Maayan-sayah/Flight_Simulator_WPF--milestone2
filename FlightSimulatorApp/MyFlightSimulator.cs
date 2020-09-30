using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class MyFlightSimulator : AirplaneModel
{
   
    public event PropertyChangedEventHandler PropertyChanged;
    bool IsClientConcted=false;
    volatile bool IsProgremRun =false;
    TcpClient t;
    Client client;
    private static Mutex mutex = new Mutex();
    private string error;
    public bool ISClientConcted{
        get { return IsClientConcted; }
    }

    public void SetIsClientConcted(string ip,string port)
    {
        try
        {
            connect(ip, port);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        
    }

    public MyFlightSimulator()
    {
        this.t = new TcpClient();
        this.client = new Client(t);

    }
    public bool ISProgremRun
    {
        get { return IsProgremRun; }
    }

    
    public void SetIsProgremRun()
    {
        if (IsProgremRun == true)
        {
            
            IsProgremRun = false;
        }
        else
        {

            IsProgremRun = true;
            start();
  
        }

    }

    public void start()
    {
        new Thread(delegate ()
        {
            while (IsProgremRun)
            {
                mutex.WaitOne();
                string d;
                try
                {
                    d = client.reciveValue("pitch");
                    this.Pitch = Math.Round(Convert.ToDouble(d), 4);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message== "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "pitch value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                
                try
                {
                    d = client.reciveValue("longitude");
                    this.Longtitude = Convert.ToDouble(d);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message == "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "Longtitude value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                
                try
                {
                    d = client.reciveValue("latitude");
                    this.Latitude = Convert.ToDouble(d);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message == "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "Latitude value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                
                try
                {
                    d = client.reciveValue("altitude");
                    this.Altitude = Math.Round(Convert.ToDouble(d),4);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message == "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "Altitude value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                
                try
                {
                    d = client.reciveValue("ground_speed");
                    this.Ground_speed = Math.Round(Convert.ToDouble(d),4);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message == "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "Ground_speed value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                
                try
                {
                    d = client.reciveValue("heading");
                    this.Heading = Math.Round(Convert.ToDouble(d),4);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message == "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "Heading value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                
                try
                {
                    d = client.reciveValue("altimeter");
                    this.Altimeter = Math.Round(Convert.ToDouble(d),4);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message == "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "Altimeter value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                
                try
                {
                    d = client.reciveValue("air_speed");
                    this.Air_speed = Math.Round(Convert.ToDouble(d),4);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message == "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "Air_speed value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                
                try
                {
                    d = client.reciveValue("vertical_speed");
                    this.Vertical_speed = Math.Round(Convert.ToDouble(d),4);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message == "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "Vertical_speed value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                
                try
                {
                    d = client.reciveValue("roll");
                    this.Roll = Math.Round(Convert.ToDouble(d),4);
                }
                catch (TimeoutException e)
                {
                    error = "read from servr take more than 10 sec";
                    NotifyPropertyChanged("Error");
                }
                catch (Exception e)
                {
                    if (e.Message == "No connection with the server")
                    {
                        error = e.Message;
                        SetIsProgremRun();
                    }
                    else
                    {
                        error = "Roll value recive error";
                    }
                    NotifyPropertyChanged("Error");
                }
                mutex.ReleaseMutex();

                Thread.Sleep(250);
            }
        }).Start();
    }

    public void connect(string ip, string port)
    {
        try
        {
            this.t.Connect(ip, Int32.Parse(port));
        }
        catch (System.Net.Sockets.SocketException e)
        {
            throw new Exception("no server to connect to");
        }
        catch (Exception e)
        {
            throw new Exception("couldnt connect with this ip/port");
        }

        start();
    }

    public void disconnect()
    {
        IsProgremRun = true;
        this.t.Close();
    }


    public void moveSThrottle(double value)
    {
        mutex.WaitOne();
        try
        {
            client.sendValue("throttle", value);
        }
        catch (TimeoutException e)
        {
            error = "read from servr take more than 10 sec";
            NotifyPropertyChanged("Error");
        }

        mutex.ReleaseMutex();
    }

    public void moveSAileron(double value)
    {
        mutex.WaitOne();
        try
        {
            client.sendValue("aileron", value);
        }
        catch (TimeoutException e)
        {
            error = "read from servr take more than 10 sec";
            NotifyPropertyChanged("Error");
        }
        mutex.ReleaseMutex();
    }
    public void NotifyPropertyChanged(string propName)
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }


    public string Error
    {
        get
        {
            return this.error;
        }
        set
        {
            error = value;
            NotifyPropertyChanged("Error");
        }
    }
    private double throttle;
    public double Throttle { get { return throttle; }

        set { throttle = value;
            NotifyPropertyChanged("Throttle");
            mutex.WaitOne();
            try
            {
                client.sendValue("throttle", value);
            }
            catch (TimeoutException e)
            {
                error = "read from servr take more than 10 sec";
                NotifyPropertyChanged("Error");
            }
            mutex.ReleaseMutex();
        }
    }

    private double aileron;
    public double Aileron { get { return aileron; } 
        set {  aileron = value;
            NotifyPropertyChanged("Aileron");
            mutex.WaitOne();
            try
            {
                client.sendValue("aileron", value);
            }
            catch (TimeoutException e)
            {
                error = "read from servr take more than 10 sec";
                NotifyPropertyChanged("Error");
            }
            mutex.ReleaseMutex();
        } }

    private double elevator;
    public double Elevator { get { return elevator; } 
        set { elevator = value; 
            NotifyPropertyChanged("Elevator");
            mutex.WaitOne();
            try
            {
                client.sendValue("elevator", value);
            }
            catch (TimeoutException e)
            {
                error = "read from servr take more than 10 sec";
                NotifyPropertyChanged("Error");
            }
            mutex.ReleaseMutex();
        } }

    private double rudder;
    public double Rudder { get { return rudder; } 
        set { rudder = value; 
            NotifyPropertyChanged("Rudder"); 
            mutex.WaitOne();
            try
            {
                client.sendValue("rudder", value);
            }
            catch (TimeoutException e)
            {
                error = "read from servr take more than 10 sec";
                NotifyPropertyChanged("Error");
            }
            mutex.ReleaseMutex();
        } }

    private double latitude;
    public double Latitude { get { return latitude; } 
        set { 
            latitude = value; NotifyPropertyChanged("Location");
            if (value < -90)
            {
                latitude = value+90;
                error = "latitude value smaller than -180";
                NotifyPropertyChanged("Error");
                NotifyPropertyChanged("Location");
            }
            else if (value > 90)
            {

                latitude = value-90;
                error = "latitude value bigger than 180";
                NotifyPropertyChanged("Error");
                NotifyPropertyChanged("Location");
                
            }
            else
            {
                latitude = value;
                NotifyPropertyChanged("Location");
            }
        } }

    private double longtitude;
    public double Longtitude { get { return longtitude; } 
        set {
            if (value < -180)
            {
                longtitude = value + 180;
                error = "longtitude value smaller than -180";
                NotifyPropertyChanged("Error");
                NotifyPropertyChanged("Location");
            }
            else if (value > 180)
            {
                longtitude = value-180;
                error = "longtitude value bigger than 180";
                NotifyPropertyChanged("Error");
                NotifyPropertyChanged("Location");
            }
            else
            {
                longtitude = value;
                NotifyPropertyChanged("Location");
            }
        }
    }

    private double air_speed;
    public double Air_speed
    {
        get { return air_speed; }
        set
        {

            air_speed = value;
            NotifyPropertyChanged("Air_speed");
        }
    }

    private double altitude;
    public double Altitude { get { return altitude; } 
        set
        {
            altitude = value;
            NotifyPropertyChanged("Altitude");
        } }

    private double roll;
    public double Roll { get { return roll; } set
        {
            roll = value;
            NotifyPropertyChanged("Roll"); } }

    private double pitch;
    public double Pitch { get { return pitch; } set
        {
            pitch = value; 
            NotifyPropertyChanged("Pitch");
            
            } 
    }


    private double altimeter;
    public double Altimeter { get { return altimeter; } set
        {
            altimeter = value;
            NotifyPropertyChanged("Altimeter");} }

    private double heading;
    public double Heading { get { return heading; } set
        {
            heading = value;
            NotifyPropertyChanged("Heading"); } }

    private double ground_speed;
    public double Ground_speed { get { return ground_speed; } set
        {
            ground_speed = value;
            NotifyPropertyChanged("Ground_speed"); } }

    private double vertical_speed;
    public double Vertical_speed { get { return vertical_speed; } set
        {
            vertical_speed = value;
            NotifyPropertyChanged("Vertical_speed"); } }
}
