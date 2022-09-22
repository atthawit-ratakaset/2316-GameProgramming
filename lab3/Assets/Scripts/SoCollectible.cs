using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectibles")]
public class SoCollectible : ScriptableObject
{
    [SerializeField] private string collectibleName;
    [SerializeField] private Types collectibleType;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] bool Respawnable;
    public string GetCollectible()
    {
        return collectibleName;
    }
}
