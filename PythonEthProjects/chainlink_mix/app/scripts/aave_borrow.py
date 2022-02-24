from .helpfull_scripts import get_account, FORKED_LOCAL_ENVIRONMENTS
from .get_weth import get_weth
from brownie import config, network, interface
from web3 import Web3

amount = 100000000000000000

def main():
    account = get_account()
    erc20_adress = config["networks"][network.show_active()]["weth_token"]
    if network.show_active() in FORKED_LOCAL_ENVIRONMENTS:
        get_weth()
    #ABI
    #Adress
    lending_pool = get_lending_pool()
    #Approve sending out ERC20 tokens
    approve_erc20(amount, lending_pool.address, erc20_adress, account)
    print("depositing")
    tx = lending_pool.deposit(erc20_adress, amount, account.address, 0, {"from" : account})
    tx.wait(1)
    print("deposited")
    borrowable_eth, total_debt = get_borrowable_data(lending_pool, account)
    dai_eth_price = get_asset_price(config["networks"][network.show_active()]["dai_eth_price_feed"])



def get_asset_price(price_feed_address):
    dai_eth_pricee_feed = interface.AggregatorV3Interface(price_feed_address)
    latest_price = dai_eth_pricee_feed.latestRoundData()[1]
    converted_latest_price = Web3.fromWei(latest_price, "ether")
    print(f"latest dai eth price is {converted_latest_price}")
    return float(latest_price)



def get_borrowable_data(lending_pool, account):
    (
        total_collateral_eth, 
        total_debt_eth, 
        available_borrow_eth, 
        current_liquidation_threshold, 
        ltv, 
        health_factor
    ) = lending_pool.getUserAccountData(account.address)
    available_borrow_eth = Web3.fromWei(available_borrow_eth, "ether")
    total_collateral_eth = Web3.fromWei(total_collateral_eth, "ether")
    total_debt_eth = Web3.fromWei(total_debt_eth, "ether")
    print(f"available eth {available_borrow_eth} - collateral eth {total_collateral_eth} - debt eth {total_debt_eth}")
    return (float(available_borrow_eth), float(total_debt_eth))


def approve_erc20(amount, spender, erc20_address, account):
    print("approving erc20 token...")
    erc20 = interface.IERC20(erc20_address)
    tx = erc20.approve(spender, amount, {"from" : account})
    tx.wait(1)
    print("Approved.")
    return tx


def get_lending_pool():
    #ABI
    #Adress
    lending_pool_adresses_provider = interface.ILendingPoolAddressesProvider(
        config["networks"][network.show_active()]["lending_pool_adresses_provider"]
    )
    lending_pool_adress = lending_pool_adresses_provider.getLendingPool()
    lending_pool = interface.ILendingPool(lending_pool_adress)
    return lending_pool
