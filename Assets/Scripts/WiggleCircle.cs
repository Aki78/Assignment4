using UnityEngine;

public class VibrateOnClick : MonoBehaviour
{
    private bool isVibrating = false;
    private float elapsedTime = 0.0f;
    private float vibrationDuration = 0.5f; 
    private float amplitude = 0.1f; 
    private float frequency = 4.0f; 
    private float damp = 2.0f; 

    private Vector3 initialScale; 

    private void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Convert mouse position to world coordinates and check if it overlaps with the circle's collider
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.OverlapPoint(mousePosition) == gameObject.GetComponent<Collider2D>())
            {
                StartVibration();
            }
        }

        if (isVibrating)
        {
            UpdateVibration();
        }
    }

    private void StartVibration()
    {
        isVibrating = true;
        elapsedTime = 0.0f;
        transform.localScale = initialScale; 
        GameManager.AddMoney();
        print(GameManager.Money);
    }

    private void UpdateVibration()
    {
        elapsedTime += Time.deltaTime;

        float normalizedTime = elapsedTime / vibrationDuration;
        if (normalizedTime > 1.0f)
        {
            isVibrating = false;
            transform.localScale = initialScale;
            return;
        }

        float dampedSine = 1.0f + Mathf.Sin(normalizedTime * Mathf.PI * 2 * frequency) * amplitude * Mathf.Exp(-damp * normalizedTime);
        transform.localScale = initialScale * dampedSine;
    }
}
