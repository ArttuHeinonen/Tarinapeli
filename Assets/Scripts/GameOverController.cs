using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public bool waitForAnimation;

    void Start () {
        waitForAnimation = false;
    }

    public void UpdateGameOver()
    {
        if (!waitForAnimation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GameController.Instance.IsDialogFinished())
                {
                    GameController.Instance.ToggleEndGameButtons(true);
                }
                else
                {
                    switch (SceneManager.GetActiveScene().name)
                    {
                        case "MelonScene":
                            MelonAfterScene();
                            break;
                        case "UnderwaterScene":
                            UnderwaterAfterScene();
                            break;
                    }
                }
            }
        }
    }

    public void MelonAfterScene()
    {
        GameController.Instance.canvasEnd.GetComponentInChildren<Text>().text = "";
        GrannyController.Instance.AnimateFalling();
        PlayerController.Instance.ChangeSpriteToShocked();
        GameController.Instance.HideDialog();
        GameController.Instance.MoveNextDialog();
    }

    public void UnderwaterAfterScene()
    {
        GameController.Instance.canvasEnd.GetComponentInChildren<Text>().text = "";
        Straw.Instance.AnimateSucking();
        GameController.Instance.MoveNextDialog();
    }
    
}
