using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodChange : MonoBehaviour
{
    [SerializeField] private Sprite coloredSprite;

    private Image image;

    [SerializeField] private bool food1;
    [SerializeField] private bool food2;

    public static bool food1static, food2static;
    void Start()
    {
        image = GetComponent<Image>();
        food1static = false;
        food2static = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(food1)
        {
            if (food1static)
            {
                image.sprite = coloredSprite;
            }
        }

        if(food2)
        {
            if (food2static)
            {
                image.sprite = coloredSprite;
            }
        }
    }
}
