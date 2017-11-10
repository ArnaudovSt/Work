var MyGame = artifacts.require("./myGame.sol");
module.exports = function (deployer) {
  deployer.deploy(MyGame);
};