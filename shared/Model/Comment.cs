namespace shared.Model
{
    public class Comment
    {
        public int CommentID {get; set;}
        public DateTime DateOfComment {get; set;}
        public string ?Author {get; set; }
        public string ?CommentString {get; set;}
        public int ?Upvotes {get; set; }
        public int ?Downvotes {get; set; }
        public Post Post {get; set; }


        public Comment(DateTime dateofcomment, string author = "", string commentString = "", int upvotes = 0, int downvotes = 0)
        {
            DateOfComment = dateofcomment;
            Author = author;
            CommentString = commentString;
            Upvotes = upvotes;
            Downvotes = downvotes;
        }
        public Comment() {
            CommentID = 0;
            Author = "";
            CommentString = "";
            Upvotes = 0;
            Downvotes = 0;
        }
    }
}