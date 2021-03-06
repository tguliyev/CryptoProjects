// SPDX-License-Identifier: MIT
pragma solidity ^0.7.0;

import "../dependencies/chainlink-brownie-contracts@0.3.0/contracts/src/v0.7/interfaces/AggregatorV3Interface.sol";
import "../dependencies/openzeppelin-contracts@3.4.0/contracts/access/Ownable.sol";
import "../dependencies/chainlink-brownie-contracts@0.3.0/contracts/src/v0.7/VRFConsumerBase.sol";
 
enum LOTTERY_STATE { OPEN, CLOSED, CALCULATING_WINNER }

contract Lottery is Ownable, VRFConsumerBase {

    AggregatorV3Interface internal ethUsdPriceFeed;

    bytes32 keyHash;
    uint256 randomness;
    uint256 public fee;
    uint256 public usdEntryFee;
    address payable public recentWinner;
    address payable[] public players;
    LOTTERY_STATE public lottery_state;
    event RequestedRandomness(bytes32 requestId);


    constructor(address _priceFeedAddress, address _vrfCoordinator, address _link, uint256 _fee, bytes32 _keyHash) 
    VRFConsumerBase(_vrfCoordinator, _link) {
        usdEntryFee = 50 * (10 ** 18);
        ethUsdPriceFeed = AggregatorV3Interface(_priceFeedAddress);
        lottery_state = LOTTERY_STATE.CLOSED;
        fee = _fee;
        keyHash = _keyHash;
    }

    function enter() public payable {
        // 50$ minimum
        require(lottery_state == LOTTERY_STATE.OPEN);
        require(msg.value >= getEntranceFee(), "Not enough ETH!");
        players.push(payable(msg.sender));
    }

    function getEntranceFee() public view returns (uint256) {
        (,int256 price,,,) = ethUsdPriceFeed.latestRoundData();
        uint256 adjustedPrice = uint256(price) * (10 ** 10);
        
        uint256 costToEnter = (usdEntryFee * (10 ** 18)) / adjustedPrice;
        return costToEnter;
    }
    
    function startLottery() public onlyOwner {
        require(lottery_state == LOTTERY_STATE.CLOSED, "Can't start a new lottery yet!");
        lottery_state = LOTTERY_STATE.OPEN;
    }
    
    function endLottery() public onlyOwner {

        lottery_state = LOTTERY_STATE.CALCULATING_WINNER;
        bytes32 requestId = requestRandomness(keyHash, fee);
        emit RequestedRandomness(requestId);
    }

    function fulfillRandomness(bytes32 _requestId, uint256 _randomness) override internal {
        require(lottery_state == LOTTERY_STATE.CALCULATING_WINNER, "You are not there yet!");
        require(_randomness > 0, "Random not found");
        uint256 indexOfWinner = _randomness % players.length;
        recentWinner = players[indexOfWinner];
        recentWinner.transfer(address(this).balance);

        //Reset lottery
        players = new address payable[](0);
        lottery_state = LOTTERY_STATE.CLOSED;
        randomness = _randomness;
    }

}