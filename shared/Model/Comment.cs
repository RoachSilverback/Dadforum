namespace shared.Model
{
    public class Comment
    {
        public int CommentID {get; set;}
        public string ?CommentString {get; set;}
        // public DateOnly DateOfComment {get; set;}
        public int ?Upvotes {get; set; }
        public int ?Downvotes {get; set; }
        public Post Post {get; set; }


        public Comment(string commentString = "", int upvotes = 0, int downvotes = 0)
        {
            CommentString = commentString;
            Upvotes = upvotes;
            Downvotes = downvotes;
        }
        public Comment() {
            CommentID = 0;
            CommentString = "";
            Upvotes = 0;
            Downvotes = 0;
        }
    }
}