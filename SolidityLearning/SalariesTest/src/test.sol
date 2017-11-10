pragma solidity ^0.4.0;
contract SplitIt {
    address[] employees = [0x356B82400Bc5ac66c8C501efa102B5e61B6B1FDc, 0x356B82400Bc5ac66c8C501efa102B5e61B6B1FDc, 0x6761b2f815480DB8452F29Ffd7242590843028Ee];
    uint totalRecieved = 0;
    mapping (address => uint) withdrawnAmounts;

    // Constructor
    function SplitIt() payable public {
        updateTotalRecieved();
    }

    function () payable public {
        updateTotalRecieved();
    }

    function updateTotalRecieved() private {
        totalRecieved += msg.value;
    }

    modifier canWithdraw() {

        bool contains = false;
        for (let index= 0; index < employees.length; index++) {
            if (employees[index] == msg.sender) {
                contains = true;
                break;
            }
        }

        require(contains);
        _;
    }

    function withdraw() canWithdraw public {
        uint amountAllocated = totalRecieved/employees.length;
        uint amountWithdrawn = withdrawnAmounts[msg.sender];
        uint amount = amountAllocated - amountWithdrawn;
        withdrawnAmounts[msg.sender] = amountWithdrawn + amount;

        if (amount > 0) {
            msg.sender.transfer(amount);
        }
    }
}
