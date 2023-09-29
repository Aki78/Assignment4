
using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    private GameManager gameManager;
    public Spawner spawnerScript;


    public int CookieCost = 10;
    public int HandCost = 20;
    public int HasteCost = 30;



    public TextMeshProUGUI CookieCostText;
    public TextMeshProUGUI HandCostText;
    public TextMeshProUGUI HasteCostText;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnMouseDown()
    {
        Debug.Log(GameManager.Money);
        Debug.Log(CookieCost);
        if (gameObject.name == "CookieButton" && GameManager.Money > CookieCost)
        {
            Debug.Log("Pressed Hand CookieButton");
            gameManager.AddMoneyRate();
            print("Pressed Hand CookieButton");
            print(GameManager.dm);

            GameManager.TakeMoney(CookieCost);


            CookieCost += 10;
            CookieCostText.text = "Cost: " + CookieCost.ToString();
        }

        if (gameObject.name == "HandButton" && GameManager.Money > HandCost)
        {
             gameManager.StartHandButtonEffect();
            print("Pressed Hand Button");
            GameManager.TakeMoney(HandCost);

            HandCost += 20;
            HandCostText.text = "Cost: " + HandCost.ToString();
        }

        if (gameObject.name == "HasteButton" && GameManager.Money > HasteCost)
        {
            gameManager.IncreaseHandButtonSpeed();
            spawnerScript.SpawnObjectAtAngle();
            GameManager.TakeMoney(HasteCost);

            print("Pressed HasteButton");

            HasteCost += 30;
            HasteCostText.text = "Cost: " + HasteCost.ToString();
        }
    }

    public void ResetMe()
    {
        CookieCost = 10;
        HandCost = 20;
        HasteCost = 30;
    }

}
