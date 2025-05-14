using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopUI : BaseUI
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI currentGoldText;
    [SerializeField] private ShopItemSlot[] itemSetting;
    private int currentPage = 1;
    private int itemsPerPage = 3;
    private int totalPage;
    Dictionary<string, ItemSO> ownedItems;
    List<ItemSO> allItems;



    protected override UIState UIState { get; } = UIState.Shop;

    protected override void Initialize()
    {
        base.Initialize();

        allItems = DataManager.Instance.GetAllItems();
        ownedItems = DataManager.Instance.GetOwnedItems();
        totalPage = allItems.Count / 3 + 1;
        prevButton.onClick.AddListener(PrevButton);
        nextButton.onClick.AddListener(NextButton);
        exitButton.onClick.AddListener(UIManager.Instance.CloseUI);
    }

    private void OnDestroy()
    {
        DataManager.Instance.RemoveChangeOwnedItemsEvent();
    }

    public override void SetUIActive(bool isActive)
    {
        if (!isActive) DataManager.Instance.RemoveChangeOwnedItemsEvent();
        base.SetUIActive(isActive);
        DataManager.Instance.AddChangeOwnedItemsEvent(UpdateOwnedItems);
        currentPage = 1;
        UpdatePageButton();
        UpdateOwnedItems();
    }

    void UpdateOwnedItems()
    {
        currentGoldText.text = $"골드 : {DataManager.Instance.GetGold()}";
        int start = (currentPage - 1) * itemsPerPage;
        int end = currentPage * itemsPerPage;
        int idx = 0;


        for (int i = start; i < end; i++)
        {
            if (i < allItems.Count)
            {

                if (ownedItems.ContainsKey(allItems[i].id))
                    itemSetting[idx].ItemSet(allItems[i], false);
                else
                    itemSetting[idx].ItemSet(allItems[i], true);

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
            UpdateOwnedItems();
        }
    }

    void NextButton()
    {
        if (currentPage < totalPage)
        {
            currentPage++;
            UpdateOwnedItems();
        }
    }
}
