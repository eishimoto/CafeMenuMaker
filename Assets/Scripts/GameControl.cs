using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private Transform[] allSlots;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        int spawnPlace = Random.Range(0, allSlots.Length);
        if (allSlots[spawnPlace].childCount != 0)
        {
            Spawn();
            return;
        }

        GameObject tempFill = Instantiate(squarePrefab, allSlots[spawnPlace]);
        FillSquare fillSquare = tempFill.GetComponent<FillSquare>();

        int chance = Random.Range(0, 10);
        if (chance < 8f)
        {
            fillSquare.FillUpdate(3);
        }
        else if(chance >= 8f)
        {
            fillSquare.FillUpdate(6);
        }
    }
}
