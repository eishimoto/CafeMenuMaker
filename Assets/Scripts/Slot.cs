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
        if (whatWasSent == "w")
        {
            if (up != null)
            {
                return;
            }
            Slot currentSlot = this;
            SlideUp(currentSlot);
        }
        if (whatWasSent == "d")
        {
            if (right != null)
            {
                return;
            }
            Slot currentSlot = this;
            SlideRight(currentSlot);
        }
        if (whatWasSent == "a")
        {
            if (left != null)
            {
                return;
            }
            Slot currentSlot = this;
            SlideLeft(currentSlot);
        }
        if (whatWasSent == "s")
        {
            if (down != null)
            {
                return;
            }
            Slot currentSlot = this;
            SlideDown(currentSlot);
        }

        GameControl.ticker++;
        if (GameControl.ticker == 4)
        {
            GameControl.instance.FullCheck();
        }
    }

    void SlideUp(Slot currentSlot)
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
                else if(currentSlot.down.fill != nextSlot.fill)
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
        }
        if (currentSlot.down == null)
        {
            return;
        }
        SlideUp(currentSlot.down);
    }
    void SlideRight(Slot currentSlot)
    {
        if (currentSlot.left == null)
            return;

        if (currentSlot.fill != null)
        {
            Slot nextSlot = currentSlot.left;
            while (nextSlot.left != null && nextSlot.fill == null)
            {
                nextSlot = nextSlot.left;
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
                else if(currentSlot.left.fill != nextSlot.fill)
                {
                    nextSlot.fill.transform.parent = currentSlot.left.transform;
                    currentSlot.left.fill = nextSlot.fill;
                    nextSlot.fill = null;
                }
            }
        }
        else
        {
            Slot nextSlot = currentSlot.left;
            while (nextSlot.left != null && nextSlot.fill == null)
            {
                nextSlot = nextSlot.left;
            }
            if (nextSlot.fill != null)
            {
                nextSlot.fill.transform.parent = currentSlot.transform;
                currentSlot.fill = nextSlot.fill;
                nextSlot.fill = null;
                SlideRight(currentSlot);
            }
        }
        if (currentSlot.left == null)
        {
            return;
        }
        SlideRight(currentSlot.left);
    }
    void SlideLeft(Slot currentSlot)
    {
        if (currentSlot.right == null)
            return;

        if (currentSlot.fill != null)
        {
            Slot nextSlot = currentSlot.right;
            while (nextSlot.right != null && nextSlot.fill == null)
            {
                nextSlot = nextSlot.right;
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
                else if (currentSlot.right.fill != nextSlot.fill)
                {
                    nextSlot.fill.transform.parent = currentSlot.right.transform;
                    currentSlot.right.fill = nextSlot.fill;
                    nextSlot.fill = null;
                }
            }
        }
        else
        {
            Slot nextSlot = currentSlot.right;
            while (nextSlot.right != null && nextSlot.fill == null)
            {
                nextSlot = nextSlot.right;
            }
            if (nextSlot.fill != null)
            {
                nextSlot.fill.transform.parent = currentSlot.transform;
                currentSlot.fill = nextSlot.fill;
                nextSlot.fill = null;
                SlideLeft(currentSlot);
            }
        }
        if (currentSlot.right == null)
        {
            return;
        }
        SlideLeft(currentSlot.right);
    }
    void SlideDown(Slot currentSlot)
    {
        if (currentSlot.up == null)
            return;

        if (currentSlot.fill != null)
        {
            Slot nextSlot = currentSlot.up;
            while (nextSlot.up != null && nextSlot.fill == null)
            {
                nextSlot = nextSlot.up;
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
                else if (currentSlot.up.fill != nextSlot.fill)
                {
                    nextSlot.fill.transform.parent = currentSlot.up.transform;
                    currentSlot.up.fill = nextSlot.fill;
                    nextSlot.fill = null;
                }
            }
        }
        else
        {
            Slot nextSlot = currentSlot.up;
            while (nextSlot.up != null && nextSlot.fill == null)
            {
                nextSlot = nextSlot.up;
            }
            if (nextSlot.fill != null)
            {
                nextSlot.fill.transform.parent = currentSlot.transform;
                currentSlot.fill = nextSlot.fill;
                nextSlot.fill = null;
                SlideDown(currentSlot);
            }       
        }
        if (currentSlot.up == null)
        {
            return;
        }
        SlideDown(currentSlot.up);
    }

}
