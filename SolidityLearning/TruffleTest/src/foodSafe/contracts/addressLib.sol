pragma solidity ^0.4.17;

library AddressLib {
    function getAddress() public view returns (address msgSender, address thisAddress, address txOrigin) {
        return (msg.sender, address(this), tx.origin);
    }
}