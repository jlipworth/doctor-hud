Frequently Asked Questions
==========================

Contact
-------
If you have any questions or issues, please raise an issue in our github repository:

`jlipworth/doctor-hud <https://github.com/jlipworth/doctor-hud/issues>`_.

Platform Support
----------------
We support all major platforms, but server support on Windows requires a bash shell, but also requires the shell scripts to be in LF-style line endings, unless bash is configured to run with CRLF endings.

Client support is even less limited to only the browser. The only limits are a capable browser, and our Skype integration plugin is supported on the machine.

Additional Sensors
------------------
Adding additional sensors at the present time is limited, but it is a work in progess. Although as long as OpenICE supports it, only small modifications are required for new sensors to be supported.

Sensor Update Frequency
-----------------------
Currently the sensor data updates once a second. This isn't nearly as granular as analog sensors, but it does allow us to support the data over almost all connections.

Calendar/Appointment Setup
--------------------------
An admin can setup appointments for certain hospital rooms at certain times. The admin would need to login and add particular user to a calendar slot and associated hospital room.

Skype Destination
-----------------
The Skype destination for a particular hospital room is setup upon initial server setup.
