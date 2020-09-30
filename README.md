## **FlightSimulatorWPF**


### **<u>Basic Information:</u>**

In purpose to control "Flight Simulator" we created an WPF program, use MVVM architecture. 
The program sends a command, that passes to the simulator's server . In addition the program also  receives data from an aircraft and responds accordingly.

you have an graphical interface of the cockpit for the operation of an aircraft which response to instructions from the user regarding the rudder and the variouse control surface.
It's look like the picture below:

![screen](https://user-images.githubusercontent.com/60346583/94696703-fef19400-033f-11eb-99c0-13f780d390aa.PNG)

 **<u>Four control surfaces:</u>**

Joystick: Steering wheel - steering wheel direction can be controlled using right and left keys. Elevator - rudder can be controlled using up and down keys.
Sliders: Aileron - balances Throttle - throttle

### **<u>Preparations:</u>**

Download FlightSimulator (Or any other simulator) in the next link- https://flightgear.en.uptodown.com/windows. 
open the simulator, go to Setting, go to Additional Setting and add the next line: "--telnet=socket,in,10,127.0.0.1,5403,tcp --httpd=8080". 


### **<u>Log in:</u>**

In order to log to our programm, a user needs to insert port and ip. 
**note** that if you dont enter suitable details, the connection ill be with ip and port that set by default .

![enter](https://user-images.githubusercontent.com/60346583/94696601-e41f1f80-033f-11eb-89c4-d3d62616ddd9.PNG)

