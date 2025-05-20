using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public Transform itemDetail;
    public Image selectIcon;
    public TMP_Text descriptionText;
    public Transform rightPanelTranform;
    public GameObject itemPrefab;

    public void OnOpen()
    {
        itemDetail.gameObject.SetActive(false);
        for(int i = rightPanelTranform.childCount - 1; i >=0; i++)
        {
            Destroy(rightPanelTranform.GetChild(i).gameObject);
        }
        for(int i = 0;i< InventoryManager.instance.inventoryList.Count; i++)
        {
            GameObject itemButtonObj = Instantiate(itemPrefab, rightPanelTranform);
            ItemButton itemButtonComp = itemButtonObj.GetComponent<ItemButton>();
            itemButtonComp.data = InventoryManager.instance.inventoryList[i];
            itemButtonComp.icon.sprite = itemButtonComp.data.itemIcon;
            Button button = itemButtonObj.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                itemDetail.gameObject.SetActive(true);
                selectIcon.sprite = itemButtonComp.data.itemIcon;
                descriptionText.text = itemButtonComp.data.description;
            });
        }
    }
}
