using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public ClotheItem[] jackects;
    public ClotheItem[] Backpacks;
    public ClotheItem[] Pants;
    public ClotheItem[] Shoes;

    public Image imageJackects;
    public Image imageBackpacks;
    public Image imagePants;
    public Image imageShoes;

    public GameObject playerJackect;
    public GameObject playerBackpack;
    public GameObject playerPants;
    public GameObject playerShoes;

    private ClothesCheck CheckJackect;
    private ClothesCheck CheckBackpack;
    private ClothesCheck CheckPants;
    private ClothesCheck CheckShoes;

    private void OnEnable()
    {
        foreach (ClotheItem _chlote in jackects)
        {
            _chlote.toggle.interactable = _chlote.clothe.acquired;
        }
        foreach (ClotheItem _chlote in Backpacks)
        {
            _chlote.toggle.interactable = _chlote.clothe.acquired;
        }
        foreach (ClotheItem _chlote in Pants)
        {
            _chlote.toggle.interactable = _chlote.clothe.acquired;
        }
        foreach (ClotheItem _chlote in Shoes)
        {
            _chlote.toggle.interactable = _chlote.clothe.acquired;
        }
        CheckBackpack = playerBackpack.GetComponent<ClothesCheck>();
        CheckJackect = playerJackect.GetComponent<ClothesCheck>();
        CheckPants = playerPants.GetComponent<ClothesCheck>();
        CheckShoes = playerShoes.GetComponent<ClothesCheck>();
        SetNowClothes();
    }

    private void SetNowClothes()
    {
        int slot = 0; 
        foreach (GameObject _chothe in CheckJackect.clothes)
        {
            if (_chothe.activeSelf)
            {
                imageJackects.sprite = jackects[slot].clothe.sprite;
            }
            slot++;
        }
        slot = 0;
        foreach (GameObject _chothe in CheckBackpack.clothes)
        {
            if (_chothe.activeSelf)
            {
                imageBackpacks.sprite = Backpacks[slot].clothe.sprite;
            }
            slot++;
        }
        slot = 0;
        foreach (GameObject _chothe in CheckPants.clothes)
        {
            if (_chothe.activeSelf)
            {
                imagePants.sprite = Pants[slot].clothe.sprite;
            }
            slot++;
        }
        slot = 0;
        foreach (GameObject _chothe in CheckShoes.clothes)
        {
            if (_chothe.activeSelf)
            {
                imageShoes.sprite = Shoes[slot].clothe.sprite;
            }
            slot++;
        }

    }

    private void EquipClothePlayer(GameObject _clothe, int _indexItem)
    {
        int count = _clothe.transform.childCount;
        //Debug.LogFormat("number childs: {0}", count);
        for (int i = 0; i < count; i++)
        {
            //Debug.LogFormat("number: {0}", i);
            _clothe.transform.GetChild(i).gameObject.SetActive(false);
        }
        _clothe.transform.GetChild(_indexItem).gameObject.SetActive(true);
    }

    public (TypeClothes, int) GetTypeClothes(int _id)
    {
        TypeClothes _type = TypeClothes.backpack;
        int slot = 0; 
        foreach (ClotheItem _chlote in jackects)
        {
            if (_chlote.clothe.id == _id)
            {
                _type = _chlote.clothe.type;
                slot = _chlote.clothe.slot;
            }
        }
        foreach (ClotheItem _chlote in Backpacks)
        {
            if (_chlote.clothe.id == _id)
            {
                _type = _chlote.clothe.type;
                slot = _chlote.clothe.slot;
            }
        }
        foreach (ClotheItem _chlote in Pants)
        {
            if (_chlote.clothe.id == _id)
            {
                _type = _chlote.clothe.type;
                slot = _chlote.clothe.slot;
            }
        }
        foreach (ClotheItem _chlote in Shoes)
        {
            if (_chlote.clothe.id == _id)
            {
                _type = _chlote.clothe.type;
                slot = _chlote.clothe.slot;
            }
        }
        return (_type , slot);
    }

    public void EquipClothe(int _id)
    {
        var dubla = GetTypeClothes(_id);
        TypeClothes _type = dubla.Item1;
        int slot = dubla.Item2;
        //Debug.LogFormat("Type: {0}  Slot: {1}", _type, slot);
        switch (_type)
        {
            case TypeClothes.backpack:
                imageBackpacks.sprite = Backpacks[slot].clothe.sprite;
                EquipClothePlayer(playerBackpack, slot);
                CheckBackpack.SetClothes();
                break;
            case TypeClothes.jacket:
                imageJackects.sprite = jackects[slot].clothe.sprite;
                EquipClothePlayer(playerJackect, slot);
                CheckJackect.SetClothes();
                break;
            case TypeClothes.pants:
                imagePants.sprite = Pants[slot].clothe.sprite;
                EquipClothePlayer(playerPants, slot);
                CheckPants.SetClothes();
                break;
            case TypeClothes.shoes:
                imageShoes.sprite = Shoes[slot].clothe.sprite;
                EquipClothePlayer(playerShoes, slot);
                CheckShoes.SetClothes();
                break;
        }
    }
}
