﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    // todo remove from inspector later
    float movementFactor; // 0 for not moved, 1 for fully moved

    Vector3 startingPos;  // must be stored for absolute movement
    
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // set movementFactor automatically
        if (period <= Mathf.Epsilon) { return; } // protect against period is zero

        float cycles = Time.time / period;  // grows continually from 0

        const float tau = Mathf.PI * 2;  // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
