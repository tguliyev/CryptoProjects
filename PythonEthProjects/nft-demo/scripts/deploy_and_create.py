from .helpful_scripts import get_account
from brownie import SimpleCollectible

sampleTokenURI = "https://ipfs.io/ipfs/Qmd9MCGtdVz2miNumBHDbvj8bigSgTwnr4SbyH6DNnpWdt?filename=0-PUG.json"
openSeaURI = "https://testnets.opensea.io/assets/"

def deploy_and_create():
    account = get_account()
    simpleCollectible = SimpleCollectible.deploy({"from" : account})
    mintTransaction = simpleCollectible.createCollectible(sampleTokenURI ,{"from" : account})
    mintTransaction.wait(1)
    return simpleCollectible


def main():
    deploy_and_create()