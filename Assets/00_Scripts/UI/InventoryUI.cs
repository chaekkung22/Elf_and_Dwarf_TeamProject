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
    [SerializeField] private InventoryItemSlot[] itemSetting;
    private int currentPage = 1;
    private int itemsPerPage = 3;
    private int totalPage;
    Dictionary<string, ItemSO> ownedItems;
    private ItemSO equipedItem;



    protected override UIState UIState { get; } = UIState.Shop;

    protected override void Initialize()
    {
        base.Initialize();
        equipedItem = DataManager.Instance.GetEquipedItem();
        ownedItems = DataManager.Instance.GetOwnedItems();
        totalPage = ownedItems.Count / 3 + 1;
        prevButton.onClick.AddListener(PrevButton);
        nextButton.onClick.AddListener(NextButton);
        exitButton.onClick.AddListener(UIManager.Instance.CloseUI);
        DataManager.Instance.AddChangeEquipedItemEvent(UpdateEquipedItems);
    }

    public override void SetUIActive(bool isActive)
    {
        base.SetUIActive(isActive);
        currentPage = 1;

        UpdatePageButton();
        UpdateEquipedItems();
    }

    void UpdateEquipedItems()
    {
        int start = (currentPage - 1) * itemsPerPage;
        int end = currentPage * itemsPerPage;
        int idx = 0;


        for (int i = start; i < end; i++)
        {
            if (i < ownedItems.Count)
            {
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
