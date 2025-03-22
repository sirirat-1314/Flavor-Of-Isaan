using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject statusPanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)){

            panel.SetActive(!panel.activeInHierarchy);
            statusPanel.SetActive(!statusPanel.activeInHierarchy);
        }
    }
}
