
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
        public static EventManager instance;

    public event Action<Vector3> MoveSquareEvent;

    private void Awake()
    {
        if (instance == null)
{            instance = this;
            print("instance is null");
}
        else
        {
            Destroy(gameObject);
            print("gameObject Destroyed");
}
    }

    public void TriggerMoveSquareEvent(Vector3 targetPosition)
    {
        MoveSquareEvent?.Invoke(targetPosition);
        print("move square triggered");
    }
}