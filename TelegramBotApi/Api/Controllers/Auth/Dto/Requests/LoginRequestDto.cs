using System.ComponentModel.DataAnnotations;

namespace Api.controllers.Dto.Requests;

public class LoginRequestDto
{
    [Required]
    public string UserKey { get; set; }  
    
    [Required] 
    public string Login { get; set; }

    [Required] 
    public string Password { get; set; }
}