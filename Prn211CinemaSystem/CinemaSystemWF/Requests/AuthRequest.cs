using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemeSystemWF.Requests
{
    public class AuthRequest : HttpRequest
    {
        private const string LOGIN_URL = "http://localhost:5216/api/login";

        public static new AuthRequest Instance { get; } = new();

        public struct LoginResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            var response = await Post<LoginResponse>(LOGIN_URL, new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"email", email },
                {"password", password },
            }));

            return response;
        }
    }
}
