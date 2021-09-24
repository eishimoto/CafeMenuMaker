using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public static bool lost = false;
    public static bool canMove;

    //Color
    public Color[] myColors;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        canMove = true;
        Spawn();
        Spawn();
    }

    private void Update()
    {
        KeyboardControl();
    }

    public void KeyboardControl()
    {
        if (canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
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
    }

    public void TouchControl()
    {

    }

    public void FullCheck()
    {
        bool isFull = true;
        for (int i = 0; i < allSlots.Length; i++)
        {
            if (allSlots[i].fill == null)
            {
                isFull = false;
            }
        }
        if (isFull == true)
        {
            lost = true;
            canMove = false;
            return;
        }
        Spawn();
    }

    private void Spawn()
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
}
