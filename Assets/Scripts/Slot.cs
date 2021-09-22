using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slot : MonoBehaviour
{
    [SerializeField] private Slot right;
    [SerializeField] private Slot left;
    [SerializeField] private Slot up;
    [SerializeField] private Slot down;

    public FillSquare fill;

    private void OnEnable()
    {
        GameControl.slide += OnSlide;
    }

    private void OnDisable()
    {
        GameControl.slide -= OnSlide;
    }

    private void OnSlide(String whatWasSent)
    {
        if (whatWasSent == "W")
        {
            if (up != null)
                return;
            Slot currentSlot = this;
            SlideUp(currentSlot);
        }
        if (whatWasSent == "D")
        {
 
        }
        if (whatWasSent == "A")
        {
  
        }
        if (whatWasSent == "S")
        {

        }
    }

    private void SlideUp(Slot currentSlot)
    {
        if (currentSlot.down == null)
            return;

        if (currentSlot.fill != null)
        {
            Slot nextSlot = currentSlot.down;
            while (nextSlot.down != null && nextSlot.fill == null)
            {
                nextSlot = nextSlot.down;
            }
            if (nextSlot.fill != null)
            {
                if (currentSlot.fill.value == nextSlot.fill.value)
                {
                    nextSlot.fill.Double();
                    nextSlot.fill.transform.parent = currentSlot.transform;
                    currentSlot.fill = nextSlot.fill;
                    nextSlot.fill = null;
                }
                else
                {
                    nextSlot.fill.transform.parent = currentSlot.down.transform;
                    currentSlot.down.fill = nextSlot.fill;
                    nextSlot.fill = null;
                }
            }
        }
        else
        {
            Slot nextSlot = currentSlot.down;
            while (nextSlot.down != null && nextSlot.fill == null)
            {
                nextSlot = nextSlot.down;
            }
            if (nextSlot.fill != null)
            {
                nextSlot.fill.transform.parent = currentSlot.transform;
                currentSlot.fill = nextSlot.fill;
                nextSlot.fill = null;
                SlideUp(currentSlot);
            }


            if (currentSlot.down == null)
                return;
            SlideUp(currentSlot.down);
        }
    }
}
