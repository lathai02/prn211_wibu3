using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemeSystemWF.Requests
{
    public class ShowRequest : HttpRequest
    {
        private const string GET_SHOWS_URL = "http://localhost:5216/api/get-shows";
        private const string CHECK_TICKET_URL = "http://localhost:5216/api/check-ticket";

        public static new ShowRequest Instance { get; } = new();

        public struct GetShowsResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("shows")]
            public List<Show> Shows { get; set; }
        }

        public struct Show
        {
            [JsonProperty("id")]
            public int ID { get; set; }

            [JsonProperty("film")]
            public string Film { get; set; }

            [JsonProperty("start")]
            public DateTime Start { get; set; }

            [JsonProperty("end")]
            public DateTime End { get; set; }

            [JsonProperty("ticket-price")]
            public double TicketPrice { get; set; }

            [JsonProperty("room")]
            public string Room { get; set; }
        }

        public struct CheckTicketResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }

        public async Task<GetShowsResponse> GetShows(TimeSpan interval)
        {
            var response = await Get<GetShowsResponse>($"{GET_SHOWS_URL}?interval={interval.TotalMilliseconds}");

            return response;
        }

        public async Task<CheckTicketResponse> CheckTicket(string token, int showId, string email, string otp)
        {
            var response = await Post<CheckTicketResponse>(CHECK_TICKET_URL, new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "token", token},
                { "showId", showId.ToString() },
                { "email", email },
                { "otp", otp },
            }));

            return response;
        }
    }
}
