using System.Collections.Generic;
using System.Linq;

namespace Exercises.Problems;

/// <summary>
/// Amazon is building a way to help customers search reviews quicker by providing real-time
/// suggestions to search terms when the customer starts typing. When given a
/// minimum of two characters into the search field the system will suggest at most three
/// keywords from the review word repository. As the customer continues to type in the
/// reviews search bar the relevant keyword suggestions will update automatically.
///
/// Write an algorithm that will output a maximum of three keywords suggestions after
/// each character is typed by the customer in the search field.
///
/// If there are more than three acceptable keywords, return the keywords that are first in
/// alphabetical order.
/// Only return keyword suggestions after the customer has entered two characters.
/// Keyword suggestions must start with the characters already typed.
/// Both the repository and the customerQuery should be compared in a case-insensitive way.
///
/// Input
/// The input to the method consists of two arguments:
/// - Repository: a list of unique strings representing the various keywords from
/// the Amazon review section.
/// - CustomerQuery: A string represeting the full search query of the customer.
///
/// Output
/// Return a list of list of strings in lower case, where each list represents the keyword
/// suggestions made by the system as the customer types each character of the
/// customerQuery. Assume the customer types characters in order without deleting or
/// removing any characters. If an output is not possible, return an empty array ([]).
///
/// Example
/// Input:
/// - Repository ["mobile", "mouse", "moneypot", "monitor", "mousepad"]
/// - customerQuery = "mouse"
///
/// Output:
/// - typed "mo" -> ["mobile", "moneypot", "monitor"]
/// - typed "mou" -> ["mouse", "mousepad"]
/// - typed "mous" -> ["mouse", "mousepad"]
/// - typed "mouse" -> ["mouse", "mousepad"]
///
/// Explanation
/// The chain of words that will generate in the search box will be mo, mou, mous, mouse.
/// Each line from the output shows the suggestions of mo, mou, mous, mouse, respectively in each line.
/// For the keyword suggestions made bye the system that are generated for 'mo',
/// the matches that will be generated are ["mobile", "mouse", "moneypot", "monitor", "mousepad"].
/// Then they will be ordered into ["mobile", "moneypot", "monitor", "mouse", "mousepad"].
/// Finally the first three keywords are ["mobile", "moneypot", "monitor"].
///
/// Tests
/// - Repository ["mobile", "mouse", "moneypot", "monitor", "mousepad"]
/// - customerQuery ["mouse"]
///
/// - Repository ["5", "mobile", "mouse", "moneypot", "monitor", "mousepad"]
/// - customerQuery ["mouse"]
/// - expected output ->
/// [
///     ["mobile", "moneypot", "monitor", "mouse", "mousepad"],
///     ["mobile", "moneypot", "monitor", "mouse", "mousepad"],
///     ["mobile", "moneypot", "monitor", "mouse", "mousepad"],
///     ["mouse", "mousepad"],
///     ["mouse", "mousepad"]
/// ]
///
/// </summary>
public class AmazonCustomerReviews
{
    private static readonly List<List<string>> emptySearch = new();
    private static readonly int defaultCharsToExtractAmount = 2;

    public static List<List<string>> SearchSuggestions(List<string> repository, string customerQuery)
    {
        if (ParametersAreInvalid(repository, customerQuery)) return emptySearch;

        var output = new List<List<string>>();
        var sortedRepository = repository.OrderBy(x => x).ToList();
        output = FindSuggestions(sortedRepository, customerQuery, defaultCharsToExtractAmount, output);

        // 6. You did it mate!
        return output;
    }

    private static List<List<string>> FindSuggestions(
        List<string> sortedRepository,
        string customerQuery,
        int charsToExtract,
        List<List<string>> output)
    {
        // With query "mouse"
        // 1. We extract the first 2 chars from it.
        var extractedChars = ExtractChars(customerQuery, charsToExtract);

        // 2. We look for strings starting with those 2 chars in the repository.
        //    2.1 Look for the strings
        //    2.2 Order the found strings
        //    2.3 Choose only the first three from the found strings.
        var wordsFound = SearchExtractedStringInRepository(sortedRepository, extractedChars);

        // 3. If words found are empty we stop looking since we wont find more chars in the repo.
        if (wordsFound.Count == 0) return output;

        // 4. Save found strings in the output.
        output.Add(wordsFound);

        // 4. If customerQuery length is greater than 2, extract the next char
        //    4.1 Repeat steps from 2 and 3 until the current index of the extracted char
        //        matches the length of the word.
        if (customerQuery.Length > charsToExtract)
        {
            charsToExtract++;
            FindSuggestions(sortedRepository, customerQuery, charsToExtract, output);
        }

        // 5. Else return output.
        return output;
    }

    private static List<string> SearchExtractedStringInRepository(List<string> sortedRepository, string extractedChars)
    {
        return sortedRepository
            .Where(x => x.ToLower().StartsWith(extractedChars.ToLower()))
            .Take(3)
            .Select(x => x.ToLower())
            .ToList();

        //extractedChars = extractedChars.ToLower();
        //var searchResult = new List<string>();
        //foreach (var word in sortedRepository)
        //{
        //    var wordToCompare = word.ToLower();
        //    if (wordToCompare.StartsWith(extractedChars) && searchResult.Count != 3)
        //        searchResult.Add(wordToCompare);
        //    if (searchResult.Count == 3)
        //        break;
        //}

        //return searchResult;
    }

    private static string ExtractChars(string customerQuery, int amountToExtract) => customerQuery[..amountToExtract];

    private static bool ParametersAreInvalid(List<string> repository, string customerQuery)
    {
        if (string.IsNullOrWhiteSpace(customerQuery)) return true;
        if (customerQuery.Trim().Length < 2) return true;
        if (repository == null || repository.Count == 0) return true;

        return false;
    }
}