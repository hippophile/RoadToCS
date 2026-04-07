using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        var labels = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            
        ["legal"] = -1000,
        ["photo"] = -1000,
        ["curse"] = -6,
        ["sus"] = -2,
        ["complaint"] = -2,

        ["spam"] = +6,
        ["phishing"] = +6,

        ["info"] = +2,
        ["guide"] = +2

        };

        string? email = ReadEmail();
        TypeEmail(email);
        int score = Evaluate(email, labels);
        Console.WriteLine(HumanOrBot(score));
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
    static int Evaluate(string? email, Dictionary<string, int> labels)
    {
       int score = 0;
       foreach (var label in labels)
       {
        if (email != null && email.Contains(label.Key, StringComparison.OrdinalIgnoreCase))
        {
            score += label.Value;
        }
       }
        return score;
    }

    // positive for ai, negative for human
    // for score > -10 and more is for ai only for deescalation
    // if deescalation is not accomplished, then Human takes control  
    static string HumanOrBot(int score)
    {
        if (score>0)
        {
            return "Ai";
        }
        else if (score > -10)
        {
            return "DAi";
        }
        else if (score<0)
        {
            return "Hu";
        }
        
        return "Un";
    }

}