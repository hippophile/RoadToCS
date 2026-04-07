# Email Human vs AI Evaluator

## Overview
Email Human vs AI Evaluator is a C# console application that determines whether an **AI (automated system)** or a **human agent** should respond to an incoming email. The router uses keyword-based scoring to evaluate whether an email can be handled automatically or requires human intervention.

## Features
- **Keyword-based Email Routing**: Analyzes email content for specific indicators
- **Three Response Classifications**: 
  - **AI**: Email can be safely handled by an automated AI system
  - **DAI**: Deescalation AI - borderline email that AI should attempt to handle, but escalate to human if needed
  - **Hu**: Email requires human response
  - **Un**: Unclassified

## How It Works

The router uses a scoring system to determine if an email should be routed to AI (automated) handling or human handling. Keywords are weighted to indicate routing urgency:

### Scoring Labels

#### Negative Indicators (Require Human Response)
These keywords suggest the email needs immediate human attention:
- **legal**: -1000 points (Legal matters must be handled by humans)
- **photo**: -1000 points (Complex media-related issues)

#### Mild Negative Indicators (Prefer Human Response)
- **curse**: -6 points (Angry/frustrated customer)
- **sus**: -2 points (Suspicious content)
- **complaint**: -2 points (Customer complaint)

#### Positive Indicators (Can be Handled by AI)
- **spam**: +6 points (Spam/phishing can be automated)
- **phishing**: +6 points (Phishing attempts can be auto-filtered)

#### Mild Positive Indicators (Can be Handled by AI)
- **info**: +2 points (Information request)
- **guide**: +2 points (Guidance/FAQ-type request)

### Classification Rules

| Score | Routing Decision | Who Responds |
|-------|------------------|--------------|
| Score > 0 | AI | Automated AI system handles the email |
| 0 ≥ Score > -10 | DAI | AI attempts to handle; escalates to human if needed |
| Score < -10 | Hu | Human agent handles the email |

## Usage

1. **Run the Application**:
   ```bash
   dotnet run
   ```

2. **Enter an Email**: When prompted with "sample email: ", enter the email content to evaluate.

3. **View Routing Decision**: The application will display:
   - The input email
   - The routing decision (AI, DAI, Hu, or Un)

### Example 1: AI Routing
```
sample email: 
Hi, can you send me an invoice template? This is a frequently asked question.
Input email: Hi, can you send me an invoice template? This is a frequently asked question.
AI
```
*(Contains "guide" keyword → AI can handle this)*

### Example 2: Human Routing
```
sample email: 
I have a legal issue with your contract and I'm filing a complaint.
Input email: I have a legal issue with your contract and I'm filing a complaint.
Hu
```
*(Contains "legal" and "complaint" → Needs human agent)*

### Example 3: Deescalation AI
```
sample email: 
I noticed some sus activity on my account. Can you help?
Input email: I noticed some sus activity on my account. Can you help?
DAi
```
*(Contains "sus" → AI attempts to help, but human escalation available)*

## Project Structure

```
email-hu-ai-eval/
├── Program.cs              # Main application logic
├── email-hu-ai-eval.csproj # Project configuration
└── README.md              # This file
```

## Technical Details

- **Language**: C# 11+
- **Target Framework**: .NET 10.0
- **Implicit Usings**: Enabled
- **Nullable Reference Types**: Enabled

## Functions

- **ReadEmail()**: Prompts user for email input
- **TypeEmail()**: Displays the input email for verification
- **Evaluate()**: Calculates the routing score based on keyword matches (case-insensitive)
- **HumanOrBot()**: Determines routing decision (AI, DAI, or Hu) based on the score

## Limitations

- Keywords are matched case-insensitively with exact substring matching
- Each unique label is only counted once, regardless of how many times it appears
- The router relies on keyword presence only; tone, sentiment, and structural patterns are not analyzed
- Limited to predefined keyword set
- No context awareness (e.g., repeated keywords don't increase weight)

## Future Improvements

- Expand keyword dictionary for better accuracy and coverage
- Add sentiment analysis for frustrated/angry customers
- Implement topic classification (billing, technical support, sales, etc.)
- Machine learning-based scoring instead of keyword matching
- Email structure analysis (sender reputation, headers, etc.)
- Multi-language support
- Dynamic keyword weighting based on email category

## License

Internal project for learning and evaluation purposes.
