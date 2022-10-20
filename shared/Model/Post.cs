namespace shared.Model
{
    public class Post
    {
        public int PostID {get; set; }
        public DateTime DateOfSubmission {get; set; }
        public string ?NameOfAuthor {get; set; }
        public string ?PostString {get; set; }
        public string ?Content {get; set; }
        public int Upvotes {get; set; }
        public int Downvotes {get; set; }
        public List<Comment> Comments {get; set; } = new List<Comment>();
        public Post (DateTime dateofsubmission, string nameofauthor, string poststring, string content, int upvotes, int downvotes) {
            DateOfSubmission = dateofsubmission;
            NameOfAuthor = nameofauthor;
            PostString = poststring;
            Content = content;
            Upvotes = upvotes;
            Downvotes = downvotes;
        }
        public Post () {
            PostID = 0;
            NameOfAuthor = "";
            PostString = "";
            Content = "";
            Upvotes = 0;
            Downvotes = 0;
        }

        public override string ToString()
        {
            return $"PostID: {PostID}, DateOfSubmission: {DateOfSubmission}, NameOfAuthor: {NameOfAuthor}, PostString: {PostString}, Content: {Content}, Upvotes: {Upvotes}, Downvotes: {Downvotes}";
        }
    }
}