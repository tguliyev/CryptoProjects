from brownie import accounts, SimpleStorage
from brownie.network import account

def test_deploy():
    # Arrange
    account = accounts[0]
    # Act
    simple_storage = SimpleStorage.deploy({"from" : account})
    starting_value = simple_storage.retrieve()
    exspected = 22
    # Assert
    assert starting_value == exspected


def test_updating_storage():
    # Arrange
    account = accounts[0] 
    # Act 
    simple_storage = SimpleStorage.deploy({"from" : account})
    transaction = simple_storage.store(24, {"from" : account})
    transaction.wait(1)
    updated_value = simple_storage.retrieve()
    exspected = 24
    # Assert
    assert updated_value == exspected  