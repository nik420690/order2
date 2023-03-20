namespace MentorAPI
{
    public class Mentor
    {
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Tip { get; set; }
    }
}
