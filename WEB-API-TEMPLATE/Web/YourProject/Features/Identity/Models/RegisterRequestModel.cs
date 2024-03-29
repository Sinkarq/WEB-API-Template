﻿using CommunityToolkit.Diagnostics;
using YourProject.Common;

namespace YourProject.Server.Features.Identity.Models;

public class RegisterRequestModel
{
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
}
