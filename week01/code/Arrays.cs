using System.Diagnostics;
using System.Globalization;
using System.Collections.Generic;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// I will let the user supply the input for the function then will run the function.
    Debug.WriteLine("Please enter a number greater than 0 to get multiples:");
    static double number = Console.ReadLine();

    Debug.WriteLine("Please enter the number of multiples you need: ");
    static int length = Console.ReadLine();
    List<double> list = MultiplesOf(number, length);
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // get the input from the user and test if it is greater than 0 after that run a loop to iterate through the number variable
        // depending on the length size variable to get each of the multiples and will store it in an array of the size.
        int i = 0;
        List<double> list = new List<double>();
        if (number > 0 || number > 1)
        {
            while (i <= length) ;
            list.Add(number);
            number += number;
            i++;
        }
        return list;// replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
