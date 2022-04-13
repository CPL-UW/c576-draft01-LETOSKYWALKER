using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mirror;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject myPrefab;
    private GameObject zoomCard;

    public void Awake()
    {
        Canvas = GameObject.Find("Canvas");
    }

    public void OnHoverEnter()
    {
        zoomCard = Instantiate(myPrefab, new Vector2(Input.mousePosition.x - 324, Input.mousePosition.y + 25 -188), Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.layer = LayerMask.NameToLayer("Zoom");
        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(132, 176);
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard);
    }
}
