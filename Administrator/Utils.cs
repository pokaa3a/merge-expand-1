using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static void SetSprite(GameObject obj, string spritePath)
    {
        SpriteRenderer sprRend = obj.GetComponent<SpriteRenderer>();
        if (sprRend == null)
            sprRend = obj.AddComponent<SpriteRenderer>();
        sprRend.sprite = Resources.Load<Sprite>(spritePath);
    }

    public static void SetSpriteSortingOrder(GameObject obj, int idx)
    {
        SpriteRenderer sprRend = obj.GetComponent<SpriteRenderer>();
        if (sprRend == null)
            sprRend = obj.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sprRend.sortingOrder = idx;
    }
}
