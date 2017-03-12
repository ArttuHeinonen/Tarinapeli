using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateText : MonoBehaviour {

    public Vector3 defaultScale;
    public float scale = 1.3f;
    public float timeLimit = 1f;
    public float collectedTime = 0;

    private void Start()
    {
        defaultScale = this.transform.localScale;
    }

    public void ScaleTextUp()
    {
        this.transform.localScale = defaultScale * scale;
        StartCoroutine(Util.LerpScaleToPoint(this.gameObject, defaultScale, 0.25f, Constants.TextAnimationSpeed));
    }

    public bool IsSecondsPassed()
    {
        if(collectedTime > timeLimit)
        {
            collectedTime = 0;
            return true;
        }
        collectedTime += Time.deltaTime;

        return false;
    }

    public void ResetScale()
    {
        this.transform.localScale = defaultScale;
    }
}
