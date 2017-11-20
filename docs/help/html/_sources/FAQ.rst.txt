Frequently Asked Questions
==========================

Contact
-------
If you have any questions or issues, please raise an issue in our `github repository <https://github.com/jlipworth/doctor-hud/issues>`_.

Platform Support
----------------
We support all major POSIX-compliant platforms (namely, Linux and OS X).  To deploy the server on Windows, a bash shell is required, and the files must be converted from CRLF to LF line endings.

The client functions on all major web browsers. Chrome is preferred, as it supports the Skype web plugin. Firefox and Safari also work, but the Skype call button must be used instead of the plugin.  Edge also supports the Skype plugin, but there may be minor display issues.

Additional Sensors
------------------
Adding additional sensors at the present time is limited, but it is a work in progess. Although as long as OpenICE supports it, only small modifications are required for new sensors to be supported.

Sensor Update Frequency
-----------------------
Currently, the sensor data updates once a second.

Calendar/Appointment Setup
--------------------------
An admin for a particular hospital can setup appointments at certain times. The procedure is described in the `admin section <admin.html>`_.

Skype Destination
-----------------
The Skype destination for a particular hospital room is set up upon initial server setup.

Disconnect Token Users
----------------------
To disconnect any users logged in with tokens, simply restart the server, and all users will be required to reauthenticate.
