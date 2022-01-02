from solcx import compile_standard
from web3 import Web3
import json

with open("./SimpleStorage.sol", "r") as file:
    simple_storage_file = file.read()

compiled_sol = compile_standard(
    {
        "language": "Solidity",
        "sources": {"SimpleStorage.sol": {"content": simple_storage_file}},
        "settings": {
            "outputSelection": {
                "*": {
                    "*": ["abi", "metadata", "evm.bytecode", "evm.bytecode.sourceMap"]
                }
            }
        },
    },
    solc_version="0.6.0",
)

with open("cimpiled_code.json", "w") as file:
    json.dump(compiled_sol, file)


# Get bytecode
bytecode = compiled_sol["contracts"]["SimpleStorage.sol"]["SimpleStorage"]["evm"]["bytecode"]["object"]

# Get abi
abi = compiled_sol["contracts"]["SimpleStorage.sol"]["SimpleStorage"]["abi"]

# Connecting ganache
web3 = Web3(Web3.HTTPProvider("https://rinkeby.infura.io/v3/5b92ffb11802454da67fe778edd7f712"))
chain_id = 4
my_address = "0x02d8834Cb5BB9affDa038dAd522B804cd59F8cB9"
private_key = "0xbddcef3270275b39844948cc7d0d5f204aec72007f5941ce88f723438267db22"

# Creating contract in python
simple_storage = web3.eth.contract(abi=abi, bytecode=bytecode)

# Get the latest transaction
nonce = web3.eth.getTransactionCount(my_address)


# Build the transaction
transaction = simple_storage.constructor().buildTransaction({"gasPrice": web3.eth.gas_price, "chainId" : chain_id, "from" : my_address, "nonce" : nonce})

# Sign the transaction
signed_transaction = web3.eth.account.sign_transaction(transaction, private_key=private_key)

# Send transaction
transaction_hash = web3.eth.send_raw_transaction(signed_transaction.rawTransaction)
transaction_receipt = web3.eth.wait_for_transaction_receipt(transaction_hash)


# Working with deployed Contracts
deployed_simple_storage = web3.eth.contract(address=transaction_receipt.contractAddress, abi=abi)
print(deployed_simple_storage.functions.retrieve().call())

store_transaction = simple_storage.functions.store(15).buildTransaction({
    "gasPrice": web3.eth.gas_price, 
    "chainId" : chain_id, 
    "from" : my_address, 
    "nonce" : nonce + 1, 
    "to" : transaction_receipt.contractAddress
})

signed_store_transaction = web3.eth.account.sign_transaction(store_transaction, private_key=private_key)

send_store_transaction = web3.eth.send_raw_transaction(signed_store_transaction.rawTransaction)

store_transaction_receipt = web3.eth.wait_for_transaction_receipt(send_store_transaction) 

print(deployed_simple_storage.functions.retrieve().call())