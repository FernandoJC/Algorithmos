using Exercises.Problems;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace ExercisesTests.Problems;

public class AmazonCustomerReviewsTests
{
    /// - Repository ["5", "mobile", "mouse", "moneypot", "monitor", "mousepad"]
    /// - customerQuery ["mouse"]
    /// - expected output ->
    /// [
    ///     ["mobile", "moneypot", "monitor"],
    ///     ["mobile", "moneypot", "monitor"],
    ///     ["mobile", "moneypot", "monitor"],
    ///     ["mouse", "mousepad"],
    ///     ["mouse", "mousepad"]
    /// ]
    [Theory]
    [MemberData(nameof(ValidTestA))]
    [MemberData(nameof(ValidTestB))]
    [MemberData(nameof(ValidTestC))]
    public void ShouldSearchSuggestions(List<string> repository, string customerQuery, List<List<string>> expectedOutput)
    {
        var output = AmazonCustomerReviews.SearchSuggestions(repository, customerQuery);

        output.ShouldBeEquivalentTo(expectedOutput);
    }

    public static IEnumerable<object[]> ValidTestA()
    {
        var repository = new List<string> { "5", "Mobile", "mouse", "moneypot", "monitor", "mousepad" };
        var customerQuery = "mouse";
        var expectedOutput = new List<List<string>>
        {
            new List<string> { "mobile", "moneypot", "monitor" },
            new List<string> { "mouse", "mousepad" },
            new List<string> { "mouse", "mousepad" },
            new List<string> { "mouse", "mousepad" }
        };
        return new List<object[]>
        {
            new object[] { repository, customerQuery, expectedOutput },
        };
    }

    public static IEnumerable<object[]> ValidTestB()
    {
        var repository = new List<string> { "abcdefghij", "abcdefgh", "abcdfeghij", "abcdefghji", "abcdefghi" };
        var customerQuery = "abcde";
        var expectedOutput = new List<List<string>>
        {
            new List<string> { "abcdefgh", "abcdefghi", "abcdefghij" },
            new List<string> { "abcdefgh", "abcdefghi", "abcdefghij" },
            new List<string> { "abcdefgh", "abcdefghi", "abcdefghij" },
            new List<string> { "abcdefgh", "abcdefghi", "abcdefghij" }
        };
        return new List<object[]>
        {
            new object[] { repository, customerQuery, expectedOutput },
        };
    }

    public static IEnumerable<object[]> ValidTestC()
    {
        var repository = new List<string> { "5", "Mobile", "mouse", "moneypot", "monitor", "mousepad" };
        var customerQuery = "doggy";
        var expectedOutput = new List<List<string>>();
        return new List<object[]>
        {
            new object[] { repository, customerQuery, expectedOutput },
        };
    }

    [Fact]
    public void ShouldReturnEmpty_WhenRepositoryIsEmpty()
    {
        var output = AmazonCustomerReviews.SearchSuggestions(new List<string>(), "something");
        output.ShouldBeEmpty();

        output = AmazonCustomerReviews.SearchSuggestions(null, "something");
        output.ShouldBeEmpty();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("      ")]
    [InlineData("a")]
    [InlineData("a  ")]
    public void ShouldReturnEmpty_WhenCustomerQueryLenghtIsLessThanTwo(string customerQuery)
    {
        var output = AmazonCustomerReviews.SearchSuggestions(new List<string>(), customerQuery);

        output.ShouldBeEmpty();
    }
}