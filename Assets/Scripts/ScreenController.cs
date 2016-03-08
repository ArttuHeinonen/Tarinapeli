using UnityEngine;
using System.Collections;

public class ScreenController : MonoBehaviour {

    public static ScreenController Instance { get; private set; }

    public Sprite altBackground;
    private GameObject child;
    private SpriteRenderer sr;

	void Start () {
        Instance = this;
        sr = GetComponent<SpriteRenderer>();
        ResizeBackground();
    }

    public void SwapToAltBackground()
    {
        sr.sprite = altBackground;
        ResizeBackground();
    }

    void ResizeBackground()
    {
        if (sr == null)
        {
            return;
        }
        transform.localScale = new Vector3(1, 1, 1);
        float width = sr.bounds.size.x;
        float height = sr.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        transform.localScale = xWidth;

        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height;
        transform.localScale = yHeight;

        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 10));
    }

    public void HideChild()
    {
        if (this.gameObject.transform.GetChild(0) != null)
        {
            child = this.gameObject.transform.GetChild(0).gameObject;
            child.SetActive(false);
        }
        
    }
}
