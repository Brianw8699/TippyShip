using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class Leaderboard : MonoBehaviour
{

int leaderboardID = 5378;
int count = 50;
int after = 0;
    // Start is called before the first frame update
    void Start()
    {
LootLockerSDKManager.StartGuestSession("Brian", (response) =>
        {
        if (response.success)
        {

            Debug.Log("Lootlocker Init Success");
        }
        else
        {
            Debug.Log("Lootlocker init fail");
        }
        
        });

      LootLockerSDKManager.GetScoreList(leaderboardID, count, after, (response) =>
{
    if (response.statusCode == 200) {
        Debug.Log("Successful");
    } else {
        Debug.Log("failed: " + response.Error);
    }
});  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

