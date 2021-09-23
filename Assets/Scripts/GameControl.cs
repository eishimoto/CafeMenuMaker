using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControl : MonoBehaviour
{
    //Slots and prefab
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private Slot[] allSlots;

    //Action
    public static Action<String> slide;

    //Statics
    public static GameControl instance;
    public static int ticker;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        InicialSpawn();
        InicialSpawn();
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
            ticker = 0;
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ticker = 0;
            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ticker = 0;
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ticker = 0;
            slide("a");
        }
    }

    public void TouchControl()
    {

    }

    public void Spawn()
    {
        bool isFull = true;
        for (int i = 0; i < allSlots.Length; i++)
        {
            if(allSlots[i].fill == null)
            {
                isFull = false;
            }
        }
        if(isFull == true)
        {
            return;
        }

        int spawnPlace = UnityEngine.Random.Range(0, allSlots.Length);
        if (allSlots[spawnPlace].transform.childCount != 0)
        {
            Spawn();
            return;
        }

        GameObject tempFill = Instantiate(squarePrefab, allSlots[spawnPlace].transform);
        FillSquare fillSquare = tempFill.GetComponent<FillSquare>();
        allSlots[spawnPlace].GetComponent<Slot>().fill = fillSquare;

        int chance = UnityEngine.Random.Range(0, 10);
        if (chance < 8f)
        {
            fillSquare.FillUpdate(2);
        }
        else if(chance >= 8f)
        {
            fillSquare.FillUpdate(4);
        }
    }
    public void InicialSpawn()
    {
        int spawnPlace = UnityEngine.Random.Range(0, allSlots.Length);
        if (allSlots[spawnPlace].transform.childCount != 0)
        {
            Spawn();
            return;
        }

        GameObject tempFill = Instantiate(squarePrefab, allSlots[spawnPlace].transform);
        FillSquare fillSquare = tempFill.GetComponent<FillSquare>();
        allSlots[spawnPlace].GetComponent<Slot>().fill = fillSquare;

            fillSquare.FillUpdate(2);

    }
}
