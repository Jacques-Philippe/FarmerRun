using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetBackgroundPosition : MonoBehaviour
{
    private Vector3 startingPosition;
    private float resetDistance;

    // Start is called before the first frame update
    void Start()
    {
        this.startingPosition = this.transform.position;
        this.resetDistance = this.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = this.transform.position;
        float distanceFromStart = (currentPosition - startingPosition).magnitude;
        bool isBeyondResetDistance = distanceFromStart >= resetDistance;
        if (isBeyondResetDistance) Reset();
    }

    private void Reset()
    {
        this.transform.position = startingPosition;
    }
}
