using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
     internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Simona", "pass", "121221119", Others.UserRolesEnum.STUDENT);

        
                UserViewModel userViewModel = new UserViewModel(user);
                UserView view = new UserView(userViewModel);


            view.Display();
            Console.ReadKey();
                

        }
          
     }
}


