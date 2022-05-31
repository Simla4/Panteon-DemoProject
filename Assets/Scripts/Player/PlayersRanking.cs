using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayersRanking : MonoBehaviour
{
    [SerializeField] private List<Transform> competitor;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private TextMeshProUGUI ranking;

    // Update is called once per frame
    void Update()
    {
        RankTheCompetitor();
    }

    private void RankTheCompetitor()
    {
        for (int i = 0; i < competitor.Count; i++)
        {
            var biggestValZ = competitor[i].position.z;
            var biggestVal = i;

            for (int j = 0; j < competitor.Count; j++)
            {
                var currentValZ = competitor[j].position.z;
                if(currentValZ > biggestValZ)
                {
                    biggestVal = j;
                }
            }

            var tempVar = competitor[biggestVal];
            competitor[biggestVal] = competitor[i];
            competitor[i] = tempVar;
        }

        int playerRank = competitor.IndexOf(playerTransform) + 1;
        ranking.text = playerRank.ToString();
    }
}
