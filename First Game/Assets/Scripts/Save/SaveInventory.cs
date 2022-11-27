using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveInventory : MonoBehaviour
{
    IUinventory inv;

    public UIitem[] items;

    private void Start()
    {
        inv = GetComponent<IUinventory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            Save();
        else if (Input.GetKeyDown(KeyCode.K))
            Load();
    }

   public void Save()
   {
        List<ItemLoadB> itemsToLoad = new List<ItemLoadB>();
        for(int i = 0; i < inv.slots.Length; i++)
        {
            UIslot z = inv.slots[i];
            if (z.slotsItem)
            {
                ItemLoadB h = new ItemLoadB(z.slotsItem.itemID, z.slotsItem.amountInStack, i);
                itemsToLoad.Add(h);

            }
        }

        string json = CustomJSON.ToJson(itemsToLoad);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + transform.name, json);
        Debug.Log("Saving.....");

    }

   public void Load()
   {
        Debug.Log("Loading.....");
        List<ItemLoadB> itemsToLoad = CustomJSON.FromJson<ItemLoadB>(File.ReadAllText(Application.persistentDataPath + transform.name));
        Debug.Log(itemsToLoad);
        for (int i = itemsToLoad[0].slotIndex; i < inv.slots.Length; i++)
        {
            foreach (ItemLoadB z in itemsToLoad)
            {
                if(i == z.slotIndex)
                {
                    UIitem b = Instantiate(items[z.id], inv.slots[i].transform).GetComponent<UIitem>();
                    b.amountInStack = z.amount;
                    break;
                }
            }
        }
   } 

    public void SaveGame()
    {
        Save();
    }

    public void LoadGame()
    {
        Load();
    }

}

[System.Serializable]
public class ItemLoadB
{
    public int id, amount, slotIndex;

    public ItemLoadB(int ID, int AMOUNT, int SLOTINDEX)
    {
        id = ID;
        amount = AMOUNT;
        slotIndex = SLOTINDEX;
    }
}
