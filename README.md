# doctor-hud
Checkout AlphaReleaseDemo.mov for a step by step demo on how to run with real OpenICE data.

## Run with real OpenICE data
**OpenICE's website SSL certificate has recently expired these days. We managed to download and build binaries for it before 10/3 (when the certificate expired). Due to this, Gradle might not build on a recent download because of this. It is already a noted issue on the OpenICE forum.**  

**This branch https://github.com/jlipworth/doctor-hud/tree/open-ice contains a compiled version of Hello OpenICE on MacOS.**

**Prerequisities for current install: Visual Studio with Microsoft .Net framework targeting pack 4.6.1; Python 3.5+;**
1. Download and install OpenICE and hello-openIce from 
https://www.openice.info/devdocs/-hello-openice.html.
2. Open windows application in Visual Studio, update the ip address variable in Form1.cs line 23 `static string serverIp = "localhost";`to desired server ip in Form1.cs. Update the ip address at line 85 `sock.bind(("10.211.55.2", port))` of open-ice-socket.py to be the server ip. If running in a Mac Windows VM, localhost shouldn't have to be changed, but the address at line 85 is the local intranet address of the machine. This step is temporary until we get reliable network discovery fully working. Hardcoding the address ensures that our demo will be able to communicate across the local network.
3. Run hello open ice and pipe the output to open-ice-socket.py. Run this command in project root directory.
 `./hello-open-ice-build/gradlew run | python ./server-script/open-ice-socket.py`
4. Open OpenICE supervisor, select "Create a device adapater", set Device Type to "Simulated Multiparameter Monitor", click "Start monitor".
5. Build and run the windows application; this is under the WindowsFormApp1 directory. There might be some package dependencies at first for the UI, but Nuget Package manager should pull in all the frameworks e.g. MetroFramework.

## Run with fake sensor data 
**Because of the unavailability of the SSL certificate, we built test mode that generates and broadcasts fake sensor data.**

**This is intended for machines that cannot run the precompiled binaries. e.g. testing but only having access to a windows machine. This functionality will be removed when OpenICE updates their certificate for new users to authenticate and download the source. This can be solely run on a Windows machine. We preconfigured it with localhost so there is no need for additional changes.**
1. Run the script with `python ./server-script/open-ice-socket.py <any arg>`. We have the script on the condition that if an additional argument is passed in, that it will proceed to broadcast fake data. Since OpenICE cannot build, the script will supply the data and send it over the network.
2. Build and run the windows application. Same instructions as 5 with the real data.
