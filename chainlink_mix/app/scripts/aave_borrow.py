from .helpfull_scripts import get_account, FORKED_LOCAL_ENVIRONMENTS
from .get_weth import get_weth
from brownie import config, network, interface


def main():
    account = get_account(id="test_acc")
    erc20_adress = config["networks"][network.show_active()]["weth_token"]
    if network.show_active() in FORKED_LOCAL_ENVIRONMENTS:
        get_weth()
    #ABI
    #Adress
    lending_pool = get_lending_pool()


def get_lending_pool():
    #ABI
    #Adress
    pass