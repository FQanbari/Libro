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
