# EntityFrameworkRelationships

## Overview

EntityFrameworkRelationships is an ASP.NET Core Web API application designed to provide a practical understanding of database management system concepts, with a focus on exploring and implementing different types of relationships between tables.

## Purpose

The primary purpose of this project is to demonstrate proficiency in managing relationships within a relational database, specifically using Entity Framework in an ASP.NET Core environment. The project simulates a backend system for a game, showcasing various types of relationships such as one-to-one, one-to-many, and many-to-many.

## Table of Contents

- [Technologies Used](#technologies-used)
- [Key Features](#key-features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Technologies Used

- ASP.NET Core
- Entity Framework
- SQL Server

## Key Features

- **One-to-Many Relationship:**
  - Users can create multiple characters in the game, establishing a one-to-many relationship between users and characters.

- **Many-to-Many Relationship:**
  - Characters can have multiple weapons, showcasing a many-to-many relationship between characters and weapons.

- **One-to-One Relationship:**
  - Characters can possess a unique skill, demonstrating a one-to-one relationship between characters and skills.

## Database Relationships

### Users Table

- `UserID` (Primary Key)
- `Name`

### Characters Table

- `ID` (Primary Key)
- `UserID` (Foreign Key)
- `Name`
- `RpgClass`

### Weapons Table

- `ID` (Primary Key)
- `WeaponName`
- `Damage`
- `CharacterId` (Foreign Key)

### Skills Table

- `ID` (Primary Key)
- `Name`
- `Damage`

### CharacterSkill Table

- `CharacterID` (Primary Key) (Foreign Key)
- `SkillId` (Primary Key) (Foreign Key)


## Getting Started

To run this project locally, follow these steps:

1. Clone the repository.
2. Configure the connection string in the `appsettings.json` file.
3. Run the database migrations to create the necessary tables.
4. Start the ASP.NET Core Web API application.

## Usage

Explore the API endpoints to create, retrieve, and manage relationships between users, characters, weapons, and skills. The project includes interactive API documentation powered by [Swagger](https://swagger.io/), allowing you to test each API seamlessly.

To access Swagger:

1. Run the application locally.
2. Navigate to `/swagger` in your web browser.

Swagger provides an intuitive and interactive interface for testing and understanding each API endpoint. Feel free to experiment with the various endpoints and observe the relationships between different entities.



## Contributing

Contributions are welcome! Please follow the [contribution guidelines](CONTRIBUTING.md).


## Contact

For inquiries or further information, feel free to contact me:

- GitHub: [Akshdeep Singh](https://github.com/AkshdeepSingh1)
- LinkedIn: [Akshdeep Singh](https://www.linkedin.com/in/akshdeep-singh-78b1151a6/)
- Email: 11akshdeep11@gmail.com
