namespace InsuranceProcess.Auth
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public decimal DurationInDay { get; set; }
    }
}
