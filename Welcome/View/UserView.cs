using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
            private UserViewModel _viewModel;

            public UserView(UserViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void Display()
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("User: " + _viewModel.Name);
                Console.WriteLine("Role: " + _viewModel.UserRolesEnum);
                Console.WriteLine("\n");
            }

        public void display()
        {
            throw new NotImplementedException();
        }

        public void DisplayDetailed()
            {
                Console.WriteLine("Welcome to the Detailed View");
                Console.WriteLine($"User: {_viewModel.Name}");
                Console.WriteLine($"Role: {_viewModel.UserRolesEnum.ToString()}");
                Console.WriteLine($"Faculty Number: {_viewModel.FacultyNumber}");
       
                Console.WriteLine("Here, you can see all the detailed information about the user.");
                Console.WriteLine("\n");
            }

        }
    }
