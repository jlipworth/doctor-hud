Remote Doctor Operation
=======================

The major functionality of the remote doctor's web interface can be explained in terms of a few different operations.

Connect Page
------------
Everything starts at the `connect page <https://jlipworth.github.io/doctor-hud>`_. This is a drop-down to select which server you want to connect to. It includes our online demo server, and a local option for users wanting to test it on their own machines.

.. image:: pictures/connectpage.png
   :align: center


Creating Account
----------------
To create permanent credentials as a doctor, a you should create a new account. This can reached through the login page.

.. image:: pictures/login-create.png
   :align: center

Filling out this form and submitting it will store these credentials, which can be used in the future, once an administrator has granted the account access.

.. image:: pictures/login-signup.png
   :align: center
   :scale: 75

Login via Credentials
---------------------
Logging in with credentials requires an appointment time set up in advance by an administrator. If this has been set up properly, logging in with credentials will bring the user directly to the sensor display.

.. image:: pictures/login-credentials.png
   :align: center

Login via Token
---------------
When immediate assistance is required, admins can create temporary tokens, which can also be used to login at the login screen.

.. image:: pictures/login-token.png
   :align: center

Displaying and Hiding Sensors
-----------------------------
The default display on logging in is to display all the sensor data. If desired, you can hide any of the sensors. Here is the default first column of sensors:

.. image:: pictures/sensors-allshown.png
   :align: center
   :scale: 50

Clicking "Hide Heart Rate" will result in:

.. image:: pictures/sensors-hiddenheart.png
   :align: center
   :scale: 50

Clicking "Show Heart Rate" will return the view back to the first view.


Moving Sensors
--------------
Sensors can be moved up and down, as well as between the two columns. All sensors can be dragged and dropped to easily customize the display as desired.

.. image:: pictures/sensors-drag.png
   :align: center


Skype Integration
-----------------
Skype web control is integrated as part of the web application.  A first-time user needs to sign in with their own Skype account. 

.. image:: pictures/skype-signin.png
   :align: center

To launch a Skype video call to the operating doctor, click the call button on the top right corner of the Skype chat canvas. The destination Skype account for every hospital is set when the server is set up. The chat canvas will show the video once the call is picked up.

.. image:: pictures/skype-call.png
   :align: center

Notice that initiating a call through Skype web control is only supported on Google Chrome and Microsoft Edge, and requires an HTTPS connection. If you're using other browsers or testing on your local server without HTTPS, you can instead click on the Skype call button in the navigation bar, which will invoke the desktop version of Skype installed on your computer, and initiate the call. 

.. image:: pictures/skype-button.png
   :align: center
   
Logout
------
To log out of the session, click the "Logout" button in the top banner:

.. image:: pictures/sensors-logout.png
   :align: center

If previously logged in with credentials, the user can log back in as long as the appointment has not ended.

If previously logged in with a temporary token, a new token must be generated to log back in.
