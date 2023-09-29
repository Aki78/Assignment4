using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquareMover : MonoBehaviour
{
    public float m = 1.0f; 
    public float c = 0.1f; 
    public float k = 1.0f;

    private Vector3 currentPosition;
    private Vector3 previousPosition;
    private Vector3 acceleration;

    private Vector3 equilibriumPosition = new Vector3(-50,-100,0);

    private void OnEnable()
    {
        EventManager.instance.MoveSquareEvent += SetEquilibriumPosition;
    }

    private void OnDisable()
    {
        EventManager.instance.MoveSquareEvent -= SetEquilibriumPosition;
    }

    private void Start()
    {
        currentPosition = transform.position;
        previousPosition = currentPosition;
    }

//    private void Update()
    private void FixedUpdate()
    {
        Vector3 displacementFromEquilibrium = currentPosition - equilibriumPosition;

        Vector3 dampingForce = c * (currentPosition - previousPosition) / Time.deltaTime;

        acceleration = (-k * displacementFromEquilibrium - dampingForce) / m;

        Vector3 newPosition = 2 * currentPosition - previousPosition + acceleration * Time.deltaTime * Time.deltaTime;

        previousPosition = currentPosition;
        currentPosition = newPosition;

        transform.position = currentPosition;
    }

    private void SetEquilibriumPosition(Vector3 newTarget)
    {
        equilibriumPosition = newTarget;
    }

}
