LIFX-Sharp
==========

.NET API for the controlling LIFX bulbs


LifxLib is a library containing classes representing Bulbs, PAN controllers, Communication and Messages sent from and to a physical LIFX bulb. The communication is done solely via UDP. 

Since the API is not available yet, I have relied on magicmonkeys terrific LIFX project (https://github.com/magicmonkey/lifxjs) which has a great documentation from observations made of network traffic.


Included is a test application showing how to use the lib to:
* Discover PAN controllers/bulbs
* Get/Set Power state
* Get/Set Label
* Get/Set Color parameters


Usage
==========

Discovery of bulb:
```
  LifxCommunicator.Instance.Initialize();

  List<LifxPanController> panController = LifxCommunicator.Instance.Discover();
  LifxBulb mBulb = panController[0].bulbs[0];
```

Get power state:
```
  LifxPowerState powerState = mBulb.GetPowerState();
```

Set power state:
```
  mBulb.SetPowerState(LifxPowerState.On);
```

Set Color:

```
  UInt16 kelvinValue = 1000;
  UInt32 fadeTimeMilliseconds = 2000;
  mBulb.SetColor(new LifxColor(Color.Red, kelvinValue), fadeTimeMilliseconds);
```
Etc...
