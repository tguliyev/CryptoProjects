from scripts.deploy import get_account, deploy_fund_me, LOCAL_BLOCKCHAIN_ENVIRONMENTS
from brownie import network, accounts, exceptions
import pytest


def test_can_fund_and_withdraw():
    account = get_account()
    fund_me = deploy_fund_me()
    entrance_fee = fund_me.getEntranceFee() + 100
    tx = fund_me.fund({"from" : account, "value" : entrance_fee})
    tx.wait(1)
    assert fund_me.addressToAmountFunded(account.address) == entrance_fee
    tx2 = fund_me.withdraw({"from" : account})
    tx2.wait(1)
    assert fund_me.addressToAmountFunded(account.address) == 0


def test_only_owner_can_withdraw():
    if network.show_active() not in LOCAL_BLOCKCHAIN_ENVIRONMENTS:
        pytest.skip("Only for dev networks")
    fund_me = deploy_fund_me()
    bad_actor = accounts[1]
    with pytest.raises(exceptions.VirtualMachineError):
        fund_me.withdraw({"from" : bad_actor})