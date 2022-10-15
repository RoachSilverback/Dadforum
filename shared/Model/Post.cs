namespace shared.Model
{
    public class Post
    {
        public int PostID {get; set; }
        // public DateOnly DateOfSubmission {get; set; }
        public string ?NameOfAuthor {get; set; }
        public string ?PostString {get; set; }
        public int Upvotes {get; set; }
        public int Downvotes {get; set; }
        public List<Comment> Comments {get; set; } = new List<Comment>();
        public Post (string nameofauthor, string poststring, int upvotes, int downvotes) {
            NameOfAuthor = nameofauthor;
            PostString = poststring;
            Upvotes = upvotes;
            Downvotes = downvotes;
        }
        public Post () {
            PostID = 0;
            NameOfAuthor = "";
            PostString = "";
            Upvotes = 0;
            Downvotes = 0;
        }

        public override string ToString()
        {
            return $"PostID: {PostID}, NameOfAuthor: {NameOfAuthor}, PostString: {PostString}, Upvotes: {Upvotes}, Downvotes: {Downvotes}";
        }
    }
}