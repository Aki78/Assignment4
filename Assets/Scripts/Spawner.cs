using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject oscillatingObjectPrefab;
    public Vector2 spawnCenter = Vector2.zero;  
    public float spawnRadius = 5.0f;    
    public float spawnAngle = 0.0f;      
    public float radiusIncreaseAmount = 1000.0f;
    public float dTheta = 10.0f;

    private float totalAngleRotated = 0.0f;

    private float isNewSpawn = 0.0f;

    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space))
    {
        SpawnObjectAtAngle();
        
    } 
    }

    public void SpawnObjectAtAngle()
    {
        float radianAngle = (spawnAngle + 90) * Mathf.Deg2Rad;

        Vector2 spawnPosition = new Vector2(
            spawnCenter.x + spawnRadius * Mathf.Cos(radianAngle),
            spawnCenter.y + spawnRadius *Mathf.Sin(radianAngle)
        );

        Vector2 directionToCenter = (spawnCenter - spawnPosition).normalized;

        float rotationAngle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;

        GameObject hand = Instantiate(oscillatingObjectPrefab, spawnPosition, Quaternion.Euler(0, 0, rotationAngle));

        OscillateMeTowards oscillateComponent = hand.GetComponent<OscillateMeTowards>();

        spawnAngle = (spawnAngle - dTheta + 360.0f) % 360.0f;

        totalAngleRotated += dTheta;
        if (totalAngleRotated >= 360.0f)
        {
            totalAngleRotated -= 360.0f;
            spawnRadius += 1.5f * radiusIncreaseAmount;
            isNewSpawn = +1;
        }

        if ( isNewSpawn >= 1 ){
            oscillateComponent.frequency = 1.5f*isNewSpawn*oscillateComponent.frequency;
        }
    }
}
