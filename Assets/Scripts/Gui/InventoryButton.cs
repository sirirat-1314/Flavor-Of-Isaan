using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI text;

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot itemSlot)
    {
        icon.sprite = itemSlot.item.icon;
        icon.gameObject.SetActive(true);

        if (itemSlot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = itemSlot.count.ToString();
        }
        else {
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
        ItemContainer inventory = GameManager.instance.inventoryContainer;
        GameManager.instance.dragAndDropController.OnClick(inventory.slots[myIndex]);
        transform.parent.GetComponent<InventoryPanel>().Show();
    }
}