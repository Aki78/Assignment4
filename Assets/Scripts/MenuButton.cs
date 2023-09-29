using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveButton : MonoBehaviour
{

    private bool menuOn = false;

    public Vector3 targetPosition = new Vector3(0, 0, 0);
    public Vector3 backPosition = new Vector3(-20, -100, 0);

    private void OnMouseDown()
    {
        if (menuOn)
        {
            EventManager.instance.TriggerMoveSquareEvent(targetPosition);
            menuOn = false;
            print("Button Clicked to False");
//            PauseAfterDelay(2f);A // Can't do this because physics relies on dt, and it breaks 
//            Time.timeScale = 0f;
        }
        else
        {
            EventManager.instance.TriggerMoveSquareEvent(backPosition);
            menuOn = true;
            print("Button Clicked to true");
//            Time.timeScale = 1f;A // Can't do this because physics relies on dt, and it breaks 
        }
    }

//    IEnumerator PauseAfterDelay(float delay)
//{
//    yield return new WaitForSeconds(delay);
//    Time.timeScale = 0f;
//}

}
