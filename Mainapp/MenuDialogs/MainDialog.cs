using ContactsDomain.Factories;
using ContactsDomain.Interfaces;
using ContactsDomain.Models;
namespace Mainapp.MenuDialogs;

public class MainDialog
{
    public MainDialog(IContactsList contactsList) 
    {
        _contacts = contactsList;
    }
    private readonly IContactsList _contacts;
    
    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to your Contact List App");
        Console.WriteLine("### Choose one option ###");
        Console.WriteLine("");
        Console.WriteLine($"{"1.",-15} View your Contacts List");
        Console.WriteLine($"{"2.",-15} Add a Contact");
        Console.WriteLine($"{"3.",-15} Delete a Contact");
        Console.WriteLine($"{"4.",-15} Delete all Contacts");
        Console.WriteLine($"{"Q.",-15} Exit Application");
        Console.WriteLine("");
        string option = Console.ReadLine()!;
        MenuOptionHandler(option);
        
    }

    public void MenuOptionHandler( string option) 
    {
        switch (option.ToLower())
        {
            case "1":
                ViewList();
                break;

            case "2":
                CreateUser();
                break;

            case "3":
                DeleteUser();
                break;

            case "4":
                //Edit User??
                break;

            case "q":
                ExitApp();
                break;

            default:
                break;
        }
    }

    public void ViewList() 
    {
        //Håll console specifik kod till MainApp. 
        Console.Clear();
        var contacts = _contacts.ViewContacts();
        foreach (ContactForm contact in contacts) 
        {
            Console.WriteLine($"ID: {contact.Id}");
            Console.WriteLine($"Firstname: {contact.FirstName}");
            Console.WriteLine($"Lastname: {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone: {contact.Phone}");
            Console.WriteLine($"Address:{contact.Address}");
            Console.WriteLine($"Postal Code:{contact.Postal}");
            Console.WriteLine($"City:{contact.City}");
            Console.WriteLine("=======================");
        }
        Console.ReadKey();
    }

    public void CreateUser()
    {
        Console.Clear();
        Console.WriteLine("Enter your first name");
        string firstname = Console.ReadLine()!;
        Console.WriteLine("Enter your last name");
        string lastname = Console.ReadLine()!;
        Console.WriteLine("Enter your Email");
        string email = Console.ReadLine()!;
        Console.WriteLine("Enter your Phone");
        string phone = Console.ReadLine()!;
        Console.WriteLine("Enter your Adress");
        string address = Console.ReadLine()!;
        Console.WriteLine("Enter your Postal Code");
        string postalCode = Console.ReadLine()!;
        Console.WriteLine("Enter your City");
        string city = Console.ReadLine()!;
        ContactForm user = CreateContactFactory.CreateContact(firstname, lastname, email, phone, address, postalCode, city);
        
        _contacts.AddUser(user);
    }

    public void DeleteUser() 
    {

        if (_contacts.EditUserList().Count() == 0)
        {
            Console.Clear();
            Console.WriteLine("There are no customers in customerlist");
            Console.ReadKey();
            return;
        }

        int SelectedIndex = 0;
        List<ContactForm> users = _contacts.EditUserList();
        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            Console.WriteLine("Select the user you would like to delete");
            Console.WriteLine("Press Escape to cancel");

            for (int i = 0; i < users.Count; i++)
            {
                if (i == SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($">   {users[i].FirstName} {users[i].LastName}");
                    Console.ResetColor();
                }

                else
                {
                    Console.WriteLine($"{users[i].FirstName} {users[i].LastName}");
                }
            }

            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow && SelectedIndex > 0)
            {
                SelectedIndex--;
            }
            else if (key.Key == ConsoleKey.DownArrow && SelectedIndex < users.Count - 1)
            {
                SelectedIndex++;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("Deletion cancelled.");
                Console.ReadKey();
                return;
            }

        }

        while (key.Key != ConsoleKey.Enter);

        Console.Clear();
        Console.WriteLine($"Are you sure you want to delete {users[SelectedIndex].FirstName} {users[SelectedIndex].LastName}?");
        string confirmation = Console.ReadLine()!;

        if (confirmation.ToLower() == "yes")
        {
            _contacts.RemoveUser(SelectedIndex);
            Console.WriteLine("User succesfully deleted");
        }

        else
        {
            Console.WriteLine("Deletion Cancelled");
        }


    }
    

    public void ExitApp()
    {
        Console.WriteLine("Are you sure you would like to exit the application? yes/no");
        string confirmation = Console.ReadLine()!;
        if(confirmation.ToLower()=="yes")
        Environment.Exit(0);

        else return;
    }


}

