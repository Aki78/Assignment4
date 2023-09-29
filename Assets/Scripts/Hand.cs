using UnityEngine;

public class OscillateMeTowards : MonoBehaviour
{
    public float frequency = 1.0f;
    public float amplitude = 1.0f;

    private Vector2 startPosition;
    private Vector2 directionToTarget;
    private Vector2 targetPosition = new Vector2(0, 0);

    private float angleCenter; 

    void Start()
    {
        startPosition = transform.position;
        directionToTarget = (targetPosition - startPosition);

        Vector2 A = new Vector2(1,0);
        Vector2 B = new Vector2(0,0);
        Vector2 C = new Vector2(transform.position.x, transform.position.y);

        float angle = MyGeo.AngleBetweenThreePoints(A, B, C);
        print(angle);
        print(gameObject.name);
        transform.eulerAngles = new Vector3(0,0,(angle - 90));
    }

    void Update()
    {
        float displacementAmount = Mathf.Sin(Time.time * frequency) * amplitude;
        Vector2 displacement = directionToTarget * displacementAmount;
        transform.position = startPosition + displacement;
    }
}
