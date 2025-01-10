using ContactsDomain.Models;

namespace ContactsDomain.Interfaces;

public interface IContactsList
{
    void AddUser(ContactForm contact);
    IEnumerable<ContactForm> ViewContacts();

    public List<ContactForm> EditUserList();

    public void RemoveUser(int SelectedIndex);
}