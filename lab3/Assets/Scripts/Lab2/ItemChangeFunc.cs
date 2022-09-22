using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChangeFunc : MonoBehaviour
{
    public ItemColor color;
    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent(out ItemRandomize itemRandomize))
        {
            color = itemRandomize.color;
        }
    }
    ItemColor GetThisColor()
    {
        return this.color;
    }
    void SetThisColor(ItemColor color)
    {
        this.color = color;
    }
}
