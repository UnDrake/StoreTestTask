# StoreTestTask

## Overview
This is a .NET Core Web API for managing a store's customers, products, and purchases.

## Features
- **Customers**: Store and retrieve customer details.
- **Products**: Manage product inventory.
- **Purchases**: Track customer purchases with multiple items.
- **Endpoints**:
  - `GET /api/clients/birthdays?date=YYYY-MM-DD` → Returns customers with birthdays on the given date.
  - `GET /api/clients/recent-buyers?days=N` → Lists customers who made purchases in the last N days.
  - `GET /api/clients/popular-categories/{clientId}` → Returns the most purchased product categories by a customer.

## Setup & Run
1. Clone the repository:
   ```sh
   git clone https://github.com/UnDrake/StoreTestTask.git
   cd StoreTestTask
2. Install dependencies:
   ```sh
   dotnet restore
3. Apply database migrations:
   ```sh
   dotnet ef database update
4. Run the application:
   ```sh
   dotnet run
5. Open Swagger for testing:
   Go to: http://localhost:5225/swagger/index.html
   (or https://localhost:7205/swagger/index.html if running with HTTPS)

## Test Data for API Calls
1. Test GET /api/clients/birthdays  
   Input in Swagger date: 2024-03-05  
   Expected Response:
   ```md
   [
     {
       "id": 1,
       "fullName": "Alexander Ivanenko"
     }
   ]

2. Test GET /api/clients/recent-buyers   
   Input in Swagger days: 5  
   Expected Response:
   ```md
   [
     {
       "id": 1,
       "fullName": "Alexander Ivanenko",
       "lastPurchaseDate": "2024-03-03T12:00:00"
     },
     {
       "id": 3,
       "fullName": "Ivan Gordienko",
       "lastPurchaseDate": "2024-03-04T12:00:00"
     }
   ]

3. Test: GET /api/clients/popular-categories/{clientId}  
   Input in Swagger clientId: 1  
   Expected Response:
   ```md
   [
     {
       "category": "Electronics",
       "quantity": 5
     }
   ]
