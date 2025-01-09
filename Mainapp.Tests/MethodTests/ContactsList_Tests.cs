
using ContactsDomain.Factories;
using ContactsDomain.Models;
using ContactsDomain.Services;

namespace Mainapp.Tests.Factories;

public class ContactsList_Tests


{

    
    //First methodtest (AddUser) written with AI. The code provides fileservice to AddUser to test if it saves to File.
    //It then looks inside the list and checks if exactly one object has been saved(assert single). Tests if objects properties match with given string values.
    
    
    private const string TestDirectoryPath = "test_data";
    private const string TestFileName = "test_list.json";
    
    
    [Fact]
    public void AddUser_ShouldPutContactInListAndSaveListToFile()
    {


        var fileService = new FileService(TestDirectoryPath, TestFileName);
        var contactsList = new ContactsList(fileService);
        //Arrange
        var user = CreateContactFactory.CreateContact("Arthur", "Gunn", "ArtGunn@gmail.com", "0708111380273", "skoggshyddan", "50646", "Borås");

        //Act

        contactsList.AddUser(user);

        var savedContacts = fileService.LoadListFromFile();
        Assert.Single(savedContacts);
        Assert.Equal("Arthur", savedContacts[0].FirstName);
        Assert.Equal("Gunn", savedContacts[0].LastName);
    }


    //--------------------------------------------------------------------------------------------------------------------------------------------------------
    
    
    [Fact]

    public void ViewList_ShouldLoadListFromFile_ReturnsListObject() 
    {
        //arrange
        var fileService = new FileService(TestDirectoryPath, TestFileName);
        var contactsList = new ContactsList(fileService);
        var user = CreateContactFactory.CreateContact("Arthur", "Gunn", "ArtGunn@gmail.com", "0708111380273", "skoggshyddan", "50646", "Borås");
        contactsList.AddUser(user);
        //act
        var containsobject = contactsList.ViewContacts().ToList();
        
        
        //assert

        Assert.Single(containsobject);
        Assert.Equal("Arthur", containsobject[0].FirstName);

    }



}

