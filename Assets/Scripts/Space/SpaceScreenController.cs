using UnityEngine;
using System.Collections;

public class SpaceScreenController : MonoBehaviour {

    public static SpaceScreenController Instance { get; private set; }

	void Start()
    {
        Instance = this;
    }

    public void EnterTheBlackHole()
    {

    }
}
