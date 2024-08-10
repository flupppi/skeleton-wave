using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats
{
    public int score;
    public Dictionary<string, int> evaluationCounts;


    public GameStats()
    {
        evaluationCounts = new Dictionary<string, int>();
        evaluationCounts.Add("perfect", 0);
        evaluationCounts.Add("awesome", 0);
        evaluationCounts.Add("good", 0);
        evaluationCounts.Add("okay", 0);
        evaluationCounts.Add("bad", 0);
        evaluationCounts.Add("terrible", 0);


    }

    public void countUpEvaluation(string evaluation)
    {
        evaluationCounts[evaluation] += 1;
    }

}
