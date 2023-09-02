using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public GameObject[] popUps;
    public TopDownCharacterController playercontroller;
    int count = 0;

    public void NextFrame()
    {
        count++;
        foreach (GameObject _frame in popUps)
        {
            _frame.SetActive(false);
        }
        if (count > 2)
        {
            this.gameObject.SetActive(false);
            playercontroller.UImode = false;
        }
        else {
            popUps[count].SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            NextFrame();
        }
    }
}
