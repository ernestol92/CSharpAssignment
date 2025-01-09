
using ContactsDomain.Factories;
using ContactsDomain.Models;
using ContactsDomain.Services;
using System.Runtime.CompilerServices;

namespace Mainapp.Tests.MethodTests;

public class FileService_Tests
{

    private readonly string _testDirectory = "test_data";
    private readonly string _testFileName = "test_list.json";
    private readonly List<ContactForm> _testList = new List<ContactForm>();

    [Fact]

    public void SaveListToFile_ShouldCreateDirectoryAndWriteFile() 
    {
        //Arrange
        
        FileService fileService = new FileService(_testDirectory, _testFileName);
        var user = CreateContactFactory.CreateContact("Arthur", "Gunn", "ArtGunn@gmail.com", "0708111380273", "skoggshyddan", "50646", "Borås");
        _testList.Add(user);
        //Act
        fileService.SaveListToFile(_testList);
        //Assert
        var FilePath = Path.Combine(_testDirectory, _testFileName);
        Assert.True(File.Exists(FilePath),"The File was not created");

        var fileContent = File.ReadAllText(FilePath);
        Assert.Contains("Arthur", fileContent);
    }

    [Fact]

    public void LoadListFromFile_ShouldReturnDeserializedList() 
    {
        FileService fileService = new FileService(_testDirectory, _testFileName);
        var user = CreateContactFactory.CreateContact("Arthur", "Gunn", "ArtGunn@gmail.com", "0708111380273", "skoggshyddan", "50646", "Borås");
        _testList.Add(user);
        fileService.SaveListToFile(_testList);
        var _FilePath = Path.Combine(_testDirectory, _testFileName);
        //Act
        var list = fileService.LoadListFromFile();

        //Assert
        Assert.Single(list);
        var deserializedUser = list.First();
        Assert.Equal("Arthur", deserializedUser.FirstName);
        Assert.Equal("Gunn", deserializedUser.LastName);
        Assert.Equal("ArtGunn@gmail.com", deserializedUser.Email);
        Assert.Equal("0708111380273", deserializedUser.Phone);
        Assert.Equal("skoggshyddan", deserializedUser.Address);
        Assert.Equal("50646", deserializedUser.Postal);
        Assert.Equal("Borås", deserializedUser.City);
        // Good to verify each property in a list as serialization or deserialization can fail on single properties.
    }

}
