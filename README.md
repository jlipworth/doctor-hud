# doctor-hud
Checkout AlphaReleaseDemo.mov for a step by step demo on how to run with real OpenICE data.

## Run with real openIce data
**OpenICE website certificate has been expired these days. Hello OpenICE might not build on a recent download because of this.**  
**The hello-open-ice-build folder contains a compiled version of Hello OpenICE on MacOS.**
1. Download and install OpenICE and hello-openIce from 
https://www.openice.info/devdocs/-hello-openice.html.
1. Open windows application in Visual Studio, update the ip address variable in Form1.cs line 23 `static string serverIp = "localhost";`to desired server ip in Form1.cs. Update the ip address at line 85 `sock.bind(("10.211.55.2", port))` of open-ice-socket.py to be the server ip.
1. Run hello open ice. Pipe the output to open-ice-socket.py
 `./PATH_TO_HELLOOPENICE_DIR/gradlew ./PATH_TO_HELLOOPENICE_DIR/run | python ./PATH_TO_SCRIPY_DIR/open-ice-socket.py`
1. Open OpenICE supervisor, select "Create a device adapater", set Device Type to "Simulated Multiparameter Monitor", click "Start monitor".
1. Build and run windows application. 

## Run with fake sensor data 
**Because of the inavailability of openICE these days, we build a test mode that generate and broadcast fake sensor data**
1. Uncomment line 99 and comment line 100 of open-ice-socket.py.
1. Open windows application in Visual Studio, update the ip address variable in Form1.cs line 23 `static string serverIp = "localhost";`to desired server ip in Form1.cs. Update the ip address at line 85 `sock.bind(("10.211.55.2", port))` of open-ice-socket.py to be the server ip.
1. Run the script with `python ./PATH_TO_SCRIPY_DIR/open-ice-socket.py`
1. Build and run windows application.
