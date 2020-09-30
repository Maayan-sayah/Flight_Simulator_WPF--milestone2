using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

class AirplanViewModel : INotifyPropertyChanged
{
    
    //public bool connection = false; 
    private static Mutex mutex = new Mutex(); 
    public event PropertyChangedEventHandler PropertyChanged;
    private AirplaneModel model;
    public AirplanViewModel(AirplaneModel m)
    {
        this.model = m;
        model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged("vm_" + e.PropertyName);
        };
    }

    public void NotifyPropertyChanged(string propName)
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    public double vm_Throttle
    {
        get { return this.model.Throttle; }
        set
        {
            this.model.Throttle = value;
            model.moveSThrottle(value);
        }
    }
    public double vm_Aileron { get { return this.model.Aileron;  }
        set
        {
            this.model.Aileron = value;
            model.moveSAileron(value);   
        }
    }

    public double vm_Elevator { get => this.model.Elevator; set { this.model.Rudder = value; } }
    public double vm_Rudder { get { return this.model.Rudder; } set { this.model.Rudder = value;  } }
    
    public double vm_Latitude { get { return this.model.Latitude; } }
    public double vm_Longtitude { get { return this.model.Longtitude; } }
    public double vm_Air_speed { get { return this.model.Air_speed; } }

    public double vm_Altitude { get { return this.model.Altitude; } }
    public double vm_Roll { get { return this.model.Roll; } }
    public double vm_Pitch { get { return this.model.Pitch; } }

    public double vm_Altimeter { get { return this.model.Altimeter; } }
    public double vm_Heading
    {
        get { return this.model.Heading; }
    }
    public double vm_Ground_speed
    {
        get { return this.model.Ground_speed; }
    }
    public double vm_Vertical_speed
    {
        get { return this.model.Vertical_speed; }
    }

    public string vm_Location
    {
        get {  return this.model.Latitude + ","+this.model.Longtitude+",0.00";  }

    }

    public string vm_Error
    {
        get { return this.model.Error; }
    }

    public void connect(string ip,string port)
    {
        try
        {
            this.model.SetIsClientConcted(ip, port);  
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
        
    }

    public void stopandrun()
    {
        this.model.SetIsProgremRun();
    }
}


