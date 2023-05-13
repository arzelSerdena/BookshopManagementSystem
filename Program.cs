class bookshopManagementSystem
{
        static void Main()
        {
            int book001 = 84;
            int book002 = 63;
            int book003 = 57;
            int book004 = 91;
            int book005 = 83;
        
            Console.WriteLine("BOOKSHOP MANAGEMENT SYSTEM \n");
            Console.WriteLine("MENU");
            Console.WriteLine("1. View Books");
            Console.WriteLine("2. View Stocks");
            Console.WriteLine("3. Add Stocks");
            Console.WriteLine("5. Exit");

            Console.Write("\nEnter your choice: ");
            string? userInput = Console.ReadLine();

            while (userInput != "1" || userInput != "2" || userInput != "3" || userInput != "4")
            {
                if (userInput == "1")
                {
                    
                    Console.WriteLine("\nSelect a book to view more details.\n\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5. Design Patterns: Elements of Reusable Object-Orienn Vted Software\n6. Back to Menu");

                    Console.Write("\nEnter your book choice: ");

                    string? bookChoice = Console.ReadLine();

                    while (bookChoice != "1" || bookChoice != "2" || bookChoice != "3" || bookChoice != "4" || bookChoice != "5" || bookChoice != "6");

                    // BOOK DETAILS
                }
                else if (userInput == "2")
                {
                    Console.WriteLine(" --------------------------------------------------------");
                    Console.WriteLine("|   005   |  Design Patterns: Elements of Reusable  | 83 |");
                    Console.WriteLine("| BOOK ID |                BOOK TITLE               |   STOCK   |");
                    Console.WriteLine(" --------------------------------------------------------");
                    Console.WriteLine("|   001   |  Code Complete                          | " + book001 + " |");
                    Console.WriteLine("|   002   |  The Pragmatic Programmer               | " + book002 + " |");
                    Console.WriteLine("|   003   |  The Mythical Man-Month                 | " + book003 + " |");
                    Console.WriteLine("|   004   |  Clean Code                             | " + book004 + " |");
                    Console.WriteLine("|   005   |  Design Patterns: Elements of Reusable  | " + book005 + " |");
                    Console.WriteLine("|         |     Object-Oriented Software            |           |");
                    Console.WriteLine(" --------------------------------------------------------");
                    
                    Console.WriteLine("Press 0 to go back to MENU.");
                    string? userInput2 = Console.ReadLine();

                    while (userInput2 != "0")
                    {
                        Console.WriteLine("Invalid Code. Press 0 to go back to MENU.");
                    }
                }
                else if (userInput == "3")
                {

                }
            }



            switch (userInput)
            {
                case "1":
                    // view books

                    string bookChoice = "1";
                    

                    if (bookChoice == "1")
                    {
                        Console.WriteLine("\n1. Book ID: 001\n   Title: Code Complete\n   Author: Steve McConnell\n   ISBN: 978-0735619678\n   Publication Date: 2004\n   Description: A guide to writing high-quality software code.");
                        Console.WriteLine("\nEnter 0 to view more books.\nEnter 1 to go back to main menu.\n");

                        string? menuChoice = Console.ReadLine();

                        if (menuChoice == "0")
                        {
                            Console.WriteLine("\n1. Code Complete\n2. The Pragmatic Programmer\n3. The Mythical Man-Month\n4. Clean Code\n5.Design Patterns: Elements of Reusable Object-Orienn Vted Software\n6. Back to Menu");

                            Console.Write("Enter your book choice: ");

                            string? bookChoice2 = Console.ReadLine();


                        }
                        else if (menuChoice == "1")
                        {
                            Console.WriteLine("MENU");
                            Console.WriteLine("1. View Books");
                            Console.WriteLine("2. View Stocks");
                            Console.WriteLine("3. Add Stocks");
                            Console.WriteLine("4. Exit");

                            Console.Write("\nEnter your choice: ");
                            string? userInput2 = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice.");
                        }


                    }
                    else if (bookChoice == "2")
                    {
                        Console.WriteLine("2. Book ID: 002\n   Title: The Pragmatic Programmer\n   Author: Andrew Hunt and David Thomas\n   ISBN: 978-0201616224\n   Publication Date: 1999\n   Description: A guide to practical programming techniques.");
                    }
                    else if (bookChoice == "3")
                    {
                        Console.WriteLine("3. Book ID: 003\n   Title: The Mythical Man-Month\n   Author: Frederick P. Brooks Jr.\n   ISBN: 978-0201835953\n   Publication Date: 1995\n   Description: A classic book on software engineering, discussing project management and team organization.");
                    }
                    else if (bookChoice == "4")
                    {
                        Console.WriteLine("4. Book ID: 004\n   Title: Clean Code\n   Author: Robert C. Martin\n   ISBN: 978-0132350884\n   Publication Date: 2008\n   Description: A guide to writing clean, maintainable, and efficient code.");
                    }
                    else if (bookChoice == "5")
                    {
                        Console.WriteLine("5. Book ID: 005\n   Title: Design Patterns: Elements of Reusable Object-Oriented Software\n   Author: Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides\n   ISBN: 978-0201633610\n   Publication Date: 1994\n   Description: A classic book on software design patterns.");
                    }
                    else if (bookChoice == "6")
                    {
                        Console.WriteLine("MENU");
                        Console.WriteLine("1. View Books");
                        Console.WriteLine("2. View Stocks");
                        Console.WriteLine("3. Add Stocks");
                        Console.WriteLine("4. Exit");

                        Console.Write("\nEnter your choice: ");
                        string? userInput2 = Console.ReadLine();
                    }

                    
                break;

                
            }

            

            

        }
}