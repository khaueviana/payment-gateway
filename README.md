# Payment Gateway Application

## About The Project

Payment Gateway to process Credit Card payments.

### Built With

- ASP.NET Web API 6.0
- FluentValidator
- MongoDB Driver
- Refit
- Mountebank
- Swagger UI

## Getting Started

### Requirements

1. Visual Studio >= 2022
2. .NET >= 6.0
3. Docker
4. Makefile
5. Docker-compose

### Running

```
make run
```

### Dependencies

```
make infra
```

## Running Unit Tests

```
make unit-tests
```

## Usage

**[POST][v1/payments]**

Process a payment with a Credit Card

**[GET][v1/payments/{id}]**

Retrieve the payment details

## Roadmap

### Features

- Refund API
- Settle API
- Cancellation API
- Support for 3DS, HPP and other payment methods

### Tech (essential)

- Authentication
- Error Handling (error contract and custom middleware)
- Logging and Telemetry
- Resilience (timeout, retries, circuit breakers, fallbacks)
- Security (as a secure vault to store credit card details)
- Component & Integration Tests