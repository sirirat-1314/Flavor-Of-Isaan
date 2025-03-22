using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml.Linq;
using System.ComponentModel;
using System.Threading;
using Unity.VisualScripting;

[Serializable]

public class ItemSlot
{
    public Item item;
    public int count;

    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    public void Set(Item item,int count)
    {
        this.item = item;
        this.count = count;
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item item,int count = 1)
    {
        if(item.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(X => X.item == item);
            if(itemSlot != null)
            {

                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(X => X.item == null);
                if(itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }

        }
        else
        {
            ItemSlot itemSlot = slots.Find(X => X.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
        
    }

    internal bool CheckFreeSpace()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == null)
            {
                return true;
            }
        }

        return false;
    }

    internal bool CheckItem(ItemSlot checkingItem)
    {
        ItemSlot itemSlot = slots.Find(X => X.item == checkingItem.item);

        if(itemSlot == null) { return false;  }

        if(checkingItem.item.stackable) { return itemSlot.count > checkingItem.count; }

        return true;
    }

    public void Remove(Item itemToRemove, int count = 1)
    {
        if (itemToRemove == null)
        {
            Debug.LogError("❌ Remove: Item to remove is NULL!");
            return;
        }

        if (itemToRemove.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
            if (itemSlot == null)
            {
                Debug.LogWarning($"⚠️ Item {itemToRemove.name} not found in inventory.");
                return;
            }

            itemSlot.count -= count;
            if (itemSlot.count <= 0)
            {
                itemSlot.Clear();
            }
        }
        else
        {
            while (count > 0)
            {
                count--;
                ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
                if (itemSlot == null)
                {
                    Debug.LogWarning($"⚠️ Non-stackable item {itemToRemove.name} not found!");
                    break;
                }

                itemSlot.Clear();
            }
        }
    }



}




