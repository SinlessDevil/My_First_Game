using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour
{
   public IUinventory inv;

    GameObject curSlot;
    UIitem curSlotsItem;

    public Image followMouseImage;

    [SerializeField] private AudioSource drop;

    private void Update()
    {
        followMouseImage.transform.position = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.G))
        {
            drop.Play();
            GameObject obj = GetObjectUnderMouse();
            if (obj)
                obj.GetComponent<UIslot>().DropItem();

        }

        if (Input.GetMouseButtonDown(0))
        {
            curSlot = GetObjectUnderMouse();
        }
        else if (Input.GetMouseButton(0))
        {
            if (curSlot && curSlot.GetComponent<UIslot>().slotsItem)
            {
                followMouseImage.color = new Color(255, 255, 255, 255);
                followMouseImage.sprite = curSlot.GetComponent<Image>().sprite;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (curSlot && curSlot.GetComponent<UIslot>().slotsItem)
            {
                curSlotsItem = curSlot.GetComponent<UIslot>().slotsItem;

                GameObject newObj = GetObjectUnderMouse();
                if (newObj && newObj != curSlot)
                {
                    if (newObj.GetComponent<UIslot>().slotsItem)
                    {
                        UIitem objectsItem = newObj.GetComponent<UIslot>().slotsItem;
                        if (objectsItem.itemID == curSlotsItem.itemID && objectsItem.amountInStack != objectsItem.maxStackSize)
                        {
                            curSlotsItem.transform.parent = null;
                            inv.AddItem(curSlotsItem, objectsItem);
                        }
                        else
                        {
                            objectsItem.transform.parent = curSlot.transform;
                            curSlotsItem.transform.parent = newObj.transform;
                        }
                    }
                    else
                    {
                        curSlotsItem.transform.parent = newObj.transform;
                    }
                }
            }
        }
        else
        {
            followMouseImage.sprite = null;
            followMouseImage.color = new Color(0, 0, 0, 0);
        }
    }

    GameObject GetObjectUnderMouse()
    {
        GraphicRaycaster reyCaster = GetComponent<GraphicRaycaster>();
        PointerEventData eventData = new PointerEventData(EventSystem.current);

        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        reyCaster.Raycast(eventData, results);

        foreach (RaycastResult i in results)
        {
            if (i.gameObject.GetComponent<UIslot>())
                return i.gameObject;
        }
        return null;
    }
}
