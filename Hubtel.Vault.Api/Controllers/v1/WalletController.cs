using Hubtel.Vault.Api.Models;
using Hubtel.Vault.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hubtel.Vault.Api.Controllers.v1
{
    [ApiController]
    [Authorize(Roles = "Member")]
    [Route("api/v1/wallet")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletsRepository _walletsRepository;
        public WalletController(IWalletsRepository walletsRepository)
        {
            _walletsRepository = walletsRepository;
        }

        [HttpGet("getAllWallets")]
        public async Task<IActionResult> ListAllWallet()
        {
            var allWallets = await _walletsRepository.GetAllWallets();
            if (allWallets.Count() == 0) 
            {
                return BadRequest("No wallets available");
            }
            return Ok(allWallets);
        }

        [HttpGet("userWallets")]
        [ProducesResponseType(typeof(IEnumerable<Wallet>), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> GetAllUserWallets() 
        {
            var ownerPhoneNumber = User.FindFirst(ClaimTypes.MobilePhone)?.Value;
            if (ownerPhoneNumber != null)
            {
                var userWallets = await _walletsRepository.GetUserWallets(ownerPhoneNumber);

                if (userWallets.Count() > 0)
                {
                    return Ok(userWallets);
                }
            }
            return BadRequest("No user wallet account found");
        }

        [HttpGet("{walletId}")]
        [ProducesResponseType(typeof(Wallet), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> GetWallet([FromRoute] int walletId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ownerPhoneNumber = User.FindFirst(ClaimTypes.MobilePhone)?.Value;

            if (ownerPhoneNumber != null)
            {
                var wallet = await _walletsRepository.GetWalletById(walletId, ownerPhoneNumber);
                if (wallet == null)
                {
                    return NotFound("No Wallet Found");
                }
                return Ok(wallet);
            }

            return BadRequest("No user account was found");           
        }

        [HttpPost("addWallet")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> AddWallet([FromBody] WalletRequest wallet)
        {
            var user = User;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // checking for existing wallets
            var checkForExistingResult = await _walletsRepository.CheckForExistingWallets(wallet?.AccountNumber);
            if (checkForExistingResult) 
            {
                return BadRequest($"{wallet.AccountNumber} account number already exist");
            }
            var ownerPhoneNumber = User.FindFirst(ClaimTypes.MobilePhone)?.Value;
            wallet.Owner = ownerPhoneNumber;
            var userWallets = await _walletsRepository.GetUserWallets(wallet?.Owner);
            if (userWallets != null) 
            {
                bool allowedWallets = userWallets?.Count() >= 0 && userWallets.Count() <= 5;
                if (!allowedWallets)
                {
                    return BadRequest("User cannot have more than 5 wallets accounts");
                }
            }

           // first time adding a wallet or wallet added not up to 5.
            if (wallet.Type == "card")
            {
                wallet.AccountNumber = wallet?.AccountNumber?.Substring(0, 6);
            }
            var success = await _walletsRepository.AddWallet(wallet);
            return success ? Ok("Wallet added successfully.") : BadRequest("Failed to add wallet.");
        }

        [HttpDelete("{walletId}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> RemoveWallet([FromRoute] int walletId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ownerPhoneNumber = User.FindFirst(ClaimTypes.MobilePhone)?.Value;
            var success = await _walletsRepository.RemoveWallet(walletId, ownerPhoneNumber);
            return success ? Ok("Wallet removed successfully.") : BadRequest("Failed to remove wallet.");
        }
    }
}
