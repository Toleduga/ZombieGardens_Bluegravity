using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public PlayerInteractor playerInteractor;
    public TMP_Text textFlowers;

    // Update is called once per frame
    void Update()
    {
        textFlowers.text = playerInteractor.flowers.ToString();
    }
}
