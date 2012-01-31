using System;
using NUnit.Framework;

namespace StepsToFluentAPI.Step6to7.OptionB
{
    public class Tests
    {
        [TestCase]
        public void ConfiguringPostWithAuthor()
        {
            var expected = new BlogPost();
            expected.Title = "How to build a basic fluent interface in 8 steps";
            expected.Body = "<html>...</html>";
            expected.Tags = "Fluent API, Internal DSL";
            var author = new Author();
            author.Name = "John Doe";
            author.Email = "johndoe@email.com";
            author.Twitter = "@johndoe";
            expected.Author = author;

            var post = Post
                .Title("How to build a basic fluent interface in 8 steps")
                .Body("<html>...</html>")
                .Author(a => a
                    .Name("John Doe")
                    .Email("johndoe@email.com")
                    .Twitter("@johndoe"))
                .Tags("Fluent API, Internal DSL");
            BlogPost actual = post.Build();

            Assert.IsTrue(TestsHelper.CheckEquivalence(expected, actual));
        }
    }

    public class Post
    {
        private AuthorSpec authorSpec;

        public static Post Title(string title)
        {
            var post = new Post();
            post.TitleValue = title;
            return post;
        }

        protected string TitleValue { get; set; }

        public Post Body(string body)
        {
            this.BodyValue = body;
            return this;
        }

        protected string BodyValue { get; set; }

        public Post Tags(string tags)
        {
            this.TagsValue = tags;
            return this;
        }

        protected string TagsValue { get; set; }

        public Post Author(Action<AuthorSpec> spec)
        {
            this.authorSpec = new AuthorSpec();
            spec(authorSpec);
            return this;
        }

        public BlogPost Build()
        {
            var blogPost = new BlogPost();

            blogPost.Title = this.TitleValue;
            blogPost.Body = this.BodyValue;
            blogPost.Tags = this.TagsValue;

            var author = new Author();
            author.Name = this.authorSpec.NameValue;
            author.Email = this.authorSpec.EmailValue;
            author.Twitter = this.authorSpec.TwitterValue;
            blogPost.Author = author;

            return blogPost;
        }
    }

    public class AuthorSpec
    {
        public AuthorSpec Name(string name)
        {
            this.NameValue = name;
            return this;
        }

        public string NameValue { get; set; }

        public AuthorSpec Email(string email)
        {
            this.EmailValue = email;
            return this;
        }

        public string EmailValue { get; set; }

        public AuthorSpec Twitter(string twitter)
        {
            this.TwitterValue = twitter;
            return this;
        }

        public string TwitterValue { get; set; }
    }
}
