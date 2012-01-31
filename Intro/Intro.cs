namespace StepsToFluentAPI.Intro
{
    public class Intro
    {
        public void Code()
        {
            var post = new BlogPost();
            post.Title = "8 steps for writing a fluent API";
            post.Body = "<html>...</html>";
            var author = new Author(); // We should check the authors repository before creating a new one 
            author.Name = "John Doe";
            author.Email = "johndoe@email.com";
            author.Twitter = "@johndoe";
            post.Author = author;
            post.Tags = "Fluent API, Internal DSL";
        }
    }
}
