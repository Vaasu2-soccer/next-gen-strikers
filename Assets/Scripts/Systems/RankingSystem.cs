using UnityEngine;
using System.Collections.Generic;

public enum Rank
{
    Rookie,
    Sophomore,
    Bronze,
    Silver,
    Gold,
    Platinum,
    Diamond,
    Champion,
    GrandChampion,
    EliteBaller,
    StreetBallMaster,
    TheGodOfFootball
}

public class RankingSystem : MonoBehaviour
{
    private Rank currentRank = Rank.Rookie;
    private int currentStars = 0;
    private int winsForNextStar = 3;
    private int totalWins = 0;

    // Wins required per star increase per rank
    private Dictionary<Rank, int> winsRequiredPerRank = new Dictionary<Rank, int>
    {
        { Rank.Rookie, 3 },
        { Rank.Sophomore, 3 },
        { Rank.Bronze, 3 },
        { Rank.Silver, 3 },
        { Rank.Gold, 3 },
        { Rank.Platinum, 4 },
        { Rank.Diamond, 5 },
        { Rank.Champion, 10 },
        { Rank.GrandChampion, 10 },
        { Rank.EliteBaller, 10 },
        { Rank.StreetBallMaster, 10 },
        { Rank.TheGodOfFootball, int.MaxValue } // Final rank
    };

    public void RecordWin()
    {
        totalWins++;
        winsForNextStar--;

        if (winsForNextStar <= 0)
        {
            AddStar();
        }
    }

    private void AddStar()
    {
        currentStars++;

        if (currentStars >= 5)
        {
            PromoteToNextRank();
        }
    }

    private void PromoteToNextRank()
    {
        if (currentRank < Rank.TheGodOfFootball)
        {
            currentRank++;
            currentStars = 0;
            winsForNextStar = winsRequiredPerRank[currentRank];
            Debug.Log($"Promoted to: {currentRank}");
        }
    }

    public Rank GetCurrentRank()
    {
        return currentRank;
    }

    public int GetCurrentStars()
    {
        return currentStars;
    }

    public int GetTotalWins()
    {
        return totalWins;
    }

    public float GetRankProgress()
    {
        return (5 - winsForNextStar) / 5f; // Progress to next rank
    }
}
