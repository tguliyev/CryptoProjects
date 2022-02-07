from brownie import Lottery, accounts, config, network, exceptions
from scripts.helpful_scripts import get_account, get_contract
from scripts.helpful_scripts import LOCAL_BLOCKCHAIN_ENVIRONMENTS, fund_with_link
from scripts.deploy import deploy_lottery
from web3 import Web3
import pytest

def test_get_entrance_fee():
    if network.show_active() not in LOCAL_BLOCKCHAIN_ENVIRONMENTS:
        pytest.skip()
    # Arrange
    lottery = deploy_lottery()
    # Act
    expected_entrance_fee = Web3.toWei(0.025, "ether")
    entrance_fee = lottery.getEntranceFee()
    # Assert
    assert entrance_fee == expected_entrance_fee


def test_cant_enter_unless_started():
    # Arrange
    if network.show_active() not in LOCAL_BLOCKCHAIN_ENVIRONMENTS:
        pytest.skip()
    lottery = deploy_lottery()
    # Act / Assert
    with pytest.raises(exceptions.VirtualMachineError):
        lottery.enter({"from" : get_account(), "value": lottery.getEntranceFee()})


def test_can_enter_and_start_lottery():
    # Arrange
    if network.show_active() not in LOCAL_BLOCKCHAIN_ENVIRONMENTS:
        pytest.skip()
    lottery = deploy_lottery()
    account  = get_account()
    lottery.startLottery({"from" : account})
    # Act
    lottery.enter({"from" : account, "value" : lottery.getEntranceFee()})
    # Assertt
    assert lottery.players(0) == account


def test_can_end_lottery():
    # Arrange
    if network.show_active() not in LOCAL_BLOCKCHAIN_ENVIRONMENTS:
        pytest.skip()
    lottery = deploy_lottery()
    account  = get_account()
    lottery.startLottery({"from" : account})
    lottery.enter({"from" : account, "value" : lottery.getEntranceFee()})
    fund_with_link(lottery)
    # Act
    lottery.endLottery({"from" : account})
    # Assert
    assert lottery.lottery_state() == 2


def test_can_pick_winner_correctly():
    # Arrange
    if network.show_active() not in LOCAL_BLOCKCHAIN_ENVIRONMENTS:
        pytest.skip()
    lottery = deploy_lottery()
    account = get_account()
    lottery.startLottery({"from" : account})
    lottery.enter({"from" : account, "value" : lottery.getEntranceFee()})
    lottery.enter({"from" : get_account(index=1), "value" : lottery.getEntranceFee()})
    lottery.enter({"from" : get_account(index=2), "value" : lottery.getEntranceFee()})
    fund_with_link(lottery)
    transaction = lottery.endLottery({"from" : account})
    # transaction.wait(1)
    request_id = transaction.events["RequestedRandomness"]["requestId"]
    # Act
    get_contract("vrf_coordinator").callBackWithRandomness(request_id, 777, lottery.address, {"from" : account})

    account_ballance = account.balance()
    lottery_ballance = lottery.balance()
    # Assert
    assert lottery.recentWinner() == account
    assert lottery.balance() == 0
    assert account.balance() == account_ballance + lottery_ballance