from brownie import Lottery, accounts, config, network
from ..scripts.deploy import deploy_lottery

def main():
    lottery = deploy_lottery()