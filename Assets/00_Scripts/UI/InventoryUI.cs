using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : BaseUI
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI currentGoldText;
    [SerializeField] private InventoryItemSlot[] itemSetting;

    private int currentPage = 1;
    private int itemsPerPage = 3;
    private int totalPage;
    List<ItemSO> ownedItems;
    private ItemSO equipedItem;



    protected override UIState UIState { get; } = UIState.Inventory;

    protected override void Initialize()
    {
        base.Initialize();
        ownedItems = DataManager.Instance.GetOwnedItemList();
        prevButton.onClick.AddListener(PrevButton);
        nextButton.onClick.AddListener(NextButton);
        exitButton.onClick.AddListener(UIManager.Instance.CloseUI);
    }

    public override void SetUIActive(bool isActive)
    {
        if (!isActive) DataManager.Instance.RemoveChangeEquipedItemEvent();
        base.SetUIActive(isActive);
        DataManager.Instance.AddChangeEquipedItemEvent(UpdateEquipedItems);
        currentPage = 1;
        totalPage = Mathf.Max(1, Mathf.CeilToInt((float)ownedItems.Count / itemsPerPage));
        UpdatePageButton();
        UpdateEquipedItems();
    }

    void UpdateEquipedItems()
    {
        equipedItem = DataManager.Instance.GetEquipedItem();
        currentGoldText.text = $"골드 : {DataManager.Instance.GetGold()}";

        int start = (currentPage - 1) * itemsPerPage;
        int end = currentPage * itemsPerPage;
        int idx = 0;

        for (int i = start; i < end; i++)
        {
            if (i < ownedItems.Count)
            {
                if (equipedItem == ownedItems[i])
                    itemSetting[idx].ItemSet(ownedItems[i], true);
                else
                    itemSetting[idx].ItemSet(ownedItems[i], false);

                itemSetting[idx++].gameObject.SetActive(true);
            }
            else
            {
                itemSetting[idx++].gameObject.SetActive(false);
            }
        }
        UpdatePageButton();
    }

    void UpdatePageButton()
    {
        if (totalPage <= 1)
        {
            prevButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            prevButton.gameObject.SetActive(currentPage > 1);
            nextButton.gameObject.SetActive(currentPage < totalPage);
        }
    }


    void PrevButton()
    {
        if (currentPage > 1)
        {
            currentPage--;
            UpdateEquipedItems();
        }
    }

    void NextButton()
    {
        if (currentPage < totalPage)
        {
            currentPage++;
            UpdateEquipedItems();
        }
    }
}
