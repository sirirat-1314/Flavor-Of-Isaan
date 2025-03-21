using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[CreateAssetMenu(menuName ="Data/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemSlot> element;
    public ItemSlot output;
}
