pragma solidity ^0.4.17;

contract IScoreStore {
    function getScore(string personName) public view returns (int);
}

contract MyGame {
    function showScore(string name) public view returns (int score) {
        IScoreStore scoreStore = IScoreStore(0xAFEF6d4A0dAc6d49671a0Dd73b29b926f8c3bEbc);
        return scoreStore.getScore(name);
    }
}