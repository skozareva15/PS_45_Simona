using DataLayer.Database;
using DataLayer.Model;
using System.Data;
using System.Xml.Linq;
using Welcome.Others;

namespace DataLayer
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();

                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. View all users");
                    Console.WriteLine("2. Add a new user");
                    Console.WriteLine("3. Delete an existing user");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            ViewAllUsers(context);
                            break;
                        case 2:
                            AddNewUser(context);
                            break;
                        case 3:
                            DeleteUser(context);
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
            }

            static void ViewAllUsers(DatabaseContext context)
            {
                var users = context.Users.ToList();
                if (users.Any())
                {
                    Console.WriteLine("All users:");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"ID: {user.Id}, Name: {user.names}, Role: {user.roles}");
                    }
                }
                else
                {
                    Console.WriteLine("No users found.");
                }
            }
            static void AddNewUser(DatabaseContext context)
            {
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();

                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    names = username,
                    password = password,
                    roles = UserRolesEnum.STUDENT,
                    expires = DateTime.Now,
                });
                context.SaveChanges();
                Console.WriteLine("User added successfully.");
            }

            static void DeleteUser(DatabaseContext context)
            {
                Console.WriteLine("Enter username of the user to delete:");
                string username = Console.ReadLine();

                var user = context.Users.FirstOrDefault(u => u.names == username);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    Console.WriteLine("User deleted successfully.");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
        }
    }
}
