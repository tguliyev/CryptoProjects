using System;
using EthereumSmartContracts.Contracts.SimpleStorage;
using EthereumSmartContracts.Contracts.SimpleStorage.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Signer;
using System.Numerics;
using Nethereum.RPC.Eth.DTOs;

namespace SimpleStorageConsole
{
    class Program
    {
        static readonly string infuraURL = "https://rinkeby.infura.io/v3/5b92ffb11802454da67fe778edd7f712";
        static readonly string privateKey = "0xbddcef3270275b39844948cc7d0d5f204aec72007f5941ce88f723438267db22";
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Hello My Incredible Future!!!");

            try
            {
                // Setup
                Account account = new Account(privateKey, Chain.Rinkeby);
                Web3 web3 = new Web3(account, infuraURL);

                // An already-deployed SimpleStorage.sol contract on Rinkeby:
                string contractAddress = "0x5123B49B873245cC2d933717Ff5DC6f77363fa8A";
                SimpleStorageService service = new SimpleStorageService(web3, contractAddress);

                // Set new value
                TransactionReceipt setValueTransactionAddress = await service.SetRequestAndWaitForReceiptAsync(new BigInteger(24));
                System.Console.WriteLine(setValueTransactionAddress.TransactionHash);

                // Get the stored value
                BigInteger currentStoredValue = await service.GetQueryAsync();
                Console.WriteLine($"Contract has value stored: {currentStoredValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}