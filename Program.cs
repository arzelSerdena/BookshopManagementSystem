class bookshopManagementSystem
{
        static void Main()
        {
            int book001 = 84;
            int book002 = 63;
            int book003 = 57;
            int book004 = 91;
            int book005 = 83;

            Console.WriteLine("\n ------------------------------ ");
            Console.WriteLine("|  BOOKSHOP MANAGEMENT SYSTEM  |");
            Console.WriteLine(" ------------------------------ ");

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
                        Console.WriteLine("\nSelect a book to view more details.\n");
                        Console.WriteLine("1. Code Complete");
                        Console.WriteLine("2. The Pragmatic Programmer");
                        Console.WriteLine("3. The Mythical Man-Month");
                        Console.WriteLine("4. Clean Code");
                        Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                        Console.WriteLine("Press 0 to go back to Menu.");

                        Console.Write("\nEnter your book choice: ");

                        string? bookChoice = Console.ReadLine();

                        while (bookChoice != "0")
                        {
                            switch (bookChoice)
                            {
                                case "1":
                                   
                                    Console.WriteLine("\n --------------------------------------------------------------------- ");
                                    Console.WriteLine("| Book ID     | 001                                                   |");
                                    Console.WriteLine("| Title       | Code Complete                                         |");
                                    Console.WriteLine("| Author      | Steve McConnell                                       |");
                                    Console.WriteLine("| Description | A guide to writing high-quality software code.        |");
                                    Console.WriteLine("| Publication | 2004                                                  |");
                                    Console.WriteLine("| ISBN        | 978-0735619678                                        |");
                                    Console.WriteLine(" --------------------------------------------------------------------- ");

                                    Console.WriteLine("\nSelect a book to view more details.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                
                                break;

                                case "2":
                                    
                                    Console.WriteLine("\n --------------------------------------------------------------------- ");
                                    Console.WriteLine("| Book ID     | 002                                                   |");
                                    Console.WriteLine("| Title       | The Pragmatic Programmer                              |");
                                    Console.WriteLine("| Author      | Andrew Hunt and David Thomas                          |");
                                    Console.WriteLine("| Description | A guide to practical programming techniques.          |");
                                    Console.WriteLine("| Publication | 1999                                                  |");
                                    Console.WriteLine("| ISBN        | 978-0201616224                                        |");
                                    Console.WriteLine(" --------------------------------------------------------------------- ");

                                    Console.WriteLine("\nSelect a book to view more details.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                break;

                                case "3":
                                    
                                    Console.WriteLine("\n ------------------------------------------------------------------------- ");
                                    Console.WriteLine("| Book ID     | 003                                                       |");
                                    Console.WriteLine("| Title       | The Mythical Man-Month                                    |");
                                    Console.WriteLine("| Author      | Frederick P. Brooks Jr.                                   |");
                                    Console.WriteLine("| Description | Discussion on project management and team organization.   |");
                                    Console.WriteLine("| Publication | 1995                                                      |");
                                    Console.WriteLine("| ISBN        | 978-0201835953                                            |");
                                    Console.WriteLine(" ------------------------------------------------------------------------- ");

                                    Console.WriteLine("\nSelect a book to view more details.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                break;

                                case "4":
                                    
                                    Console.WriteLine("\n ----------------------------------------------------------------------------- ");
                                    Console.WriteLine("| Book ID     | 004                                                           |");
                                    Console.WriteLine("| Title       | Clean Code                                                    |");
                                    Console.WriteLine("| Author      | Robert C. Martin                                              |");
                                    Console.WriteLine("| Description | A guide to writing clean, maintainable, and efficient code.   |");
                                    Console.WriteLine("| Publication | 2008                                                          |");
                                    Console.WriteLine("| ISBN        | 978-0132350884                                                |");
                                    Console.WriteLine(" ----------------------------------------------------------------------------- ");

                                    Console.WriteLine("\nSelect a book to view more details.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                break;

                                case "5":
                                    
                                    Console.WriteLine("\n ------------------------------------------------------------------------------ ");
                                    Console.WriteLine("| Book ID     | 005                                                            |");
                                    Console.WriteLine("| Title       | Elements of Reusable Object-Oriented Software                  |");
                                    Console.WriteLine("| Author      | Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides   |");
                                    Console.WriteLine("| Description | A classic book on software design patterns.                    |");
                                    Console.WriteLine("| Publication | 1994                                                           |");
                                    Console.WriteLine("| ISBN        | 978-0201633610                                                 |");
                                    Console.WriteLine(" ------------------------------------------------------------------------------ ");

                                    Console.WriteLine("\nSelect a book to view more details.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice = Console.ReadLine();
                                break;

                                
                                default:
                                    Console.WriteLine("\nInvalid input. Please try again.");

                                    Console.WriteLine("\nSelect a book to view more details.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

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
                        Console.WriteLine("\n ---------------------------------------------------------------");
                        Console.WriteLine("| BOOK ID |                BOOK TITLE               |   STOCK   |");
                        Console.WriteLine(" ---------------------------------------------------------------");
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
                        Console.WriteLine("\nChoose a book to add stock.\n");
                        Console.WriteLine("1. Code Complete");
                        Console.WriteLine("2. The Pragmatic Programmer");
                        Console.WriteLine("3. The Mythical Man-Month");
                        Console.WriteLine("4. Clean Code");
                        Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                        Console.WriteLine("Press 0 to go back to Menu.");

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

                                    Console.WriteLine("\nChoose a book to add stock.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                
                                case "2":
                                    Console.Write("Enter number of stock/s to add: ");
                                    addStocks = Console.Read();

                                    book002 += addStocks;
                                    Console.WriteLine("\nBook stock has been successfully updated!");

                                    Console.WriteLine("\nChoose a book to add stock.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                case "3":
                                    Console.Write("Enter number of stock/s to add: ");
                                    addStocks = Console.Read();

                                    book003 += addStocks;
                                    Console.WriteLine("\nBook stock has been successfully updated!");

                                    Console.WriteLine("\nChoose a book to add stock.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                case "4":
                                    Console.Write("Enter number of stock/s to add: ");
                                    addStocks = Console.Read();

                                    book004 += addStocks;
                                    Console.WriteLine("\nBook stock has been successfully updated!");

                                    Console.WriteLine("\nChoose a book to add stock.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                case "5":
                                    Console.Write("Enter number of stock/s to add: ");
                                    addStocks = Console.Read();

                                    book005 += addStocks;
                                    Console.WriteLine("\nBook stock has been successfully updated!");

                                    Console.WriteLine("\nChoose a book to add stock.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

                                    Console.Write("\nEnter your book choice: ");

                                    bookChoice2 = Console.ReadLine();
                                break;
                                
                                default:
                                    Console.WriteLine("\nInvalid input. Please try again.");

                                    Console.WriteLine("\nChoose a book to add stock.\n");
                                    Console.WriteLine("1. Code Complete");
                                    Console.WriteLine("2. The Pragmatic Programmer");
                                    Console.WriteLine("3. The Mythical Man-Month");
                                    Console.WriteLine("4. Clean Code");
                                    Console.WriteLine("5. Design Patterns: Elements of Reusable Object-Oriented Software");
                                    Console.WriteLine("Press 0 to go back to Menu.");

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