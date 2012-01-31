namespace StepsToFluentAPI
{
    using System;

    public class TestsHelper
    {
        public static bool CheckEquivalence(BlogPost expected, BlogPost actual)
        {
            return expected.Title.Equals(actual.Title) && 
                   expected.Body.Equals(actual.Body) &&
                   expected.Tags.Equals(actual.Tags) && 
                   ((expected.Author == null && actual.Author == null) ||
                   (expected.Author.Name.Equals(actual.Author.Name) &&
                   expected.Author.Email.Equals(actual.Author.Email) && 
                   expected.Author.Twitter.Equals(actual.Author.Twitter)));
        }
    }
}
