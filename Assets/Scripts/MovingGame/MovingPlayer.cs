using System;
using UnityEngine;

public class MovingPlayer : Player
{
    public Vector2 velocity;
    public float cooldown;
    public bool onCooldown;

    public override void UpdatePlayer()
    {
        if (onCooldown)
        {
            ReduceCooldown();
        }
    }

    public void MoveTowardsTarget()
    {
        if(Math.Abs(Vector2.Distance(targetPosition, rb2D.position)) > Constants.MinMoveDistance)
        {
            velocity = (targetPosition - rb2D.position).normalized * playerSpeed;
            if(Math.Abs(Vector2.Distance(targetPosition, rb2D.position)) > Math.Abs(Vector2.Distance(rb2D.position + velocity * Time.deltaTime, rb2D.position)))
            {
                rb2D.MovePosition(rb2D.position + velocity * Time.deltaTime);
            }
            else
            {
                rb2D.MovePosition(targetPosition);
            }
        }
    }

    public void ReduceCooldown()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                onCooldown = false;
                cooldown = 0;
                playerSpeed = defaultSpeed;
            }
        }
    }

    public void ReduceSpeed(float percent, float seconds)
    {
        playerSpeed -= playerSpeed * percent;
        onCooldown = true;
        cooldown = seconds;
    }

    public void IncreaseSpeed(float percent, float seconds)
    {
        playerSpeed += playerSpeed * percent;
        onCooldown = true;
        cooldown = seconds;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PickupPoint")
        {
            GameController.Instance.play.score.IncreaseScore();
            Destroy(other.gameObject);
        }
        else if(other.tag == "PickupSlowdown")
        {
            Transform parent = other.transform.parent;
            ReduceSpeed(parent.gameObject.GetComponent<Pickup>().speedReductionPercent, parent.gameObject.GetComponent<Pickup>().reductionTimeSeconds);
            Destroy(parent.gameObject);
        }
        
    }
}
