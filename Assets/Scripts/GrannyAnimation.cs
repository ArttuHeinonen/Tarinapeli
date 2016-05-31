using UnityEngine;
using System.Collections;

public class GrannyAnimation : MonoBehaviour {

	public IEnumerator HitGround()
    {
        PlayerController.Instance.ChangeSpriteToSquashed();
        SoundManager.Instance.PlaySplat();
        yield return new WaitForSeconds(1.5f);
        GameController.Instance.GoToCutScene();
        GameController.Instance.ShowDialog();
        GameController.Instance.ToggleEndGameButtons(true);
    }
}
