# Product & Order Microservices API

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![Microservices](https://img.shields.io/badge/Architecture-Microservices-brightgreen)
![Docker](https://img.shields.io/badge/Docker-Enabled-blue)
![Kafka](https://img.shields.io/badge/Kafka-EventDriven-orange)
![License](https://img.shields.io/badge/License-MIT-yellow)

A modern **Product & Order Management API** built with **.NET 8** using **Microservices Architecture**. This project showcases a scalable and distributed back-end system for managing products and orders, leveraging **Docker** for containerization and **Apache Kafka** for event-driven communication. Hosted on GitHub as part of my portfolio, it demonstrates my expertise in microservices design, containerization, and asynchronous messaging.

## Table of Contents
1. [Project Overview](#project-overview)
2. [Features](#features)
3. [Technologies Used](#technologies-used)
4. [Architecture](#architecture)
5. [Setup Instructions](#setup-instructions)
6. [API Endpoints](#api-endpoints)
7. [How to Run](#how-to-run)
8. [Docker & Kafka Configuration](#docker--kafka-configuration)
9. [Contributing](#contributing)
10. [License](#license)
11. [Contact](#contact)

## Project Overview
This is a back-end project designed as a microservices-based system for managing **products** and **orders**. It consists of two main services: **Product Service** and **Order Service**, communicating asynchronously via Kafka. The project uses .NET 8, Docker for containerization, and SQLite as a lightweight database (configurable for other DBMS). It’s a practical example of modern distributed systems, built to highlight my skills in microservices architecture and DevOps practices.

Goals of this project:
- Demonstrate proficiency in designing and implementing microservices.
- Showcase integration of event-driven architecture with Kafka.
- Highlight containerization skills using Docker.

## Features
- **Product Service**: CRUD operations for managing products.
- **Order Service**: Create and retrieve orders, linked to products.
- **Event-Driven Communication**: Uses Kafka to publish and consume events (e.g., order creation triggers stock updates).
- **Containerization**: Services run in Docker containers for easy deployment.
- **Scalability**: Microservices architecture enables independent scaling of services.

## Technologies Used
- **.NET 8.0**: Core framework for building microservices.
- **ASP.NET Core**: RESTful API framework for each service.
- **Entity Framework Core**: ORM for database operations.
- **SQLite**: Lightweight database (swappable to SQL Server, PostgreSQL, etc.).
- **Docker**: Containerization of services.
- **Apache Kafka**: Message broker for event-driven communication.
- **Confluent.Kafka**: .NET client for Kafka integration.
- **Swagger**: API documentation and testing.

## Architecture
The project follows **Microservices Architecture** with the following components:

1. **Product Service**:
   - Manages product data (e.g., name, price, stock).
   - Publishes events to Kafka when product stock changes.

2. **Order Service**:
   - Handles order creation and retrieval.
   - Consumes events from Kafka to update order status based on product availability.

3. **Kafka**:
   - Acts as the message broker for asynchronous communication between services.
   - Topics: `product-stock-updated`, `order-created`.

4. **Docker**:
   - Each service runs in its own container, alongside Kafka and Zookeeper.

This architecture ensures loose coupling, scalability, and fault tolerance.

## Setup Instructions
### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/)
- Optional: [Visual Studio 2022](https://visualstudio.microsoft.com/)

### Cloning the Repository
```bash
git clone https://github.com/haindvn8386/Microservice.ApacheKafka.git
cd ProductOrderMicroservices
