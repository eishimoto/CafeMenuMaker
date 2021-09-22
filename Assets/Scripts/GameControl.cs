using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControl : MonoBehaviour
{

    //Slots and prefab
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private Transform[] allSlots;



    //Action
    public static Action<String> slide;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }

        KeyboardControl();
    }

    public void KeyboardControl()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            slide("W");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            slide("D");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            slide("S");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            slide("A");
        }
    }

    public void TouchControl()
    {

    }

    public void Spawn()
    {
        int spawnPlace = UnityEngine.Random.Range(0, allSlots.Length);
        if (allSlots[spawnPlace].childCount != 0)
        {
            Spawn();
            return;
        }

        GameObject tempFill = Instantiate(squarePrefab, allSlots[spawnPlace]);
        FillSquare fillSquare = tempFill.GetComponent<FillSquare>();
        allSlots[spawnPlace].GetComponent<Slot>().fill = fillSquare;

        int chance = UnityEngine.Random.Range(0, 10);
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
