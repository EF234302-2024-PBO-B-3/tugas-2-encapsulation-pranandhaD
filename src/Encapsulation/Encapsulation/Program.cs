using Encapsulation.Invoicing;
using Encapsulation.Employment;
using System;
using Encapsulation.Calendar;
using Encapsulation.Banking;
using Encapsulation.Extra;

namespace Encapsulation;

public class Program
{
    static void Main(string[] args)
    {
        // Invoicing
        Invoice invoice1 = new Invoice("001", "Hammer", 5, 75.0);
        Console.WriteLine($"Part Number: {invoice1.PartNumber}");
        Console.WriteLine($"Part Description: {invoice1.PartDescription}");
        Console.WriteLine($"Quantity: {invoice1.Quantity}");
        Console.WriteLine($"Price per item: {invoice1.Price}");
        Console.WriteLine($"Total Invoice Amount: {invoice1.GetInvoiceAmount()}");

        // Employee
        Employee employee1 = new Employee("John", "Doe", 3000.0);
        Employee employee2 = new Employee("Jane", "Doe", 3500.0);

        Console.WriteLine($"Yearly Salary of {employee1.FirstName} {employee1.LastName}: {employee1.GetYearlySalary()}");
        Console.WriteLine($"Yearly Salary of {employee2.FirstName} {employee2.LastName}: {employee2.GetYearlySalary()}");

        // Raise salary by 10%
        employee1.RaiseSalary(10);
        employee2.RaiseSalary(10);

        Console.WriteLine($"Yearly Salary after 10% raise for {employee1.FirstName} {employee1.LastName}: {employee1.GetYearlySalary()}");
        Console.WriteLine($"Yearly Salary after 10% raise for {employee2.FirstName} {employee2.LastName}: {employee2.GetYearlySalary()}");

        // Date
        Date validDate = new Date(12, 15, 2021);
        Date invalidDate = new Date(13, 32, 2021); // Ini akan diset ke 1/1/1970

        Console.WriteLine("Valid date:");
        validDate.DisplayDate();
        Console.WriteLine("Invalid date set to default:");
        invalidDate.DisplayDate();

        // Banking

        BankAccount account = new BankAccount("123456789", "John Doe", 1000.0);
        Console.WriteLine($"Initial balance: {account.GetBalance()}");

        account.Deposit(500.0);
        Console.WriteLine($"Balance after deposit: {account.GetBalance()}");

        account.Withdraw(200.0);
        Console.WriteLine($"Balance after withdrawal: {account.GetBalance()}");

        // Extra
        Library library = new Library();

        // Add books
        library.AddBook("978-0544003415", "The Lord of the Rings", "J.R.R. Tolkien");
        library.AddBook("978-0061120084", "To Kill a Mockingbird", "Harper Lee");
        library.AddBook("978-0141439518", "Pride and Prejudice", "Jane Austen");

        Console.WriteLine($"\nTotal books in the library: {library.GetTotalBooks()}");

        // Borrow a book
        string isbnToBorrow = "978-0544003415";
        if (library.BorrowBook(isbnToBorrow))
        {
            Console.WriteLine($"Successfully borrowed the book with ISBN: {isbnToBorrow}");
        }
        else
        {
            Console.WriteLine($"Failed to borrow the book with ISBN: {isbnToBorrow}");
        }

        // List available books
        Console.WriteLine("\nAvailable books:");
        foreach (var book in library.GetAvailableBooks())
        {
            Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN})");
        }

        // Return the book
        if (library.ReturnBook(isbnToBorrow))
        {
            Console.WriteLine($"\nSuccessfully returned the book with ISBN: {isbnToBorrow}");
        }
        else
        {
            Console.WriteLine($"\nFailed to return the book with ISBN: {isbnToBorrow}");
        }

        // List available books again
        Console.WriteLine("\nAvailable books after return:");
        foreach (var book in library.GetAvailableBooks())
        {
            Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN})");
        }
    }
}
