using System;
using UnityEngine;

public class MovingPlayer : Player
{
    public Vector2 velocity;

    public override void UpdatePlayer()
    {

    }

    public void MoveTowardsTarget()
    {
        if(Math.Abs(Vector2.Distance(targetPosition, rb2D.position)) > Constants.MinMoveDistance)
        {
            velocity = (targetPosition - rb2D.position).normalized * playerSpeed;
            Debug.Log(velocity);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.name == "Melon")
        {
            GameController.Instance.play.score.IncreaseScore();
            Destroy(other.gameObject);
        }
        else
        {
            
        }
        
    }
}
