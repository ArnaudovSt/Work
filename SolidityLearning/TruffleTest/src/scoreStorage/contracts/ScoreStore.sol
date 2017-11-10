pragma solidity ^0.4.17;
contract ScoreStore {
    struct PersonScore {
        int score;
        bool initialized;
    }
    mapping(string => PersonScore) personScores;
    function addInitialScore(string personName, int startingScore) public {
        require(!personScores[personName].initialized);

        personScores[personName].score = startingScore;
        personScores[personName].initialized = true;
    }

    function getScore(string personName) public view returns(int) {
        require(personScores[personName].initialized);

        return personScores[personName].score;
    }

}