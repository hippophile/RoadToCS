using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        var laybels = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            
        ["legal"] = -1000,
        ["photo"] = -1000,
        ["curse"] = -2,
        ["sus"] = -2,
        ["complaint"] = -2,

        ["spam"] = -6,
        ["phishing"] = -6,

        ["info"] = +2,
        ["guide"] = +2

        };

        string? email = ReadEmail();
        TypeEmail(email);
        int score = Evaluate(email, laybels);
        HumanOrBot(score);
    }


    static string? ReadEmail()
    {
        Console.WriteLine("sample email: ");
        string? email = Console.ReadLine();
        return email;
    }   

    static void TypeEmail(string? email)
    {

        Console.WriteLine($"Input email: {email}");
    }

    // Evaluate the email based on the provided labels and their corresponding scores
    // Same label will not be counted multiple times
    static int Evaluate(string? email, Dictionary<string, int> laybels)
    {
       int score = 0;
       foreach (var label in laybels)
       {
        if (email != null && email.Contains(label.Key, StringComparison.OrdinalIgnoreCase))
        {
            score += label.Value;
        }
       }
        return score;
    }

    static bool HumanOrBot(int score)
    {
        if (score>0)
        {
            Console.WriteLine("For Ai");
            return true;
        }
        else
        {
            Console.WriteLine("For Human");
            return false;
        }
    }

}