using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person_1
{
    public static class InputHelper
    {
        //Prevents empty input, whitespace, and null entries
        public static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                ShowError("Input cannot be empty. Please try again.");
            }
        }

        //Prevents crash on invalid characters, letters, overflow, or out-of-range choices
        public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (int.TryParse(input, out int result))
                {
                    if (result >= min && result <= max)
                    {
                        return result;
                    }
                    ShowError($"Please enter a number between {min} and {max}.");
                }
                else
                {
                    ShowError("Invalid input! Please enter a valid number (no letters or symbols).");
                }
            }
        }

        //Enforces valid date inputs without throwing exceptions
        public static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (YYYY-MM-DD): ");
                string input = Console.ReadLine()?.Trim();

                if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }

                ShowError("Invalid date! Must be formatted as YYYY-MM-DD (e.g., 2026-08-02).");
            }
        }

        //Asks confirmation to avoid accidental menu navigation or record actions
        public static bool ConfirmAction(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (Y/N): ");
                string input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "Y" || input == "YES") return true;
                if (input == "N" || input == "NO") return false;

                ShowError("Please enter 'Y' for Yes or 'N' for No.");
            }
        }

        //Centralized error message formatting
        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            Console.ResetColor();
        }

        //Reusable screen pause helper
        public static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }

internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Community Library Management System";

            bool running = true;

            while (running)
            {
                //Try-Catch to handle unexpected errors gracefully and prevent application crashes
                try
                {
                    Console.Clear();
                    DrawHeader();

                    Console.WriteLine("  1. Book Management");
                    Console.WriteLine("  2. Member Management");
                    Console.WriteLine("  3. Borrow & Return Transactions");
                    Console.WriteLine("  4. Reports & Analytics");
                    Console.WriteLine("  5. Exit");
                    Console.WriteLine(new string('=', 50));

                    int choice = InputHelper.ReadInt("\nSelect an option (1-5): ", 1, 5);

                    switch (choice)
                    {
                        case 1:
                            ShowBookMenu();
                            break;
                        case 2:
                            ShowMemberMenu();
                            break;
                        case 3:
                            ShowTransactionMenu();
                            break;
                        case 4:
                            ShowReportsMenu();
                            break;
                        case 5:
                            if (InputHelper.ConfirmAction("Are you sure you want to exit?"))
                            {
                                running = false;
                                Console.WriteLine("\nApplication closed successfully.");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    InputHelper.ShowError($"An unexpected error occurred: {ex.Message}");
                    Console.WriteLine("System recovered safely.");
                    InputHelper.Pause();
                }
            }
        }

        public static void DrawHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("       COMMUNITY LIBRARY MANAGEMENT SYSTEM        ");
            Console.WriteLine("==================================================");
            Console.ResetColor();
        }

        //sub-menus for each main menu option, with placeholders for Person 2, 3, and 4 methods

        public static void ShowBookMenu()
        {
            Console.Clear();
            Console.WriteLine("--- BOOK MANAGEMENT ---");
            Console.WriteLine("1. Add Book\n2. Update Book\n3. Remove Book\n4. Search Books\n5. Display All Books\n6. Back");

            int choice = InputHelper.ReadInt("\nChoose an option (1-6): ", 1, 6);
            if (choice == 6) return;

            // Person 2 methods 
            InputHelper.Pause();
        }

        public static void ShowMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("--- MEMBER MANAGEMENT ---");
            Console.WriteLine("1. Register Member\n2. Update Member\n3. Remove Member\n4. Search Members\n5. Display All Members\n6. Back");

            int choice = InputHelper.ReadInt("\nChoose an option (1-6): ", 1, 6);
            if (choice == 6) return;

            // Person 3 methods 
            InputHelper.Pause();
        }

        public static void ShowTransactionMenu()
        {
            Console.Clear();
            Console.WriteLine("--- TRANSACTIONS ---");
            Console.WriteLine("1. Borrow Book\n2. Return Book (Calculate Fines)\n3. Back");

            int choice = InputHelper.ReadInt("\nChoose an option (1-3): ", 1, 3);
            if (choice == 3) return;

            // Person 4 borrowing/return methods 
            InputHelper.Pause();
        }

        public static void ShowReportsMenu()
        {
            Console.Clear();
            Console.WriteLine("--- REPORTS & ANALYTICS ---");
            Console.WriteLine("1. Overdue Books Report\n2. Fine Summary\n3. Back");

            int choice = InputHelper.ReadInt("\nChoose an option (1-3): ", 1, 3);
            if (choice == 3) return;

            // Person 4 report methods 1
            InputHelper.Pause();
        }
    }
}
