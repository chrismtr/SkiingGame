using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float FilterFactor;
    public float GravityScale;
    public string ColliderTagName;

    private void OnEnable()
    {
        EventManager.StartListening("GameOver", StopPlayer);
    }

    private void Update ()
    {
        if (PlayerData.player.isGameOver == false && PlayerData.player.isLevelPassed == false)
        {
            Move();
        }
        else if (PlayerData.player.isLevelPassed == true)
        {
            EventManager.TriggerEvent("LevelUp");
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(ColliderTagName))
        {
            EventManager.TriggerEvent("GameOver");
        }
    }

    private void Move()
    {
        transform.position = new Vector3(FilterAcceleration().x, transform.position.y, transform.position.z);
    }

    private Vector3 FilterAcceleration()
    { 
        return Vector3.Lerp(transform.position, FilterFactor * Input.acceleration, Time.deltaTime);
    }

    private void StopPlayer()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void StartPlayer()
    {
        GetComponent<Rigidbody2D>().gravityScale = GravityScale;
    }
}