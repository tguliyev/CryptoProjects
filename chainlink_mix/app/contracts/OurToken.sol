// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

import "C:/Users/tguli/.brownie/packages/OpenZeppelin/openzeppelin-contracts@4.4.2/contracts/token/ERC20/ERC20.sol";

contract GLDToken is ERC20 {
    constructor(uint256 initialSupply) ERC20("Gold", "GLD") {
        _mint(msg.sender, initialSupply);
    }
}