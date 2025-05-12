using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] Button equipButton;


    public void ItemSet(ItemSO item, bool isEquiped)
    {
        if (item == null)
        {
            gameObject.SetActive(false);
            return;
        }

        //TODO : 장착한 아이템의 장착하기 버튼을 비활성화 및 문구 바꾸기
        
        itemImage.sprite = item.image;
        itemNameText.text = item.itemName;
        equipButton.onClick.RemoveAllListeners();
        equipButton.onClick.AddListener(() => DataManager.Instance.EquipItem(item));
    }
}
