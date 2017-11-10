pragma solidity ^0.4.17;

import './addressLib.sol';

contract FoodSafe {
  struct Location {
    string name;
    uint locationId;
    uint previousLocationId;
    uint timestamp;
    string secret;
    address libMsgSender;
    address libThisAddress;
    address txOrigin;
    bool initialized;
  }

  mapping (uint=>Location) private trail;
  uint8 private trailCount = 0;

  function addNewLocation(uint locationId, string name, string secret) public {
    Location memory newLocation;
    newLocation.name = name;
    newLocation.locationId = locationId;
    newLocation.secret = secret;
    newLocation.timestamp = now;
    newLocation.initialized = true;
    (newLocation.libMsgSender, newLocation.libThisAddress, newLocation.txOrigin) = AddressLib.getAddress();

    if (trailCount != 0) {
      newLocation.previousLocationId = trail[trailCount - 1].locationId;
    }
    trail[trailCount] = newLocation;
    trailCount++;
  }

  function getLocationByLocationId(uint locationId) public view returns (string locationName, /*uint currentLocationId,*/ uint previousLocationId, uint timestamp, string secret, address libMsgSender, address libThisAddress, address txOrigin) {
    for (uint index = 0; index < trailCount; index++) {
      if (trail[index].locationId == locationId) {
        return (trail[index].name, /*trail[index].locationId,*/ trail[index].previousLocationId, trail[index].timestamp, trail[index].secret, trail[index].libMsgSender, trail[index].libThisAddress, trail[index].txOrigin);
      }
    }

    revert();
  }

  function getLocationDetailsByTrailNumber(uint trailNumber) public view returns (string locationName, /*uint currentLocationId,*/ uint previousLocationId, uint timestamp, string secret, address libMsgSender, address libThisAddress, address txOrigin) {
    require(trailNumber >= 0 && trailNumber < trailCount);

    return (trail[trailNumber].name, /*trail[trailNumber].locationId,*/ trail[trailNumber].previousLocationId, trail[trailNumber].timestamp, trail[trailNumber].secret, trail[trailNumber].libMsgSender, trail[trailNumber].libThisAddress, trail[trailNumber].txOrigin);
  }
}
