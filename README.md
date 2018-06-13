# Pw Refactoring

Refactoring and unit tests.

## Description of the problem and solution

It is not currently possible to unit test the `CreatePartInvoice()` method due to dependency to database connections and service client.
The solution is to use dependency injection through the constructor of `PartInvoiceController` class.

## How to test

A unit test project is created to test the `CreatePartInvoice()` method.
Created mock implementation for database connections and service client.

Failure test cases:
* Empty stock code
* Quantity == 0
* CustomerID <= 0
* Availability <= 0

Success test case:
* Stock code not empty && quantity > 0 && CustomerID > 0 && Availability > 0

## Reasoning behind technical choices

By extracting `PartInvoiceController`'s dependencies and injecting them through it's contructor, we have control to pass any implementation into the `PartInvoiceController` class, either production code or test code.

## Possible improvements

Test coverage can be made more comprehensive. For example, using mock database to test database operations.
