using ContactsDomain.Models;
namespace ContactsDomain.Factories;

public class CreateContactFactory
{
    public static ContactForm CreateContact(string firstname, string lastname, string email, string phone, string address, string postalCode, string city)
    {
        return new ContactForm 
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = firstname
            , LastName = lastname
            , Email = email
            , Phone = phone
            ,Address = address
            ,Postal = postalCode
            , City = city
        };

    }
}
