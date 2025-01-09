
using ContactsDomain.Interfaces;
using ContactsDomain.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json;

namespace ContactsDomain.Services;

public class FileService : IFileService
{

    private readonly string _DirectoryPath;
    private readonly string _FilePath;


    public FileService(string directoryPath = "data", string fileName = "list.json")
    {
        _DirectoryPath = directoryPath;
        _FilePath = Path.Combine(directoryPath, fileName); // i want to see if saved in this path

    }
    //--------------------------------------------------------------------------------------------------
    public void SaveListToFile(List<ContactForm> contacts)
    {
        try
        {
            if (!Directory.Exists(_DirectoryPath))
                Directory.CreateDirectory(_DirectoryPath);

            var json = JsonSerializer.Serialize(contacts); // i want to see if this content matches the file content.
            File.WriteAllText(_FilePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

    }
    //--------------------------------------------------------------------------------------------------
    public List<ContactForm> LoadListFromFile()
    {
        try
        {
            if (!File.Exists(_FilePath)) return [];

            var json = File.ReadAllText(_FilePath);
            var list = JsonSerializer.Deserialize<List<ContactForm>>(json);
            return list ?? [];

        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }
}
