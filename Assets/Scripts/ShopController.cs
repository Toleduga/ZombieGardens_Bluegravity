using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public GameObject[] clothesGroup;
    public TMP_Text priceText;

    public Clothe clotheSelected;

    public void SetGroup(int indexGroup)
    {
        CleanGroup();
        CleanPrice();
        clothesGroup[indexGroup].SetActive(true);
    }

    private void CleanGroup()
    {
        foreach (GameObject _group in clothesGroup)
        {
            _group.SetActive(false);
        }
    }

    private void CleanPrice()
    {
        priceText.text = "0";
    }

    public void SetPrice(int price)
    {
        priceText.text = price.ToString();
    }

    public void BuyItem()
    {
        clotheSelected.acquired = true;
    }
}
