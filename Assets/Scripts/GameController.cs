using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject melon;
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
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        //yield return new WaitForSeconds(1f);
        while(true){
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(melon, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }
}
