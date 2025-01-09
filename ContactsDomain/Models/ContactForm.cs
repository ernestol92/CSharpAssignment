using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDomain.Models;

public class ContactForm
{
    public string Id = Guid.NewGuid().ToString();   
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Postal { get; set; } = null!;
    public string City { get; set; } = null!;


    //often no need for testing data containers.
    
}
