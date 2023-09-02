using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewClothe", menuName = "Clothe")]
public class Clothe : ScriptableObject
{
    public string ClotheColor;
    public TypeClothes type;
    public Sprite sprite;
    public int id;
    public int slot;
    public int price;
    public bool acquired;
}
