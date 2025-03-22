using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    public ItemContainer inventory;
    public List<InventoryButton> buttons;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        if (buttons == null || buttons.Count == 0)
        {
            Debug.LogWarning("⚠️ ItemPanel: buttons list is empty! Please assign InventoryButtons in Inspector.");
            return;
        }

        SetIndex();
        Show();
    }

    private void OnEnable()
    {
        Show();
    }

    private void SetIndex()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public virtual void Show()
    {
        if (inventory == null)
        {
            Debug.LogError("❌ ItemPanel: Inventory reference is missing!");
            return;
        }

        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }

    public virtual void OnClick(int id)
    {
        Debug.Log($"🖱️ Clicked on inventory slot {id}");
        // ใส่โค้ดเพิ่มเติมถ้าต้องการให้มีฟังก์ชันใช้งาน
    }
}
