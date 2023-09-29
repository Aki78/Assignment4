
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{




    private void OnMouseDown()
    {
        GameManager.ResetMoney();
    }
}
