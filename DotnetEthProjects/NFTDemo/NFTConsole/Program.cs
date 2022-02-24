using System;
using Nethereum;
using Nethereum.Web3.Accounts;
using Nethereum.Signer;
using Nethereum.Web3;
using EthereumSmartContracts.Contracts.SimpleCollectible;
using EthereumSmartContracts.Contracts.SimpleCollectible.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;

namespace NFTConsole
{
    public class Program
    {
        static readonly string infuraURL = "https://rinkeby.infura.io/v3/5b92ffb11802454da67fe778edd7f712";
        static readonly string privateKey = "0xbddcef3270275b39844948cc7d0d5f204aec72007f5941ce88f723438267db22";
        static readonly string tokenMetaDataUri = "https://ipfs.io/ipfs/Qmd9MCGtdVz2miNumBHDbvj8bigSgTwnr4SbyH6DNnpWdt?filename=0-PUG.json";

        static async Task Main(string[] args)
        {
            // Defining Account and Web3 instances
            Account account = new Account(privateKey, Chain.Rinkeby);
            Web3 web3 = new Web3(account, infuraURL);

            // Deploying a SimpleCollectible
            TransactionReceipt simpleCollectibleDeploymentTransaction = await SimpleCollectibleService.DeployContractAndWaitForReceiptAsync(web3, new SimpleCollectibleDeployment());
            SimpleCollectibleService simpleCollectibleService = new SimpleCollectibleService(web3, simpleCollectibleDeploymentTransaction.ContractAddress);
            Console.Write("SimpleCollectible contract address is ");
            Console.WriteLine(simpleCollectibleDeploymentTransaction.ContractAddress);

            // Creating Collectible
            CreateCollectibleFunction createCollectibleFunction = new CreateCollectibleFunction()
            {
                TokenURI = tokenMetaDataUri
            };
            TransactionReceipt createdCollectibleTransaction = await simpleCollectibleService.CreateCollectibleRequestAndWaitForReceiptAsync(createCollectibleFunction);
            Console.WriteLine($"Creted collectible transaction hash is {createdCollectibleTransaction.TransactionHash}");
        }
    }
}