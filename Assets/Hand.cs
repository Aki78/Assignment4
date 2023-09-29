using UnityEngine;

public class OscillateInDirection : MonoBehaviour
{
    public float frequency = 1.0f;

    public float amplitude = 1.0f;

    private Vector2 startPos;
    private Vector2 directionToTarget;
    private Vector2 targetPosition = new Vector2(0, 0);

    void Start()
    {
        startPos = transform.position;
        directionToTarget = (targetPosition-startPos).normalized;
    }

    void Update()
    {
        float displacementAmount = Mathf.Sin(Time.time*frequency)*amplitude;
        Vector2 displacement = directionToTarget*displacementAmount;
        transform.position = startPos+displacement;
    }
}
