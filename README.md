# Libro

Your bookshop system should support the following features:

## A. Book Management:

- Each book should have detailed information such as title, author(s), genre, publication date, ISBN, and price.
- Implement CRUD (Create, Read, Update, Delete) operations for books.
- Implement CRUD for cities but only prepare the table and models manually, and manually enter a few cities.
- Implement CRUD for genres but only prepare the table and models manually, and manually enter a few genres.
- Implement CRUD for authors but only prepare the table and models manually, and manually enter a few authors.
- Design an API for getting a list of books with the following features:
    - Search by book description and title.
    - Pagination.
    - Filtering books by price range, genre, and the city of the author's birthplace (filter by their IDs).
    - Sorting by price from cheapest to most expensive.
    - Because these operations will be slow in SQL databases, perform them in a NoSQL database (only the operation of getting the list of books should be done with NoSQL).
    - It's better to use Kafka or RabbitMQ for transferring data to NoSQL.

## B. Member Management:

- Each member should have a profile (name, last name, membership type, membership expiration date).
- Each member should be able to log in using OTP (One-Time Password) (instead of sending SMS, print the SMS text in the console).
    - Have several functions for sending SMS, for example, one function sends an SMS via Kavenegar, and another function sends SMS via Signal Company.
    - Implement the circuit breaker pattern for these two functions so that if one of them goes offline, the other one takes over.
    - For better implementation of these two functions, use an interface (OOP concept) or an appropriate design pattern.
- Implement a section for purchasing a special membership (a one-month membership for 200,000 Tomans).
- After verifying the OTP, provide a JWT token.
- The token should be manageable, meaning that we can invalidate a user's token so they have to log in again.
- Getting OTP and verifying it should have throttling (5 times in two minutes and 10 times in an hour).

## C. Book Reservation:

- Each person can reserve a book for up to 1 week.
    - Special members can reserve books for up to 2 weeks (free of charge).
    - Regular members will be charged 1,000 Tomans per day for book reservations.
        - If they have read more than 3 different books in the past month, they will receive a 30% discount.
        - If their total payments in the past two months have exceeded 300,000 Tomans, they should be exempt from fees.
- There should be no race condition when reserving a book at the same time for two people. Use optimistic locking to handle this.
- Special members can easily reserve any book.
- The list of reserved books for each person should be viewable.

## Design Requirements:

1. All mentioned APIs should have validation.
2. During design, you won't create APIs directly. Instead, you'll create services. These services are the use cases of the system and are the services your system will provide via APIs.
    - For example, the `create_user` API calls the `CreateUserUsecase` service.
3. When designing the system, consider what your entities are. Entities are equivalent to your models, and you should develop your entities as rich domain models.
    - An entity should be able to validate itself (e.g., a product with a negative price should not be allowed).
    - The fields of an entity should change via its methods, and no one should change them manually (e.g., if you want to change the status of a book to 'reserved', the `reserve` entity should have a method for reserving, rather than manually setting `reserve.status = 'reserved'`).
4. In use cases, you'll work with entities. You'll take them, change them, and store them.
    - These entities will be provided to the repository for storage.

### Read more:

- **Inversion of Control and Hexagonal Architecture:**
Learn about the concept of Inversion of Control and the Hexagonal Architecture at [here](https://www.happycoders.eu/software-craftsmanship/hexagonal-architecture/).
- **Repository Pattern:**
In simple terms, in a use case, you should not query or change data directly. All interactions with the database happen through an interface called a repository, and the use case doesn't need to know about the database. It thinks we're putting data in an array, and whenever we want it back, we get it from there.
Learn more at [here](https://www.cosmicpython.com/book/chapter_02_repository.html).
- **More Reading When You Have Time:**
Understanding the Operating System and Code Execution:
Linux: Learn about Linux commands at [here](https://www.hostinger.com/tutorials/linux-commands).
Basics (Non-Critical): Understand the basics of operating systems at [here](https://www.tutorialspoint.com/operating_system/os_overview.htm).
Memory Management: Demystify memory management in modern programming languages at [here](https://dev.to/deepu105/demystifying-memory-management-in-modern-programming-languages-ddd).
Input/Output and Hardware: Explore input/output operations and hardware interaction at [here](https://www.tutorialspoint.com/operating_system/os_io_hardware.htm).
Inter-Process Communication: Learn about inter-process communication at [here](https://www.geeksforgeeks.org/inter-process-communication-ipc/).
Computer Networking: Get insights into computer networking at [here](https://aws.amazon.com/what-is/computer-networking/).
- **Critical Concepts:**
Programs, Processes, and Threads: Understand the differences between programs, processes, and threads at [here](https://www.backblaze.com/blog/whats-the-diff-programs-processes-and-threads/).
Operating System Process Management: Dive into operating system process management at [here](https://medium.com/@akhandmishra/operating-system-process-and-process-management-108d83e8ce60).
- **Database Concepts:**
What Is an ORM: Learn what an Object-Relational Mapping (ORM) is and how it works at [here](https://stackoverflow.com/questions/1279613/what-is-an-orm-how-does-it-work-and-how-should-i-use-one).
ACID-Compliant Database: Explore the concept of ACID-compliant databases at [here](https://retool.com/blog/whats-an-acid-compliant-database/).
Database Transactions: Understand database transactions at [here](https://fauna.com/blog/database-transaction).
N+1 Query Problem: Learn about the N+1 query problem and how to fix it at [here](https://medium.com/doctolib/understanding-and-fixing-n-1-query-30623109fe89).
Database Normalization: Dive into database normalization at [here](https://www.guru99.com/database-normalization.html).
- **Login Concepts:**
User Authentication: Explore user authentication at [here](https://swoopnow.com/user-authentication/).
Single Sign-On (SSO): Learn about Single Sign-On (SSO) at [here](https://roadmap.sh/guides/sso).
OAuth: Understand OAuth at [here](https://roadmap.sh/guides/oauth).
JWT Authentication: Get insights into JWT authentication at [here](https://roadmap.sh/guides/jwt-authentication) and [here](https://jwt.io/introduction).
Introduction to OAuth 2: Learn about OAuth 2 at [here](https://www.digitalocean.com/community/tutorials/an-introduction-to-oauth-2).
OpenID Connect: Explore OpenID Connect at [here](https://openid.net/developers/how-connect-works/).
- **Design Patterns:
All design patterns are available on this page: [here](https://learn.microsoft.com/en-us/azure/architecture/patterns/).
As well as all subcategories on this page: [here](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/).
