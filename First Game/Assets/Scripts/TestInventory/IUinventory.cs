using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUinventory : MonoBehaviour
{
    public GameObject inventory;
    public bool inventoryOn;

    public UIslot[] slots;

    [SerializeField] private AudioSource Take;

    private void Start()
    {
        inventoryOn = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.SetActive(inventory.activeInHierarchy);
        }

    }

    public void AddItem(UIitem itemToBeAdded, UIitem startingItem = null)
    {
        int amountInStack = itemToBeAdded.amountInStack;
        List<UIitem> stackableItems = new List<UIitem>();
        List<UIslot> empetySlots = new List<UIslot>();

        if (startingItem && startingItem.itemID == itemToBeAdded.itemID && startingItem.amountInStack < startingItem.maxStackSize)
            stackableItems.Add(startingItem);

        foreach(UIslot i in slots)
        {
            if (i.slotsItem)
            {
                UIitem z = i.slotsItem;
                if (z.itemID == itemToBeAdded.itemID && z.amountInStack < z.maxStackSize && z != startingItem)
                    stackableItems.Add(z);
            }
            else
            {
                empetySlots.Add(i);
            }

        }

        foreach(UIitem i in stackableItems)
        {
            int amountThatCanAdded = i.maxStackSize = i.amountInStack;
            if(amountInStack <= amountThatCanAdded)
            {
                i.amountInStack += amountInStack;
                Destroy(itemToBeAdded.gameObject);
                return;
            }
            else
            {
                i.amountInStack = i.maxStackSize;
                amountInStack -= amountThatCanAdded;
            }
        }

        itemToBeAdded.amountInStack = amountInStack;
        if(empetySlots.Count > 0)
        {
            itemToBeAdded.transform.parent = empetySlots[0].transform;
            itemToBeAdded.gameObject.SetActive(false);
        }
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<UIitem>())
        {
            AddItem(collision.GetComponent<UIitem>());
            Take.Play();
        }
 
    }

    public void Chest()
    {
        if (inventoryOn == false)
        {
            inventoryOn = true;
            inventory.SetActive(true);
        }
        else if (inventoryOn == true)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }
}