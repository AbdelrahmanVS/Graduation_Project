using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class User
{
    public int UsersId { get; set; }

    public string? UserName { get; set; }

    public string? Country { get; set; }

    public int? Password { get; set; }

    public string? Gmail { get; set; }

    
}
