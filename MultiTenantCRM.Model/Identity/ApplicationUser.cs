using Microsoft.AspNetCore.Identity;
using MultiTenantCRM.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTenantCRM.Model.Identity;

// Add profile data for application users by adding properties to the MultiTenantCRMAPIUser class
public class ApplicationUser : IdentityUser
{

    public string? firstname { get; set; }
    public string? lastname { get; set; }

    public Gender?  gender { get; set; } 

    public DateTime? dateofbirth { get; set; }

    public DateTime? registrationdate { get; set; }

    public  short? verificationcode { get; set; }

    public string? imagename { get; set; }   
    public bool? activity {  get; set; }

    [NotMapped]
    public string? fullname => $"{firstname}{lastname}";

}

