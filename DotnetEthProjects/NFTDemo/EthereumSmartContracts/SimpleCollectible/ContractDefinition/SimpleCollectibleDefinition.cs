using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace EthereumSmartContracts.Contracts.SimpleCollectible.ContractDefinition
{


    public partial class SimpleCollectibleDeployment : SimpleCollectibleDeploymentBase
    {
        public SimpleCollectibleDeployment() : base(BYTECODE) { }
        public SimpleCollectibleDeployment(string byteCode) : base(byteCode) { }
    }

    public class SimpleCollectibleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040523480156200001157600080fd5b506040805180820182526005815264446f67696560d81b602080830191825283518085019094526003845262444f4760e81b9084015281519192916200005a916000916200007e565b508051620000709060019060208401906200007e565b505060006007555062000161565b8280546200008c9062000124565b90600052602060002090601f016020900481019282620000b05760008555620000fb565b82601f10620000cb57805160ff1916838001178555620000fb565b82800160010185558215620000fb579182015b82811115620000fb578251825591602001919060010190620000de565b50620001099291506200010d565b5090565b5b808211156200010957600081556001016200010e565b6002810460018216806200013957607f821691505b602082108114156200015b57634e487b7160e01b600052602260045260246000fd5b50919050565b61181380620001716000396000f3fe608060405234801561001057600080fd5b50600436106100f55760003560e01c80636352211e11610097578063b88d4fde11610066578063b88d4fde146101f4578063c87b56dd14610207578063d082e3811461021a578063e985e9c514610222576100f5565b80636352211e146101b357806370a08231146101c657806395d89b41146101d9578063a22cb465146101e1576100f5565b8063095ea7b3116100d3578063095ea7b31461015857806323b872dd1461016d57806331f1f3c31461018057806342842e0e146101a0576100f5565b806301ffc9a7146100fa57806306fdde0314610123578063081812fc14610138575b600080fd5b61010d6101083660046110ba565b610235565b60405161011a91906111fc565b60405180910390f35b61012b61027d565b60405161011a9190611207565b61014b610146366004611138565b61030f565b60405161011a91906111ab565b61016b610166366004611091565b61035b565b005b61016b61017b366004610fa3565b6103f3565b61019361018e3660046110f2565b61042b565b60405161011a91906116a0565b61016b6101ae366004610fa3565b610464565b61014b6101c1366004611138565b61047f565b6101936101d4366004610f57565b6104b4565b61012b6104f8565b61016b6101ef366004611057565b610507565b61016b610202366004610fde565b61051d565b61012b610215366004611138565b61055c565b61019361067d565b61010d610230366004610f71565b610683565b60006001600160e01b031982166380ac58cd60e01b148061026657506001600160e01b03198216635b5e139f60e01b145b806102755750610275826106b1565b90505b919050565b60606000805461028c90611718565b80601f01602080910402602001604051908101604052809291908181526020018280546102b890611718565b80156103055780601f106102da57610100808354040283529160200191610305565b820191906000526020600020905b8154815290600101906020018083116102e857829003601f168201915b5050505050905090565b600061031a826106ca565b61033f5760405162461bcd60e51b815260040161033690611573565b60405180910390fd5b506000908152600460205260409020546001600160a01b031690565b60006103668261047f565b9050806001600160a01b0316836001600160a01b0316141561039a5760405162461bcd60e51b81526004016103369061160e565b806001600160a01b03166103ac6106e7565b6001600160a01b031614806103c857506103c8816102306106e7565b6103e45760405162461bcd60e51b8152600401610336906113af565b6103ee83836106eb565b505050565b6104046103fe6106e7565b82610759565b6104205760405162461bcd60e51b81526004016103369061164f565b6103ee8383836107d6565b60075460009061043b3382610909565b6104458184610923565b60016007600082825461045891906116a9565b90915550909392505050565b6103ee8383836040518060200160405280600081525061051d565b6000818152600260205260408120546001600160a01b0316806102755760405162461bcd60e51b815260040161033690611456565b60006001600160a01b0382166104dc5760405162461bcd60e51b81526004016103369061140c565b506001600160a01b031660009081526003602052604090205490565b60606001805461028c90611718565b6105196105126106e7565b8383610967565b5050565b61052e6105286106e7565b83610759565b61054a5760405162461bcd60e51b81526004016103369061164f565b61055684848484610a0a565b50505050565b6060610567826106ca565b6105835760405162461bcd60e51b815260040161033690611522565b6000828152600660205260408120805461059c90611718565b80601f01602080910402602001604051908101604052809291908181526020018280546105c890611718565b80156106155780601f106105ea57610100808354040283529160200191610615565b820191906000526020600020905b8154815290600101906020018083116105f857829003601f168201915b505050505090506000610626610a3d565b905080516000141561063a57509050610278565b81511561066c57808260405160200161065492919061117c565b60405160208183030381529060405292505050610278565b61067584610a4f565b949350505050565b60075481565b6001600160a01b03918216600090815260056020908152604080832093909416825291909152205460ff1690565b6001600160e01b031981166301ffc9a760e01b14919050565b6000908152600260205260409020546001600160a01b0316151590565b3390565b600081815260046020526040902080546001600160a01b0319166001600160a01b03841690811790915581906107208261047f565b6001600160a01b03167f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92560405160405180910390a45050565b6000610764826106ca565b6107805760405162461bcd60e51b815260040161033690611363565b600061078b8361047f565b9050806001600160a01b0316846001600160a01b031614806107c65750836001600160a01b03166107bb8461030f565b6001600160a01b0316145b8061067557506106758185610683565b826001600160a01b03166107e98261047f565b6001600160a01b03161461080f5760405162461bcd60e51b81526004016103369061126c565b6001600160a01b0382166108355760405162461bcd60e51b8152600401610336906112e8565b6108408383836103ee565b61084b6000826106eb565b6001600160a01b03831660009081526003602052604081208054600192906108749084906116d5565b90915550506001600160a01b03821660009081526003602052604081208054600192906108a29084906116a9565b909155505060008181526002602052604080822080546001600160a01b0319166001600160a01b0386811691821790925591518493918716917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef91a46103ee8383836103ee565b610519828260405180602001604052806000815250610ad2565b61092c826106ca565b6109485760405162461bcd60e51b81526004016103369061149f565b600082815260066020908152604090912082516103ee92840190610e31565b816001600160a01b0316836001600160a01b031614156109995760405162461bcd60e51b81526004016103369061132c565b6001600160a01b0383811660008181526005602090815260408083209487168084529490915290819020805460ff1916851515179055517f17307eab39ab6107e8899845ad3d59bd9653f200f220920489ca2b5937696c31906109fd9085906111fc565b60405180910390a3505050565b610a158484846107d6565b610a2184848484610b05565b6105565760405162461bcd60e51b81526004016103369061121a565b60408051602081019091526000815290565b6060610a5a826106ca565b610a765760405162461bcd60e51b8152600401610336906115bf565b6000610a80610a3d565b90506000815111610aa05760405180602001604052806000815250610acb565b80610aaa84610c20565b604051602001610abb92919061117c565b6040516020818303038152906040525b9392505050565b610adc8383610d3b565b610ae96000848484610b05565b6103ee5760405162461bcd60e51b81526004016103369061121a565b6000610b19846001600160a01b0316610e22565b15610c1557836001600160a01b031663150b7a02610b356106e7565b8786866040518563ffffffff1660e01b8152600401610b5794939291906111bf565b602060405180830381600087803b158015610b7157600080fd5b505af1925050508015610ba1575060408051601f3d908101601f19168201909252610b9e918101906110d6565b60015b610bfb573d808015610bcf576040519150601f19603f3d011682016040523d82523d6000602084013e610bd4565b606091505b508051610bf35760405162461bcd60e51b81526004016103369061121a565b805181602001fd5b6001600160e01b031916630a85bd0160e11b149050610675565b506001949350505050565b606081610c4557506040805180820190915260018152600360fc1b6020820152610278565b8160005b8115610c6f5780610c5981611753565b9150610c689050600a836116c1565b9150610c49565b60008167ffffffffffffffff811115610c9857634e487b7160e01b600052604160045260246000fd5b6040519080825280601f01601f191660200182016040528015610cc2576020820181803683370190505b5090505b841561067557610cd76001836116d5565b9150610ce4600a8661176e565b610cef9060306116a9565b60f81b818381518110610d1257634e487b7160e01b600052603260045260246000fd5b60200101906001600160f81b031916908160001a905350610d34600a866116c1565b9450610cc6565b6001600160a01b038216610d615760405162461bcd60e51b8152600401610336906114ed565b610d6a816106ca565b15610d875760405162461bcd60e51b8152600401610336906112b1565b610d93600083836103ee565b6001600160a01b0382166000908152600360205260408120805460019290610dbc9084906116a9565b909155505060008181526002602052604080822080546001600160a01b0319166001600160a01b03861690811790915590518392907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef908290a4610519600083836103ee565b6001600160a01b03163b151590565b828054610e3d90611718565b90600052602060002090601f016020900481019282610e5f5760008555610ea5565b82601f10610e7857805160ff1916838001178555610ea5565b82800160010185558215610ea5579182015b82811115610ea5578251825591602001919060010190610e8a565b50610eb1929150610eb5565b5090565b5b80821115610eb15760008155600101610eb6565b600067ffffffffffffffff80841115610ee557610ee56117ae565b604051601f8501601f19908116603f01168101908282118183101715610f0d57610f0d6117ae565b81604052809350858152868686011115610f2657600080fd5b858560208301376000602087830101525050509392505050565b80356001600160a01b038116811461027857600080fd5b600060208284031215610f68578081fd5b610acb82610f40565b60008060408385031215610f83578081fd5b610f8c83610f40565b9150610f9a60208401610f40565b90509250929050565b600080600060608486031215610fb7578081fd5b610fc084610f40565b9250610fce60208501610f40565b9150604084013590509250925092565b60008060008060808587031215610ff3578081fd5b610ffc85610f40565b935061100a60208601610f40565b925060408501359150606085013567ffffffffffffffff81111561102c578182fd5b8501601f8101871361103c578182fd5b61104b87823560208401610eca565b91505092959194509250565b60008060408385031215611069578182fd5b61107283610f40565b915060208301358015158114611086578182fd5b809150509250929050565b600080604083850312156110a3578182fd5b6110ac83610f40565b946020939093013593505050565b6000602082840312156110cb578081fd5b8135610acb816117c4565b6000602082840312156110e7578081fd5b8151610acb816117c4565b600060208284031215611103578081fd5b813567ffffffffffffffff811115611119578182fd5b8201601f81018413611129578182fd5b61067584823560208401610eca565b600060208284031215611149578081fd5b5035919050565b600081518084526111688160208601602086016116ec565b601f01601f19169290920160200192915050565b6000835161118e8184602088016116ec565b8351908301906111a28183602088016116ec565b01949350505050565b6001600160a01b0391909116815260200190565b6001600160a01b03858116825284166020820152604081018390526080606082018190526000906111f290830184611150565b9695505050505050565b901515815260200190565b600060208252610acb6020830184611150565b60208082526032908201527f4552433732313a207472616e7366657220746f206e6f6e20455243373231526560408201527131b2b4bb32b91034b6b83632b6b2b73a32b960711b606082015260800190565b60208082526025908201527f4552433732313a207472616e736665722066726f6d20696e636f72726563742060408201526437bbb732b960d91b606082015260800190565b6020808252601c908201527f4552433732313a20746f6b656e20616c7265616479206d696e74656400000000604082015260600190565b60208082526024908201527f4552433732313a207472616e7366657220746f20746865207a65726f206164646040820152637265737360e01b606082015260800190565b60208082526019908201527f4552433732313a20617070726f766520746f2063616c6c657200000000000000604082015260600190565b6020808252602c908201527f4552433732313a206f70657261746f7220717565727920666f72206e6f6e657860408201526b34b9ba32b73a103a37b5b2b760a11b606082015260800190565b60208082526038908201527f4552433732313a20617070726f76652063616c6c6572206973206e6f74206f7760408201527f6e6572206e6f7220617070726f76656420666f7220616c6c0000000000000000606082015260800190565b6020808252602a908201527f4552433732313a2062616c616e636520717565727920666f7220746865207a65604082015269726f206164647265737360b01b606082015260800190565b60208082526029908201527f4552433732313a206f776e657220717565727920666f72206e6f6e657869737460408201526832b73a103a37b5b2b760b91b606082015260800190565b6020808252602e908201527f45524337323155524953746f726167653a2055524920736574206f66206e6f6e60408201526d32bc34b9ba32b73a103a37b5b2b760911b606082015260800190565b6020808252818101527f4552433732313a206d696e7420746f20746865207a65726f2061646472657373604082015260600190565b60208082526031908201527f45524337323155524953746f726167653a2055524920717565727920666f72206040820152703737b732bc34b9ba32b73a103a37b5b2b760791b606082015260800190565b6020808252602c908201527f4552433732313a20617070726f76656420717565727920666f72206e6f6e657860408201526b34b9ba32b73a103a37b5b2b760a11b606082015260800190565b6020808252602f908201527f4552433732314d657461646174613a2055524920717565727920666f72206e6f60408201526e3732bc34b9ba32b73a103a37b5b2b760891b606082015260800190565b60208082526021908201527f4552433732313a20617070726f76616c20746f2063757272656e74206f776e656040820152603960f91b606082015260800190565b60208082526031908201527f4552433732313a207472616e736665722063616c6c6572206973206e6f74206f6040820152701ddb995c881b9bdc88185c1c1c9bdd9959607a1b606082015260800190565b90815260200190565b600082198211156116bc576116bc611782565b500190565b6000826116d0576116d0611798565b500490565b6000828210156116e7576116e7611782565b500390565b60005b838110156117075781810151838201526020016116ef565b838111156105565750506000910152565b60028104600182168061172c57607f821691505b6020821081141561174d57634e487b7160e01b600052602260045260246000fd5b50919050565b600060001982141561176757611767611782565b5060010190565b60008261177d5761177d611798565b500690565b634e487b7160e01b600052601160045260246000fd5b634e487b7160e01b600052601260045260246000fd5b634e487b7160e01b600052604160045260246000fd5b6001600160e01b0319811681146117da57600080fd5b5056fea2646970667358221220f73f9713c522dba44298f05efbca01fe00f2b1ad2e9d1905f16c37313239e28964736f6c63430008010033";
        public SimpleCollectibleDeploymentBase() : base(BYTECODE) { }
        public SimpleCollectibleDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class CreateCollectibleFunction : CreateCollectibleFunctionBase { }

    [Function("createCollectible", "uint256")]
    public class CreateCollectibleFunctionBase : FunctionMessage
    {
        [Parameter("string", "tokenURI", 1)]
        public virtual string TokenURI { get; set; }
    }

    public partial class GetApprovedFunction : GetApprovedFunctionBase { }

    [Function("getApproved", "address")]
    public class GetApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

    [Function("isApprovedForAll", "bool")]
    public class IsApprovedForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2)]
        public virtual string Operator { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerOfFunction : OwnerOfFunctionBase { }

    [Function("ownerOf", "address")]
    public class OwnerOfFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFrom1Function : SafeTransferFrom1FunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFrom1FunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "_data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

    [Function("setApprovalForAll")]
    public class SetApprovalForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TokenCounterFunction : TokenCounterFunctionBase { }

    [Function("tokenCounter", "uint256")]
    public class TokenCounterFunctionBase : FunctionMessage
    {

    }

    public partial class TokenURIFunction : TokenURIFunctionBase { }

    [Function("tokenURI", "string")]
    public class TokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "approved", 2, true )]
        public virtual string Approved { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

    [Event("ApprovalForAll")]
    public class ApprovalForAllEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2, true )]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 3, false )]
        public virtual bool Approved { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

    [FunctionOutput]
    public class GetApprovedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsApprovedForAllOutputDTO : IsApprovedForAllOutputDTOBase { }

    [FunctionOutput]
    public class IsApprovedForAllOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }







    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenCounterOutputDTO : TokenCounterOutputDTOBase { }

    [FunctionOutput]
    public class TokenCounterOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TokenURIOutputDTO : TokenURIOutputDTOBase { }

    [FunctionOutput]
    public class TokenURIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}
