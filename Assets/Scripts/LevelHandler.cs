using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    private Text textObj; 

    private void Start()
    {
        textObj = gameObject.GetComponent<Text>();
        textObj.text = PlayerData.player.levelCount.ToString();
    }
    
    private void Update()
    {
       string playerLevelCount = PlayerData.player.levelCount.ToString();

       if (textObj.text != playerLevelCount)
        {
            textObj.text = playerLevelCount;
        }
    }
}
