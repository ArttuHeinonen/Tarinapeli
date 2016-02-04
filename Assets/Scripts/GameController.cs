using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject melon;
    public GameObject gameOverText;
    public GameObject resetButton;
    public Text timerText;

    public float timeLeft = 10;
    public float minSpawnTime, maxSpawnTime;
    private float maxWidth;

    void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float melonWidth = melon.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - melonWidth;
        UpdateTimerText();
        StartCoroutine(Spawn());
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            timeLeft = 0;
        }
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time left: " + Mathf.RoundToInt(timeLeft);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);
        while(timeLeft > 0){
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(melon, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
        yield return new WaitForSeconds(1f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(1f);
        resetButton.SetActive(true);
    }
}
