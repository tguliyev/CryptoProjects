from scripts.helpful_scripts import LOCAL_BLOCKCHAIN_ENVIRONMENTS, fund_with_link, get_contract, get_account
from scripts.deploy import deploy_lottery
from brownie import network
import pytest
import time

def test_can_pick_winner():
    # Assert
    if network.show_active() in LOCAL_BLOCKCHAIN_ENVIRONMENTS:
        pytest.skip()
    lottery = deploy_lottery()
    account = get_account(id="test_acc")
    lottery.startLottery({"from" : account})
    lottery.enter({"from" : account, "value" : lottery.getEntranceFee()})
    lottery.enter({"from" : get_account(index=1), "value" : lottery.getEntranceFee()})
    lottery.enter({"from" : get_account(index=2), "value" : lottery.getEntranceFee()})
    fund_with_link(lottery)
    # Act
    transaction = lottery.endLottery({"from" : account})
    time.sleep(60)

    # Assert
    assert lottery.recentWinner() == account
    assert lottery.balance() == 0