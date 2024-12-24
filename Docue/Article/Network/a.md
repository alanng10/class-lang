# Network

Network can connect to local system connected USB devices.

Use System module System.Network Network class to connect to USB devices.
Use "usb:" prefix in the Network any host name string.
After the prefix, use 15 digits hexadecimal integer number string.
The integer number is USB port index.
The integer number has cap that is 60 bits.
This is enough element to network with USB devices.

Network is not tagged with the existence of specific form. 
All host name strings do not tag Network with the existence of specific form.