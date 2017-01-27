using UnityEngine;
using System.Collections;

public class SpacePlayerAnimation : MonoBehaviour {

    public void StartWaitForAnimation()
    {
        SpaceGameController.Instance.ToggelWaitForAnimation(true);
    }

    public void EndWaitForAnimation()
    {
        SpaceGameController.Instance.ToggelWaitForAnimation(false);
    }

    public void InBlackHole()
    {
        SpaceScreenController.Instance.EnterTheBlackHole();
        EndWaitForAnimation();
    }
}
