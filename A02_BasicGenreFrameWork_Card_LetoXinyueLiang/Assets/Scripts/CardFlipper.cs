using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipper : MonoBehaviour
{
    public Sprite CardFront;
    public Sprite CardBcak;

    public void Flip()
    {
        Sprite currentSprite = gameObject.GetComponent<Image>().sprite;
        if (currentSprite == CardFront)
        {
            gameObject.GetComponent<Image>().sprite = CardBcak;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = CardFront;
        }
    }
}
