#nullable enable

using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace RevisionTwo_App.Models;

/// <summary>
///     Add profile data for application users by adding properties to the ApiDemoUser class
/// </summary>
public class DemoUser : IdentityUser
{
    [PersonalData]
    public string? FullName { get; set; } 

    [PersonalData]
    [DataType(DataType.EmailAddress)]
    public string? EmailAddress { get; set; }

}

