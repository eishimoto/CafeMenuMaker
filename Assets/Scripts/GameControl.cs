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
    [SerializeField] private int _keyboardOneOrTouchTwo;
    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;
    [SerializeField] private int minValue2;
    [SerializeField] private int maxValue2;

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
        if (_keyboardOneOrTouchTwo == 1)
        {
            KeyboardControl();
        }
        if (_keyboardOneOrTouchTwo == 2)
        {
            Swipe();
        }
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

    public void Swipe()
    {
        if (canMove == true)
        {
            if (TouchControl.swipeUp == true)
            {
                ticker = 0;
                slide("w");
                TouchControl.swipeUp = false;
            }
            if (TouchControl.swipeRight == true)
            {
                ticker = 0;
                slide("d");
                TouchControl.swipeRight = false;
            }
            if (TouchControl.swipeDown == true)
            {
                ticker = 0;
                slide("s");
                TouchControl.swipeDown = false;
            }
            if (TouchControl.swipeLeft == true)
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

        int chance = UnityEngine.Random.Range(0, 20);

        if (chance < 8f)
        {
            SquarePrefab.FillUpdate(minValue);
        }
        else if(chance <= 10f)
        {
            SquarePrefab.FillUpdate(maxValue);
        }
        if(chance < 18f && chance > 10f)
        {
            SquarePrefab.FillUpdate(minValue2);
        }
        if(chance >= 18f) 
        {
            SquarePrefab.FillUpdate(maxValue2);
        }
    }
}
