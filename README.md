# ProductsAPI

## Overview
This project implements a RESTful API for managing products and stock levels. It supports CRUD operations on products and allows adding/removing stock.

## Features
- CRUD operations on products
- Add/remove stock to products
- Concurrency handling
- Validation and error handling
- Swagger UI for API testing
- Unit tests for business logic

## Setup Instructions

## 1. Clone the repository:
```

git clone https://github.com/CJX3M/ProductsAPI.git
cd ProductsAPI

```
## 2. Execute the project

```
cd ProductAPI
dotnet run

Open your prefered Browser
Enter http://localhost:5080
```

## 3. Execute the project unitary test

```
cd ProducstAPI.test
dotnet test
```

The projects run InMemory for stup simplicity, and preload with 10 items ready to be used 

| Id | Name | Description | Price | Stock |
| :-- | :-- | :-- | :-- | :-- |
| 1 | Apple iPhone 13 | 128GB, Blue | 799.99 | 30 |
| 2 | Samsung Galaxy S21 | 128GB, Phantom Gray | 699.99 | 100 |
| 3 | Google Pixel 6 | 128GB, Sorta Seafoam | 599.99 | 60 |
| 4 | Apple MacBook Pro | 13", M1, 256GB SSD | 1299.99 | 45 |
| 5 | Dell XPS 13 | 13", i7, 512GB SSD | 1099.99 | 25 |
| 6 | HP Spectre x360 | 14", i5, 256GB SSD | 999.99 | 10 |
| 7 | Apple iPad Pro | 11", 128GB, Silver | 799.99 | 27 |
| 8 | Samsung Galaxy Tab S7 | 11", 128GB, Mystic Black | 649.99 | 36 |
| 9 | Amazon Fire HD 10 | 10.1", 32GB, Black | 149.99 | 61 |
| 10 | Herman Miller Aeron | Ergonomic Office Chair | 1199.99 | 76 |

## License
MIT License © 2024 Carlos López

Created with using .Net Core 8
