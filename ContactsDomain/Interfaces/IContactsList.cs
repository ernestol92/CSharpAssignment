using ContactsDomain.Models;

namespace ContactsDomain.Interfaces;

public interface IContactsList
{
    void AddUser(ContactForm contact);
    IEnumerable<ContactForm> ViewContacts();
}