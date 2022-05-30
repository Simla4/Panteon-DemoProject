using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayersRanking : MonoBehaviour
{
    [SerializeField] private List<Transform> competitor;

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
            var smallestValZ = competitor[i].position.z;
            var smallestVal = i;

            for (int j = 0; j < competitor.Count; j++)
            {
                var currentValZ = competitor[j].position.z;
                if(currentValZ < smallestValZ)
                {
                    smallestVal = j;
                }
            }

            var tempVar = competitor[smallestVal];
            competitor[smallestVal] = competitor[i];
            competitor[i] = tempVar;
        }
    }
}
