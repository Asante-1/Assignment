using Dapper;
using Hubtel.Vault.Api.Data;
using Hubtel.Vault.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using static Hubtel.Vault.Api.Data.AppDbContext;

namespace Hubtel.Vault.Api.Repository
{
    public interface IWalletsRepository
    {
        Task<bool> AddWallet(WalletRequest wallet);
        Task<Wallet> GetWalletById(int Id, string ownerPhoneNumber);
        Task<IEnumerable<Wallet>> GetAllWallets(int page = 1, int limit = 10, int offset = 0);
        Task<bool> RemoveWallet(int walletId, string ownerPhoneNumber);
        Task<bool> CheckForExistingWallets(string accountNumber);
        Task<IEnumerable<Wallet>> GetUserWallets(string owner);
    }
    public class WalletsRepository : IWalletsRepository
    {
        private readonly DapperContext _context;
        private readonly AppDbContext _dbContext;
        public WalletsRepository(AppDbContext dbContext, DapperContext dapperContext)
        {
                _dbContext = dbContext;
                _context = dapperContext;
        }

        public async Task<IEnumerable<Wallet>> GetAllWallets(int page, int limit, int offset)
        {
            using (var connection = _context.CreateConnection())
            {
                string sqlQuery = @"SELECT * FROM public.wallet ORDER BY id OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";
                var wallets = await connection.QueryAsync<Wallet>(sqlQuery, new { Offset = offset, Limit = limit}).ConfigureAwait(false);
                return wallets;
            }
        }

        public async Task<Wallet> GetWalletById(int walletId, string ownerPhoneNumber)
        {
            using (var connection = _context.CreateConnection())
            {
                string sqlQuery = @"SELECT * FROM public.wallet WHERE id = @WalletId AND owner = @Owner";

                var wallet = await connection.QueryFirstOrDefaultAsync<Wallet>(sqlQuery, new { WalletId = walletId, Owner = ownerPhoneNumber }).ConfigureAwait(false);
                return wallet;
            }
        }
         
        public async Task<bool> CheckForExistingWallets(string accountNumber)
        {
            using (var connection = _context.CreateConnection())
            {
                string sqlQuery = @"SELECT COUNT(*) FROM public.wallet WHERE account_number = @AccountNumber";

                var result = await connection.ExecuteScalarAsync<int>(sqlQuery, new { AccountNumber = accountNumber }).ConfigureAwait(false);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }
    
        public async Task<bool> RemoveWallet(int walletId, string ownerPhoneNumber)
        {
            using (var connection = _context.CreateConnection())
            {
                string sqlQuery = @"DELETE FROM public.wallet WHERE id = @WalletId AND owner = @Owner";

                var result = await connection.ExecuteAsync(sqlQuery, new { Owner = ownerPhoneNumber, WalletId = walletId }).ConfigureAwait(false);
                return result > 0;
            }          
        }

        public async Task<IEnumerable<Wallet>> GetUserWallets(string owner)
        {
            using (var connection = _context.CreateConnection())
            {
                string sqlQuery = @"SELECT * FROM public.wallet WHERE owner = @Owner";

                var userWallet = await connection.QueryAsync<Wallet>(sqlQuery, new { Owner = owner });
                return userWallet;
            }
        }

        public async Task<bool> AddWallet(WalletRequest wallet)
        {
            string sqlQuery = @"INSERT INTO public.wallet (name, type, account_number, account_scheme, created_at, owner) " +
            "VALUES (@Name, @Type, @AccountNumber, @AccountScheme, @CreatedAt, @Owner)";

            using (var connection = _context.CreateConnection())
            {
                var addWalletResult = await connection.ExecuteAsync(sqlQuery, new
                {
                    wallet.Name,
                    wallet.Type,
                    wallet.AccountNumber,
                    wallet.AccountScheme,
                    CreatedAt = DateTime.UtcNow,
                    Owner = wallet.Owner
                }).ConfigureAwait(false);
                return addWalletResult > 0;   
            }
        }
    }
}
