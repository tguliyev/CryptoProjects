from brownie import accounts, SimpleStorage, network


def deploy_simple_storage():
    # Getting account
    account = get_account()
    # Deploying contract
    simple_strage = SimpleStorage.deploy({"from" : account})
    # Calling view functions
    stored_value = simple_strage.retrieve()
    print(stored_value)
    # Making transaction
    transaction = simple_strage.store(24, {"from" : account})
    # Waiting coformation of the block 
    transaction.wait(1)
    print(simple_strage.retrieve())
    print("Hello Future")


def get_account():
    if network.show_active() == "development":
        return accounts[0]
    else: 
        return accounts.load("test_account")


def main():
    deploy_simple_storage()