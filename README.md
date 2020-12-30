SensorsPayloadDecoder
====================================

SensorsPayloadDecoder is a library to read the payload information from the [Bosch parking sensor](https://www.bosch-connectivity.com/de/produkte/parking-lot-sensor/) and
the [Elsys ERS sensor](https://www.elsys.se/en/ers-eye/) binary data.
The assembly was written and tested in .Net 5.0.

[![Build status](https://ci.appveyor.com/api/projects/status/ym5nosohx5wok6pj?svg=true)](https://ci.appveyor.com/project/SeppPenner/sensorspayloaddecoder)
[![GitHub issues](https://img.shields.io/github/issues/SeppPenner/SensorsPayloadDecoder.svg)](https://github.com/SeppPenner/SensorsPayloadDecoder/issues)
[![GitHub forks](https://img.shields.io/github/forks/SeppPenner/SensorsPayloadDecoder.svg)](https://github.com/SeppPenner/SensorsPayloadDecoder/network)
[![GitHub stars](https://img.shields.io/github/stars/SeppPenner/SensorsPayloadDecoder.svg)](https://github.com/SeppPenner/SensorsPayloadDecoder/stargazers)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://raw.githubusercontent.com/SeppPenner/SensorsPayloadDecoder/master/License.txt)
[![Known Vulnerabilities](https://snyk.io/test/github/SeppPenner/SensorsPayloadDecoder/badge.svg)](https://snyk.io/test/github/SeppPenner/SensorsPayloadDecoder)

## Available for
* NetCore 2.2

## Basic usage:
```csharp
var boschDecoder = new BoschParkingSensorDecoder();
var data = new byte[] { 0x01 };
var result = boschDecoder.DecodePayload(data, MessageType.UplinkHeartbeatMessage);

var elsysDecoder = new ElsysHumidityPayloadDecoder();
var data = new byte[] { 0x05, 0x01, 0x11, 0x01 };
var result = elsysDecoder.DecodePayload(data);
```

## Further links

### Reference links Bosch parking sensor
* https://iot-shop.de/wp-content/uploads/2019/04/parking-lot-sensor-communication-interface.pdf
* https://iot-shop.de/produkt/bosch-parksensor
* https://www.bosch-connectivity.com/de/produkte/parking-lot-sensor/
* https://www.bosch-connectivity.com/de/produkte/parking-lot-sensor/downloads/

### Reference links Elsys ERS humidity sensor
* https://www.elsys.se/en/elsys-payload/
* https://www.elsys.se/en/ers-eye/
* https://www.elsys.se/en/wp-content/uploads/sites/3/2018/06/ERS-data-sheet.pdf
* https://www.elsys.se/en/lora-doc/

Change history
--------------

See the [Changelog](https://github.com/SeppPenner/SensorsPayloadDecoder/blob/master/Changelog.md).