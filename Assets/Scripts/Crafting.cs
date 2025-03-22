using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;

    public void Craft(CraftingRecipe recipe)
    {
        if (inventory == null)
        {
            Debug.LogError("❌ Crafting: Inventory reference is missing!");
            return;
        }

        if (!inventory.CheckFreeSpace())
        {
            Debug.Log("⚠️ Not enough space in inventory!");
            return;
        }

        // ตรวจสอบว่ามีไอเท็มครบหรือไม่
        foreach (var element in recipe.elements)
        {
            if (!inventory.CheckItem(element))
            {
                Debug.Log("⚠️ Not enough materials to craft this item!");
                return;
            }
        }

        // ลบไอเท็มที่ใช้คราฟต์
        foreach (var element in recipe.elements)
        {
            inventory.Remove(element.item, element.count);
        }

        // เพิ่มไอเท็มที่คราฟต์สำเร็จ
        inventory.Add(recipe.output.item, recipe.output.count);

        Debug.Log($"✅ Crafted {recipe.output.item.name} x {recipe.output.count}!");
    }

}
