using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesCheck : MonoBehaviour
{
    
    public GameObject[] clothes;
    public int index;
    private TopDownCharacterController CharacterController;
    private Animator animator;

    private void Start()
    {
        CharacterController = FindObjectOfType<TopDownCharacterController>();
        SetClothes();
    }


    public void SetClothes()
    {
        foreach (GameObject _chothe in clothes)
        {
            if (_chothe.activeSelf)
            {
                animator = _chothe.GetComponent<Animator>();
            }
            
        }
        CharacterController.animator[index] = animator; 
    }
}
