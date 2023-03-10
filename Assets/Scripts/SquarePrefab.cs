using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquarePrefab : MonoBehaviour
{
    [SerializeField] private Text valueDsiplayText;
    [SerializeField] private float speed;

    //int
    public int value;

    //bool
    private bool combined = false;

    //Color
    Image myImage;

    //bool
    public bool multiply;

    private void Update()
    {
        CombineCheck();
    }
    public void FillUpdate(int valueIn)
    {
        value = valueIn;
        valueDsiplayText.text = value.ToString();

        int colorindex = GetColorIndex(value);
        myImage = GetComponent<Image>();
        myImage.color = GameControl.instance.myColors[colorindex];
    }
    int GetColorIndex(int number)
    {
        int index = 0;
        while (number != 1)
        {
            index++;
            number /= 2;
        }

        index--;
        return index;
    }

    private void CombineCheck()
    {
        if (transform.localPosition != Vector3.zero)
        {
            combined = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        else if (combined == false)
        {
            if (transform.parent.GetChild(0) != this.transform)
            {
                Destroy(transform.parent.GetChild(0).gameObject);
            }
            combined = true;
        }
    }

    public void Double()
    {
        if (multiply)
        {
            value *= 2;
            valueDsiplayText.text = value.ToString();

            int colorindex = GetColorIndex(value);
            myImage.color = GameControl.instance.myColors[colorindex];

            Score.instance.ScoreUpdate(10);
            Score.instance.WinPanel(value);
        }
        else if(multiply == false)
        {
            value /= 2;
            valueDsiplayText.text = value.ToString();

            int colorindex = GetColorIndex(value);
            myImage.color = GameControl.instance.myColors[colorindex];

            Score.instance.ScoreUpdate(10);
            Score.instance.WinPanel(value);
        }
    }
}
