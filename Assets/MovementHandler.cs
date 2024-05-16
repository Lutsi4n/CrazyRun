using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public InputHandler inputHandler;
    [SerializeField] private float speed;

    private void Start()
    {
        if (inputHandler == null) Debug.LogError("input handler не назначен");

    }

    private void MoveBall()
    {
        if (inputHandler.isThereTouchOnScreen())
        {
            Vector2 currDeltaPos = inputHandler.GetTouchDeltaPosition();
            currDeltaPos = currDeltaPos * speed;
            Vector3 newGravityVector = new Vector3(currDeltaPos.x, Physics.gravity.y, currDeltaPos.y);
            Physics.gravity = newGravityVector;
        }
    }

    private void Update()
    {
        MoveBall();
    }
}
