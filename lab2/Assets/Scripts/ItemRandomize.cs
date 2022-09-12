using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomize : MonoBehaviour
{
    public ItemColor color;
    [SerializeField] private Sprite[] spritesArray;
    [SerializeField] private int randInt;
    [SerializeField] private SpriteRenderer Render;
    // Start is called before the first frame update
    void Start()
    {
        Render = GetComponent<SpriteRenderer>();
        randInt = Random.Range(0, spritesArray.Length);
        switch (randInt)
        {
            case 0:
                color = ItemColor.Red;
                break;
            case 1:
                color = ItemColor.Green;
                break;
            case 2:
                color = ItemColor.Blue;
                break;
        }
        Render.sprite = spritesArray[randInt];
    }

}
