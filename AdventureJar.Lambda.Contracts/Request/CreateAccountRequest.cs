namespace AdventureJar.Lambda.Contracts.Request
{
    public class CreateAccountRequest
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
        
        public string FamilyName { get; set; }

        public string GivenName { get; set; }

        public string Gender { get; set; }

        public string Picture { get; set; }

        public bool IsLinked { get; set; }

        public string LinkedToAccount { get; set; }
    }
}
