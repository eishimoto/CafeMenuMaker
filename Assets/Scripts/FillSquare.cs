using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSquare : MonoBehaviour
{
    [SerializeField] private Text valueDsiplayText;

    private int value;

    public void FillUpdate(int valueIn)
    {
        value = valueIn;
        valueDsiplayText.text = valueIn.ToString();
    }
}
