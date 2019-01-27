using UnityEngine;

public class PopupHandler : MonoBehaviour
{
    public GameObject[] Popups;

    private void Start()
    {
        if (!PlayerData.player.isGameStarted)
        {
            Popups[1].SetActive(true);
        }
    }

    private void OnEnable()
    {
        EventManager.StartListening("GameOver", ShowPopup);
    }

    public void HidePopup(int index)
    {
        Popups[index].gameObject.SetActive(false);
    }

    public void ShowPopup()
    {
        Popups[0].gameObject.SetActive(true);
    }
}