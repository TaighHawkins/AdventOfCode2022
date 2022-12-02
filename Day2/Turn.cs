namespace Day2;

public class Turn
{
    public char OpponentPlay { get; init; }
    public char Response { get; init; }

    public int GetResultWithFirstConversion()
    {
        RockPaperScissors myPlay = ConvertPlay(Response);
        RockPaperScissors opponentPlay = ConvertPlay(OpponentPlay);

        var outcome = 0;
        if (opponentPlay == myPlay)
        {
            outcome = 3;
        }        
        else if (opponentPlay == RockPaperScissors.Rock && myPlay == RockPaperScissors.Paper
                 || opponentPlay == RockPaperScissors.Paper && myPlay == RockPaperScissors.Scissors
                 || opponentPlay == RockPaperScissors.Scissors && myPlay == RockPaperScissors.Rock)
        {
            outcome = 6;
        }

        return outcome + (int)myPlay;
    }
    
    public int GetResultWithSecondConversion()
    {
        RockPaperScissors opponentPlay = ConvertPlay(OpponentPlay);
        var outcomeScore = 0;
        var myPlay = RockPaperScissors.Rock;
        switch (Response)
        {
            case 'X':
                myPlay = opponentPlay switch
                {
                    RockPaperScissors.Rock => RockPaperScissors.Scissors,
                    RockPaperScissors.Scissors => RockPaperScissors.Paper,
                    _ => myPlay
                };
                break;
            case 'Y':
                outcomeScore = 3;
                myPlay = opponentPlay;
                break;
            case 'Z':
                outcomeScore = 6;
                myPlay = opponentPlay switch
                {
                    RockPaperScissors.Paper => RockPaperScissors.Scissors,
                    RockPaperScissors.Rock => RockPaperScissors.Paper,
                    _ => myPlay
                };
                break;
        }

        return outcomeScore + (int)myPlay;
    }
    
    private static RockPaperScissors ConvertPlay(char play)
    {
        return play switch
        {
            'A' or 'X' => RockPaperScissors.Rock,
            'B' or 'Y' => RockPaperScissors.Paper,
            'C' or 'Z' => RockPaperScissors.Scissors,
            _ => throw new InvalidDataException()
        };
    }
    
    private enum RockPaperScissors {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}