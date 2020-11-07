using Jwt;
using System;
using System.Text;
using System.Web.Http;

namespace bao_kim_API.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("get_token")]
        public string Get()
        {
            var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var issueTime = DateTime.Now;
            Data data = new Data()
            {
                iat = (long)issueTime.Subtract(utc0).TotalSeconds,
                jti = Convert.ToBase64String(Encoding.Unicode.GetBytes("32")),
                iss = "0w2zyWkeGiEiWPGzADUwgQpRmv5OrSAq",
                nbf = (long)issueTime.Subtract(utc0).TotalSeconds,
                exp = (long)issueTime.AddMinutes(30).Subtract(utc0).TotalSeconds,
            };

            return Common.JsonWebToken.Encode(data, "u7A8NZe8LbGzTuEax2muTr8t53urKDlg", JwtHashAlgorithm.HS256);
        }
    }
    public class Data
    {
        public long iat { get; set; }
        public string jti { get; set; }
        public string iss { get; set; }
        public long nbf { get; set; }
        public long exp { get; set; }
        //public dynamic form_params { get; set; }
    }
}
