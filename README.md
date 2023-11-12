**Getting Started**
  Prerequisites
    1. C- Sharp
    2. Asp.Net Core Web Api
    3. Microsoft EntityFramework
    4. Postgresql
    
**Installation**
  # Clone the repository
    git clone https://github.com/your-username/your-repo.git

  # Change into the project directory
    cd your-repo

  # Install dependencies
    dotnet restore
  # set up your database

**Running the application**
  1. dotnet build
  2. dotnet run

**Project Name**
Wallet API Creation

# Swagger Enabled
**Description**
To design an API service to be used to manage users wallet 

# Simple API Documentation 
  # GET /api/wallets/{id}
  Get a user wallet by the walletId
  
  request - GET /api/wallets/1
  
  response - {
  "id": 1,
  "name": "Sample Wallet",
  "type": "momo",
  "accountNumber": "1234567890",
  "accountScheme": "visa",
  "createdAt": "2023-01-01T12:00:00Z",
  "owner": "123-456-7890"
}

# DELETE /api/v1/wallets/{id}
Delete a wallet.
Parameters
{id} (path parameter): ID of the wallet to delete.

request - DELETE /api/wallet/2
response - {
  "message": "Wallet removed successfully."
}

# GET /api/v1/wallets
Retrieve a list of all wallets with pagination.

Parameters
page (query parameter): Page number.
limit (query parameter): Number of items per page.
offset (query parameter): Number of items to skip

request - GET /api/wallet?page=1&limit=10&offset=0
response - [
  {
    "id": 1,
    "name": "Wallet 1",
    "type": "momo",
    "accountNumber": "1234567890",
    "accountScheme": "visa",
    "createdAt": "2023-01-01T12:00:00Z",
    "owner": "123-456-7890"
  },
  {
    "id": 2,
    "name": "Wallet 2",
    "type": "card",
    "accountNumber": "9876543210",
    "accountScheme": "mastercard",
    "createdAt": "2023-01-02T12:00:00Z",
    "owner": "456-789-0123"
  },
]

# POST /api/v1/wallet/addWallet
Create a new wallet.

request body : {
  "name": "New Wallet",
  "type": "momo",
  "accountNumber": "9876543210",
  "accountScheme": "mastercard"
}

response - {
  "id": 2,
  "name": "New Wallet",
  "type": "momo",
  "accountNumber": "9876543210",
  "accountScheme": "mastercard",
  "createdAt": "2023-01-02T12:00:00Z",
  "owner": "4567890123"
}
  
