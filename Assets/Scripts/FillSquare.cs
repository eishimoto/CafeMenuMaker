using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSquare : MonoBehaviour
{
    [SerializeField] private Text valueDsiplayText;
    [SerializeField] private float speed;

    //int
    public int value;

    //bool
    private bool combined;

    public void FillUpdate(int valueIn)
    {
        value = valueIn;
        valueDsiplayText.text = valueIn.ToString();
    }

    private void Update()
    {
        if(transform.localPosition != Vector3.zero)
        {
            combined = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        else if(!combined)
        {
            if(transform.parent.GetChild(0) != this.transform)
            {
                Destroy(transform.parent.GetChild(0).gameObject);
            }
            combined = true;
        }
    }

    public void Double()
    {
        value *= 2;
        valueDsiplayText.text = value.ToString();
    }
}