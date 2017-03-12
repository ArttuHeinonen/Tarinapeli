using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    [Range(0, 1)]
    public float speedReductionPercent;

    public float reductionTimeSeconds;
}
