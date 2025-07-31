using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE 
        HashSet<string>unmatched = new HashSet<string>();
        List<string> results = new List<string>();
        foreach (string word in words)
        {
            if (unmatched.Contains(word[1].ToString() + word[0].ToString()))
            {
                results.Add(word + " & " + word[1].ToString() + word[0].ToString());
            }
            else
            {
                unmatched.Add(word);
            }
        }
        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            string degree = fields[3];
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees.Add(degree, 1);
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        Dictionary<string, int> letters = new Dictionary<string, int>();
        int biggest = int.Max(word1.Length, word2.Length);
        bool word1bigger = word1.Length == biggest;
        string letter1, letter2;
        for (int index = 0; index < biggest; index++)
        {
            if (word1bigger)
            {
                if (index < word2.Length)
                {
                    letter1 = word1[index].ToString().ToUpper();
                    letter2 = word2[index].ToString().ToUpper();
                }
                else
                {
                    letter1 = word1[index].ToString().ToUpper();
                    letter2 = " ";
                }
            }
            else
            {
                if (index < word1.Length)
                {
                    letter1 = word1[index].ToString().ToUpper();
                    letter2 = word2[index].ToString().ToUpper();
                }
                else
                {
                    letter1 = " ";
                    letter2 = word2[index].ToString().ToUpper();
                }
            }
            if (letter1 != " ")
            {
                if (!letters.ContainsKey(letter1))
                {
                    letters.Add(letter1, 1);
                }
                else
                {
                    letters[letter1]++;
                    if (letters[letter1] == 0)
                    {
                        letters.Remove(letter1);
                    }
                }
            }
            if (letter2 != " ")
            {
                if (!letters.ContainsKey(letter2))
                {
                    letters.Add(letter2, -1);
                }
                else
                {
                    letters[letter2]--;
                    if (letters[letter2] == 0)
                    {
                        letters.Remove(letter2);
                    }
                }
            }
        }

        return letters.Count == 0;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}