using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace TestBlazor.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token =
                "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImRhbmllbGUuZ2FzdGFsZG9AdGVzdC5pdCIsIlVzZXJJRCI6IjUiLCJyb2xlIjoiMSIsIm5iZiI6MTY4MTIwMDg4MCwiZXhwIjoxNjgxODA1NjgwLCJpYXQiOjE2ODEyMDA4ODB9.q68Ifo9bpfn15Xs8d6-r8umtPogiuSSKhud3WMR_qioDyopRIov48CDST2l0t5X3DToIsgKYp8D4WvRFq2cZWw";

            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            //var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
