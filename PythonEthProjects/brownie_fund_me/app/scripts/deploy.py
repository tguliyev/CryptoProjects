from brownie import accounts, config, network, FundMe, MockV3Aggregator
from web3 import Web3


FORKED_LOCAL_ENVIRONMENTS=["mainnet-fork", "mainnet-fork-dev"]
LOCAL_BLOCKCHAIN_ENVIRONMENTS=["development", "ganache-local"]

DECIMALS=8
STARTING_PRICE=200000000000


# Start helpfull scripts
def get_account():
    if (network.show_active() in LOCAL_BLOCKCHAIN_ENVIRONMENTS 
        or network.show_active() in FORKED_LOCAL_ENVIRONMENTS):
        return accounts[0]
    else: 
        return accounts.load("test_acc")


def deploy_mocks():
    print(f"The active network is {network.show_active()}")
    print("Deploying Mocks...")

    if len(MockV3Aggregator) <= 0:
        MockV3Aggregator.deploy(DECIMALS, STARTING_PRICE, {"from" : get_account()})
    
    print("Mocks deployed!")

# End helpfull scripts


def deploy_fund_me():
    account = get_account()

    if network.show_active() not in LOCAL_BLOCKCHAIN_ENVIRONMENTS:
        price_feed_address = config["networks"][network.show_active()]["eth_usd_price_feed"]
    else:
        deploy_mocks()    
        price_feed_address = MockV3Aggregator[-1].address
    
    fund_me = FundMe.deploy(
        price_feed_address, 
        {"from" : account}, 
        publish_source=config["networks"][network.show_active()]["verify"]
    )
    return fund_me
    


def main():
    deploy_fund_me()