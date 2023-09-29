using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private float handButtonInterval = 1.0f;

    public static int Money = 0;

    public static int dm = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartHandButtonEffect()
    {
        StartCoroutine(HandButtonEffect());
    }

    private System.Collections.IEnumerator HandButtonEffect()
    {
        while (true)
        {
            AddMoney();
            yield return new WaitForSeconds(handButtonInterval);
        }
    }

    public void IncreaseHandButtonSpeed()
    {
        handButtonInterval *= 0.9f;
    }

    public void AddMoneyRate()
    {
        print("Adding Money");
        dm += 1;
        print(Money);
        Debug.Log(Money);
        Debug.Log("dm is: ");
        Debug.Log(dm);
    }


    public static void AddMoney()
    {
        print("Adding Money");
        Money += dm;
    }

    public static void TakeMoney(int amount)
    {
        print("taking Money");
        Money -= amount;
    }

    public static void ResetMoney()
    {
        print("Resetting...   ");
        Money = 0;
        dm = 1;
//        handButtonInterval = 1.0f;
    }
}
