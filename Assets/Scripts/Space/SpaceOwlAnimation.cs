using UnityEngine;
using System.Collections;

public class SpaceOwlAnimation : MonoBehaviour {

	public void StopAnimation()
    {
        SpaceGameController.Instance.ToggelWaitForAnimation(false);
    }
	
}
