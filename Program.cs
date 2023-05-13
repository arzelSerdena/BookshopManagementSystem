class bookshopManagementSystem
{
        static void Main()
        {
            int book001 = 84;
            int book002 = 63;
            int book003 = 57;
            int book004 = 91;
            int book005 = 83;
        
            Console.WriteLine("BOOKSHOP MANAGEMENT SYSTEM");
            Console.WriteLine("\nMENU");
            Console.WriteLine("1. View Books");
            Console.WriteLine("2. View Stocks");
            Console.WriteLine("3. Add Stocks");
            Console.WriteLine("Press 0 to Exit.");

            Console.Write("\nEnter your choice: ");
            string? userInput = Console.ReadLine();

            while (userInput != "0")
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\nSelect a book to view more details.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                        Console.Write("\nEnter your book choice: ");

                        string? bookChoice = Console.ReadLine();

                        while (bookChoice != "0")
                        {
                            switch (bookChoice)
                            {
                                case "1":
                                    Console.WriteLine("\nBook ID: 001\nTitle: Code Complete\nAuthor: Steve McConnell\nISBN: 978-0735619678\nPublication Date: 2004\nDescription: A guide to writing high-quality software code.");

                                    Console.WriteLine("\nSelect a book to view more details.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                
                                break;

                                case "2":
                                    Console.WriteLine("\nBook ID: 002\nTitle: The Pragmatic Programmer\nAuthor: Andrew Hunt and David Thomas\nISBN: 978-0201616224\nPublication Date: 1999\nDescription: A guide to practical programming techniques.");

                                    Console.WriteLine("\nSelect a book to view more details.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                break;

                                case "3":
                                    Console.WriteLine("\nBook ID: 003\nTitle: The Mythical Man-Month\nAuthor: Frederick P. Brooks Jr.\nISBN: 978-0201835953\nPublication Date: 1995\nDescription: A classic book on software engineering, discussing project management and team organization.");

                                    Console.WriteLine("\nSelect a book to view more details.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                break;

                                case "4":
                                    Console.WriteLine("\nBook ID: 004\nTitle: Clean Code\nAuthor: Robert C. Martin\nISBN: 978-0132350884\nPublication Date: 2008\nDescription: A guide to writing clean, maintainable, and efficient code."); 

                                    Console.WriteLine("\nSelect a book to view more details.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                break;

                                case "5":
                                    Console.WriteLine("\nBook ID: 005\nTitle: Design Patterns: Elements of Reusable Object-Oriented Software\nAuthor: Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides\nISBN: 978-0201633610\nPublication Date: 1994\nDescription: A classic book on software design patterns.");

                                    Console.WriteLine("\nSelect a book to view more details.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                break;

                                
                                default:
                                    Console.WriteLine("\nInvalid input. Please try again.");

                                    Console.WriteLine("\nSelect a book to view more details.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                break;
                            }
                        }

                        Console.WriteLine("\nMENU");
                        Console.WriteLine("1. View Books");
                        Console.WriteLine("2. View Stocks");
                        Console.WriteLine("3. Add Stocks");
                        Console.WriteLine("Press 0 to Exit.");

                        Console.Write("\nEnter your choice: ");
                        userInput = Console.ReadLine();
                    break;

                    case "2":
                        Console.WriteLine(" ---------------------------------------------------------------");
                        Console.WriteLine("| BOOK ID |                BOOK TITLE               |   STOCK   |");
                        Console.WriteLine(" --------------------------------------------------------");
                        Console.WriteLine("|   001   |  Code Complete                          |     " + book001 + "    |");
                        Console.WriteLine("|   002   |  The Pragmatic Programmer               |     " + book002 + "    |");
                        Console.WriteLine("|   003   |  The Mythical Man-Month                 |     " + book003 + "    |");
                        Console.WriteLine("|   004   |  Clean Code                             |     " + book004 + "    |");
                        Console.WriteLine("|   005   |  Design Patterns: Elements of Reusable  |     " + book005 + "    |");
                        Console.WriteLine("|         |     Object-Oriented Software            |           |");
                        Console.WriteLine(" ---------------------------------------------------------------");
                        
                        Console.WriteLine("\nMENU");
                        Console.WriteLine("1. View Books");
                        Console.WriteLine("2. View Stocks");
                        Console.WriteLine("3. Add Stocks");
                        Console.WriteLine("Press 0 to Exit.");

                        Console.Write("\nEnter your choice: ");
                        userInput = Console.ReadLine();
                    break;

                    case "3":

                        Console.WriteLine("\nChoose a book to add stock.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                        Console.Write("\nEnter your book choice: ");

                        string? bookChoice2 = Console.ReadLine();

                        while (bookChoice2 != "0")
                        {
                            switch (bookChoice2)
                            {
                                case "1":
                                    Console.Write("Enter number of stock/s to add: ");
                                    int addStocks = Console.Read();

                                    book001 += addStocks;

                                    Console.WriteLine("\nBook stock has been successfully updated!");
                                    Console.WriteLine("\nChoose a book to add stock.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                
                                case "2":
                                    Console.Write("Enter number of stock/s to add: ");
                                    addStocks = Console.Read();

                                    book002 += addStocks;
                                    Console.WriteLine("\nBook stock has been successfully updated!");
                                    Console.WriteLine("\nChoose a book to add stock.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                case "3":
                                    Console.Write("Enter number of stock/s to add: ");
                                    addStocks = Console.Read();

                                    book003 += addStocks;
                                    Console.WriteLine("\nBook stock has been successfully updated!");
                                    Console.WriteLine("\nChoose a book to add stock.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                case "4":
                                    Console.Write("Enter number of stock/s to add: ");
                                    addStocks = Console.Read();

                                    book004 += addStocks;
                                    Console.WriteLine("\nBook stock has been successfully updated!");
                                    Console.WriteLine("\nChoose a book to add stock.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                case "5":
                                    Console.Write("Enter number of stock/s to add: ");
                                    addStocks = Console.Read();

                                    book005 += addStocks;
                                    Console.WriteLine("\nBook stock has been successfully updated!");
                                    Console.WriteLine("\nChoose a book to add stock.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                
                                default:
                                    Console.WriteLine("\nInvalid input. Please try again.");

                                    Console.WriteLine("\nChoose a book to add stock.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\nPress 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                            }
                        }

                        Console.WriteLine("\nMENU");
                        Console.WriteLine("1. View Books");
                        Console.WriteLine("2. View Stocks");
                        Console.WriteLine("3. Add Stocks");
                        Console.WriteLine("Press 0 to Exit.");

                        Console.Write("\nEnter your choice: ");
                        userInput = Console.ReadLine();


                    break;

                    default:
                        Console.WriteLine("\nInvalid input. Please try again.");
                        
                        Console.WriteLine("\nMENU");
                        Console.WriteLine("1. View Books");
                        Console.WriteLine("2. View Stocks");
                        Console.WriteLine("3. Add Stocks");
                        Console.WriteLine("Press 0 to Exit.");

                        Console.Write("\nEnter your choice: ");
                        userInput = Console.ReadLine();
                    break;
                
            }
        }
    }
}