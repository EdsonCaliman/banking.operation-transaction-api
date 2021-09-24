# banking.operation-transaction-api

Banking Operation Solution - Transaction Api

[![.NET](https://github.com/EdsonCaliman/banking.operation-transaction-api/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/EdsonCaliman/banking.operation-transaction-api/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/EdsonCaliman/banking.operation-transaction-api/badge.svg?branch=main)](https://coveralls.io/github/EdsonCaliman/banking.operation-transaction-api?branch=main)

This project is a part of a Banking Operation solution, with DDD and microservices architecture, using .Net Core.

![BankingOperations (1)](https://user-images.githubusercontent.com/19686147/133843637-85277ee1-9748-4456-befa-4b2265e3ebec.jpg)

Using a docker-compose configuration the components will be connected so that together they work as a solution.

This component will be responsible for register the transactions, attending the crud operations. It uses a mysql database to register the data.

![image](https://user-images.githubusercontent.com/19686147/134355746-75f9fdd6-2dc8-4130-8280-d314b66686c9.png)

# Bussiness Rules

 - A transaction needs to have a type (Credit/Debit) and a value.
 - The value needs to be between 0.1 and 10000.
 - The transaction needs to have a valid client to be registered.
 - A transaction cannot be changed or removed, a new entry must be generated for adjustment if necessary.
 - The transaction needs to have an Id for identification, which should be generated automatically.

# How to run

With a docker already installed:

Run first the project: https://github.com/EdsonCaliman/banking.operation-contact-api

After run:

docker-compose up -d

For swagger open the URL: http://localhost:8002/swagger

![image](https://user-images.githubusercontent.com/19686147/134511663-4b466e82-e963-4096-b702-0b66f7395ebf.png)

