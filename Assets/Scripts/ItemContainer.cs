using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml.Linq;

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
}
