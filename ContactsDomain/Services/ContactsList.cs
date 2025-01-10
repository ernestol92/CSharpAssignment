using ContactsDomain.Interfaces;
using ContactsDomain.Models;


namespace ContactsDomain.Services;

public class ContactsList : IContactsList
{
    public ContactsList(IFileService fileService)
    {
        _fileService = fileService;
    }


    private readonly List<ContactForm> _contacts = new List<ContactForm>();
    private readonly IFileService _fileService;

    public void AddUser(ContactForm contact)
    {
        _contacts.Add(contact);
        _fileService.SaveListToFile(_contacts);

    }

    public IEnumerable<ContactForm> ViewContacts()
    {
        var savedlist = _fileService.LoadListFromFile();
        return savedlist;
    }

    public List<ContactForm> EditUserList()
    {
        return _contacts;
    }

    public void RemoveUser(int SelectedIndex)
    {
        _contacts.Remove(_contacts[SelectedIndex]);
    }
}
