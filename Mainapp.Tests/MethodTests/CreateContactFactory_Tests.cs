using ContactsDomain.Factories;
using ContactsDomain.Services;
using System.Net;
using System.Numerics;

namespace Mainapp.Tests.Factories;


public class CreateContactFactory_Tests
{

    
    [Fact]
    
    public void CreateContact_ShouldReturnSameInput_WithValidData() 
    {
        //Arrange
        var firstname = "Hasse";
        var lastName = "Haraldsson";
        var email = "hasseh60@yahoo.com";
        var phone = "1234567890";
        var address = "stationsvägen 12";
        var postal = "33235";
        var city = "Gislaved";

        

        //Act
        var user = CreateContactFactory.CreateContact(firstname, lastName, email, phone, address, postal, city);
        var user2 = CreateContactFactory.CreateContact("Ana", "Linares", "Analinares68@gmail.com", "0708111380", "skoggshyddan", "50646", "Borås");

        //Assert
        Assert.Equal(firstname, user.FirstName);
        Assert.Equal(lastName, user.LastName);
        Assert.Equal(email, user.Email);
        Assert.Equal(phone, user.Phone);
        Assert.Equal(address, user.Address);
        Assert.Equal(postal, user.Postal);
        Assert.Equal(city, user.City);
        Assert.False(string.IsNullOrEmpty(user.Id));
        Assert.NotEqual(user2.Id, user.Id);
        
    }

}
