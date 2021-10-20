using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    [SerializeField] private GameObject[] unlockFood;

    [SerializeField] private GameObject achievementPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnlockFood();
    }

    private void UnlockFood()
    {
        if (Score.fourScore1 == true)
        {
            unlockFood[0].SetActive(true);
            Score.fourScore1 = false;
        }

        if (Score.fourScore2 == true)
        {
            unlockFood[1].SetActive(true);
            Score.fourScore2 = false;
        }


        if (Score.fiveScore1 == true)
        {
            unlockFood[0].SetActive(true);
            Score.fiveScore1 = false;
        }
        if (Score.fiveScore2 == true)
        {
            unlockFood[1].SetActive(true);
            Score.fiveScore2 = false;
        }


        if (Score.reverseScore1 == true)
        {
            unlockFood[0].SetActive(true);
            Score.reverseScore1 = false;
        }
        if (Score.reverseScore2 == true)
        {
            unlockFood[1].SetActive(true);
            Score.reverseScore2 = false;
        }
    }

    public void AchievementPanel()
    {
        achievementPanel.SetActive(true);
    }
}
