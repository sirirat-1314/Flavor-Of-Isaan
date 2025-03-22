using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI text;
    private int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot itemSlot)
    {
        if (itemSlot == null || itemSlot.item == null)
        {
            Clean();
            return;
        }

        icon.sprite = itemSlot.item.icon;
        icon.gameObject.SetActive(true);

        if (itemSlot.item.stackable)
        {
            text.gameObject.SetActive(true);
            text.text = itemSlot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = GetComponentInParent<ItemPanel>();

        if (itemPanel == null)
        {
            itemPanel = FindObjectOfType<ItemPanel>(); // ค้นหา ItemPanel ทั่ว Scene
        }

        if (itemPanel != null)
        {
            Debug.Log($"✅ ItemPanel found! Calling OnClick for index {myIndex}");
            itemPanel.OnClick(myIndex);
        }
        else
        {
            Debug.LogWarning("❌ ItemPanel not found! Check your Hierarchy setup.");
        }
    }
}
