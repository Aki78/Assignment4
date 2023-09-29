using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;



public class NumberManager : MonoBehaviour
{
    public TextMeshProUGUI TotalNumberText;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
//        print("number manager update");

        TotalNumberText.text = "Cookies: " +  GameManager.Money.ToString();
        
    }
}
