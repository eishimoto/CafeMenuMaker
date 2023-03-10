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

    //int to change in inspector
    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;

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
        Control();
    }

    public void Control()
    {
        if (canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || TouchControl.swipeUp == true)
            {
                ticker = 0;
                slide("w");
                TouchControl.swipeUp = false;
            }
            if (Input.GetKeyDown(KeyCode.D)|| TouchControl.swipeRight == true)
            {
                ticker = 0;
                slide("d");
                TouchControl.swipeRight = false;
            }
            if (Input.GetKeyDown(KeyCode.S)|| TouchControl.swipeDown == true)
            {
                ticker = 0;
                slide("s");
                TouchControl.swipeDown = false;
            }
            if (Input.GetKeyDown(KeyCode.A)|| TouchControl.swipeLeft == true)
            {
                ticker = 0;
                slide("a");
                TouchControl.swipeLeft = false;
            }
        }
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
        SquarePrefab SquarePrefab = tempFill.GetComponent<SquarePrefab>();
        allSlots[spawnPlace].GetComponent<Slot>().fill = SquarePrefab;

        int chance = UnityEngine.Random.Range(0, 10);

        if (chance < 8f)
        {
            SquarePrefab.FillUpdate(minValue);
        }
        else if(chance >= 8f)
        {
            SquarePrefab.FillUpdate(maxValue);
        }
    }
}
