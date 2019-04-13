# SMA-Monitor
This small VB.NET program is for live monitoring your SMA-SB3600TL-21 inverter on the desktop of a Windows PC.

Program:
VB.NET
Winforms
.Net framwork 4.7.2
.Net JSON

Devices:
SMA SB3600TL-21 inverter
Iungo Energy manager

Protocols:
TCP/IP

API:
ModBus via TCP/IP
Iungo 
JSON

The live Inverter information:
1.  Power in Watt
2.  Voltage to the grid
3.  Ampere to the grid
4.  Internal temperature in Celcius
5.  Daily yield in kWh
6.  Total yield (from commissioning date) in MWh

For people that are intrerested in domotica:
There is also the posibility to monitor live the power usages of your home via the Iungo-Energy-manager (https://www.iungo.nl/nl/)
and operate some ZWave switches to power a electrical devices.

How to use Iungo ZWave switches:

 Me.iungo = New IungoClient(Net.IPAddress.Parse(My.Settings.IP_Iungo))
 Me.iungo.ZWave.PowerSwitches("Iungo-switch-Name").State = PowerSwitch.PowerSwitchStatus.Off
