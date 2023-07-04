namespace web_api_crud_tutorial.Models
{
    public class TokenWEModel
    {
        public TokenWEModel(string token)
        {
            Token = token;
            ExpirationTime = "Ilimitado";
        }
        public string Token { get; set; }

        public string ExpirationTime { get; set; }
    }
}
