using UnityEngine;

public static class MyGeo
{
    public static float AngleBetweenThreePoints(Vector2 A, Vector2 B, Vector2 C)
    {
        Vector2 BA = A - B; 
        Vector2 BC = C - B;

        float dotProduct = Vector2.Dot(BA.normalized, BC.normalized);

        float angleInRadians = Mathf.Acos(dotProduct);
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;

        // Calculate the cross product's z-component
        float crossZ = BA.x * BC.y - BA.y * BC.x;

        // If the cross product is negative, the angle is greater than 180°.
        if (crossZ < 0)
        {
            angleInDegrees = 360 - angleInDegrees;
        }

        return angleInDegrees;
    }
}
