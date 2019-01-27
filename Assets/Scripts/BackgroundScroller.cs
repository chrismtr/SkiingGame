using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float Speed;

    private void Update ()
    {
        if (PlayerData.player.isGameStarted)
        {
            if (PlayerData.player.isGameOver == false
                && transform.position.y < PlayerData.player.totalHeight)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + Speed);
            }
            else if (PlayerData.player.isGameOver == false)
            {
                EventManager.TriggerEvent("LevelPassed");
            }
        }
    }
}
