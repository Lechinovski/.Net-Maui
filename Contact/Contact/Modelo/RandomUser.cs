namespace Contact.Modelo
{
    public class RandomUser
    {

        public Name name { get; set; }
        public Picture picture { get; set; }

        public class Name
        {
            public string title { get; set; }
            public string first { get; set; }
            public string last { get; set; }
        }

        public class Picture
        {
            public string large { get; set; }
            public string medium { get; set; }
            public string thumbnail { get; set; }
        }

        public string email { get; set; }

        public string phone { get; set; }

        public string cell { get; set; }
    }
}