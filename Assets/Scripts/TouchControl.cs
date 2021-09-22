using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private Vector2 firstPress;
    private Vector2 secondPress;
    private Vector2 currentSwipe;

    public static bool swipeRight;
    public static bool swipeLeft;
    public static bool swipeDown;
    public static bool swipeUp;

    [SerializeField] private float minSwipelenght;

    private void Update()
    {
        SwipeDetection();
    }

    private void SwipeDetection()
    {
        if(Input.touches.Length >0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                firstPress = new Vector2(touch.position.x, touch.position.y);
            }

            if(touch.phase == TouchPhase.Ended)
            {
                secondPress = new Vector2(touch.position.x, touch.position.y);

                currentSwipe = new Vector3(secondPress.x - firstPress.x, secondPress.y - firstPress.y);

                if(currentSwipe.magnitude < minSwipelenght)
                {
                    return;
                }

                currentSwipe.Normalize();

                //up
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                    swipeUp = true;
                }
                //down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                    swipeDown = true;
                }
                //left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                    swipeLeft = true;
                }
                //right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                    swipeRight = true;
                }
            }
        }
    }
}
