using ContactsDomain.Models;

namespace ContactsDomain.Interfaces;

public interface IFileService
{
    List<ContactForm> LoadListFromFile();
    void SaveListToFile(List<ContactForm> contacts);
}