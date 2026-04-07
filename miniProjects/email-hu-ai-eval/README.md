# Email Human vs AI Evaluator

## Overview
Email Human vs AI Evaluator is a C# console application that classifies emails as either human-written, AI-generated, or human-written with AI deescalation. The classifier uses keyword-based scoring to evaluate the content of an email.

## Features
- **Keyword-based Classification**: Analyzes email content for specific indicators
- **Three Classification Levels**: 
  - **AI**: High confidence the email is AI-generated
  - **DAI**: Deescalation AI - borderline case, requires human oversight for AI-generated content
  - **Hu**: High confidence the email is human-written
  - **Un**: Unknown/Unclassified

## How It Works

The evaluator uses a scoring system based on keyword detection:

### Scoring Labels

#### Negative Indicators (Strong Human Signals)
- **legal**: -1000 points
- **photo**: -1000 points

#### Mild Negative Indicators (Human Signals)
- **curse**: -6 points
- **sus**: -2 points
- **complaint**: -2 points

#### Positive Indicators (Strong AI/Bot Signals)
- **spam**: +6 points
- **phishing**: +6 points

#### Mild Positive Indicators (AI/Bot Signals)
- **info**: +2 points
- **guide**: +2 points

### Classification Rules

| Score | Classification | Meaning |
|-------|----------------|---------|
| Score > 0 | AI | Email appears to be AI-generated |
| 0 ≥ Score > -10 | DAI | Deescalation AI - borderline email requiring human oversight |
| Score < -10 | Hu | Email appears to be human-written |

## Usage

1. **Run the Application**:
   ```bash
   dotnet run
   ```

2. **Enter an Email**: When prompted with "sample email: ", enter the email content to evaluate.

3. **View Result**: The application will display:
   - The input email
   - The classification result (AI, DAI, Hu, or Un)

### Example
```
sample email: 
Your package has been delayed. Please click here to update your address.
Input email: Your package has been delayed. Please click here to update your address.
DAi
```

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
- **TypeEmail()**: Displays the input email
- **Evaluate()**: Calculates the score based on keyword matches (case-insensitive)
- **HumanOrBot()**: Determines classification based on the score

## Limitations

- Keywords are matched case-insensitively with exact substring matching
- Each unique label is only counted once, regardless of how many times it appears
- The classifier relies on keyword presence only; sentiment analysis and structural patterns are not considered
- Limited to predefined keyword set

## Future Improvements

- Expand keyword dictionary for better accuracy
- Add machine learning-based classification
- Implement training data analysis
- Add email structure analysis (headers, formatting, etc.)
- Support for multiple languages

## License

Internal project for learning and evaluation purposes.
