using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{   
    Vector3 StartingPosition;
    [SerializeField] Vector3 Movementvector;
    float MovementFactor;
    [SerializeField] float period = 2f;


    void Start()
    {
        StartingPosition = transform.position;

    }

    void Update()
    {
        if (period <= Mathf.Epsilon) {return; }
        float cycles= Time.time / period;  // Continually growing over ime
        const float tau = Mathf.PI * 2; // constant value of 6.283

        float rawSinWave = Mathf.Sin(cycles * tau); //going from -1 to 1

        MovementFactor = (rawSinWave + 1f) / 2f; // Recalculated to go from 0 to 1 so its cleaner

        Vector3 offset = Movementvector * MovementFactor;
        transform.position = StartingPosition + offset;
    }
}
