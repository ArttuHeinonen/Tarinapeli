using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util {


    public static IEnumerator LerpPositionToPoint(GameObject go, Vector3 end, float duration, float animationSpeed)
    {
        float startTime = Time.time;
        float frac;
        while(Mathf.Abs(Vector3.Distance(go.transform.position, end)) > 0.02f)
        {
            float covered = (Time.time - startTime) * animationSpeed;
            frac = covered / duration;
            go.transform.position = Vector3.Lerp(go.transform.position, end, frac);
            yield return new WaitForEndOfFrame();
        }
        go.transform.position = end;
    }

    public static IEnumerator LerpScaleToPoint(GameObject go, Vector3 end, float duration, float animationSpeed)
    {
        float startTime = Time.time;
        float frac;
        while (Mathf.Abs(Vector3.Distance(go.transform.localScale, end)) > 0.02f)
        {
            float covered = (Time.time - startTime) * animationSpeed;
            frac = covered / duration;
            go.transform.localScale = Vector3.Lerp(go.transform.localScale, end, frac);
            yield return new WaitForEndOfFrame();
        }
        go.transform.localScale = end;
    }


}
