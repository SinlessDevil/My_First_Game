using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIslot : MonoBehaviour
{
    public UIitem slotsItem;

    Sprite defaultSprite;
    Text amounText;
    private Transform player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        defaultSprite = GetComponent<Image>().sprite;
        amounText = transform.GetChild(0).GetComponent<Text>();
        
    }

    private void Update()
    {
        CheckForItem();
    }

    public void DropItem()
    {
        if (slotsItem)
        {
            slotsItem.transform.parent = null;
            slotsItem.gameObject.SetActive(true);
            Vector2 playerPos = new Vector2(player.position.x + 2, player.position.y - 1);
            slotsItem.transform.position = playerPos;
        }
    }

    public void CheckForItem()
    {
        if (transform.childCount > 1)
        {
            slotsItem = transform.GetChild(1).GetComponent<UIitem>();
            GetComponent<Image>().sprite = slotsItem.ItemSprite;
            if (slotsItem.amountInStack > 1)
                amounText.text = slotsItem.amountInStack.ToString();
        }
        else
        {
            slotsItem = null;
            GetComponent<Image>().sprite = defaultSprite;
            amounText.text = "";
        }
    }
}
