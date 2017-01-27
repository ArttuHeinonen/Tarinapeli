using UnityEngine;
using System.Collections;

public class SpaceGameOverController : MonoBehaviour {

    public bool waitForAnimation;

    void Start()
    {
        waitForAnimation = false;
    }

    public void UpdateGameOver () {
        if (!waitForAnimation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (SpaceGameController.Instance.IsDialogFinished())
                {
                    SpaceGameController.Instance.ToggleEndGameButtons(true);
                }
                else
                {
                    //show cutscene
                }
            }
        }
	}
}
