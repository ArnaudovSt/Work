var FoodSafe = artifacts.require("./foodSafe.sol");
var AddressLibrary = artifacts.require("../contracts/addressLib.sol");
module.exports = function (deployer) {
  deployer.deploy(AddressLibrary);
  deployer.link(AddressLibrary, FoodSafe);
  deployer.deploy(FoodSafe);
};