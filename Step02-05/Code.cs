namespace StepsToFluentAPI.Step02
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        public void ConfiguringPostWithoutAuthor()
        {
            var expected = new BlogPost();
            expected.Title = "8 steps for writing a fluent API";
            expected.Body = "<html>...</html>";
            expected.Tags = "Fluent API, Internal DSL";

            var post = Post
                .Title("8 steps for writing a fluent API")
                .Body("<html>...</html>")
                .Tags("Fluent API, Internal DSL");
            BlogPost actual = post.Build();

            Assert.IsTrue(TestsHelper.CheckEquivalence(expected, actual));
        }
    }

    public class Post
    {
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

        public BlogPost Build()
        {
            var blogPost = new BlogPost();

            blogPost.Title = this.TitleValue;
            blogPost.Body = this.BodyValue;
            blogPost.Tags = this.TagsValue;

            return blogPost;
        }
    }
}
