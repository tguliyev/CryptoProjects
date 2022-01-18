from brownie import Lottery, network, config
from .helpful_scripts import get_account, get_contract, fund_with_link
import time


def deploy_lottery():
    account = get_account()
    lottery = Lottery.deploy(
        get_contract("eth_usd_price_feed").address,
        get_contract("vrf_coordinator").address,
        get_contract("link_token").address,
        config["networks"][network.show_active()]["fee"],
        config["networks"][network.show_active()]["keyhash"],
        {"from" : account},
        publish_source=config["networks"][network.show_active()].get("verify", False)
    )
    print("Deployed lottery!!!")
    return lottery


def start_lottery():
    account = get_account()
    lottery = Lottery[-1]
    starting_tx = lottery.startLottery({"from" : account})
    starting_tx.wait(1)
    print("Lottery is started!!!")


def enter_lottery():
    account = get_account(index=1)
    print(account.balance())
    lottery = Lottery[-1]
    value = lottery.getEntranceFee()
    transaction = lottery.enter({"from" : account, "value" : value})
    transaction.wait(1)
    print("Entered the lottery")
    print(account.balance())


def end_lottery():
    account = get_account()
    lottery = Lottery[-1]
    tx = fund_with_link(lottery.address)
    tx.wait(1)
    end_transaction = lottery.endLottery({"from" : account})
    end_transaction.wait(1)
    time.sleep(60)
    print(f"{lottery.recentWinner()} is current winner!!!")


def main():
    deploy_lottery()
    start_lottery()
    enter_lottery()
    end_lottery()