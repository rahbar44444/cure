﻿using Newtonsoft.Json;

namespace Cure.Authentication.Models
{
    public class LoginModel
    {

        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
