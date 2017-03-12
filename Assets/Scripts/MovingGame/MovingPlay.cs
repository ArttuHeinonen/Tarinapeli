using System;
using UnityEngine;
using UnityEngine.UI;

public class MovingPlay : Play {

    public GameObject pickups;
    public Vector3 rawPosition;
    public RepositionColliders walls;

    public override void ActivateMusic()
    {
        
    }

    public override void ActivateSpawn()
    {
        for (int i = 0; i < pickups.transform.childCount; i++)
        {
            pickups.transform.GetChild(i).GetComponent<MoveObject>().isMoving = true;
            pickups.transform.GetChild(i).transform.GetChild(0).GetComponent<Rotate>().isRotating = true;
        }
        ActivateWalls();
    }

    public void ActivateWalls()
    {
        walls.ActivateWalls();
    }

    public override void UpdatePlay()
    {
        UpdatePlayer();
        if(timer != null)
        {
            UpdateTimer();
        }
    }

    public override void ResetValues()
    {
        ResetTime();
        score.ResetScore();
    }

    public void UpdatePlayer()
    {
        player.GetComponent<MovingPlayer>().UpdatePlayer();
        if (Input.GetMouseButton(0))
        {
            if (canControl)
            {
                rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
                rawPosition = new Vector3(Mathf.Clamp(rawPosition.x, -screenWidth, screenWidth), Mathf.Clamp(rawPosition.y, -screenHeight, screenHeight), 0f);
                player.GetComponent<MovingPlayer>().targetPosition = rawPosition;

                player.GetComponent<MovingPlayer>().MoveTowardsTarget();

            }
            else if(isOnCooldown)
            {
                ReduceCooldown();
            }
        }
        
    }
}
