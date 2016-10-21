using UnityEngine;
using System.Collections;

public class StrawAnimation : MonoBehaviour {

	
    public IEnumerator StartSucking()
    {
        PusuController.Instance.Animate("GetSucked");
        yield return new WaitForSeconds(1.5f);
    }

    public IEnumerator Leave()
    {
        yield return new WaitForSeconds(1.5f);
        GameController.Instance.GoToCutScene();
        GameController.Instance.ShowDialog();
        GameController.Instance.ToggleEndGameButtons(true);
    }
}
