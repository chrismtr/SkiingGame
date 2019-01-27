using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject[] Source;
    public float SourceLength;
    public float SourceOffset;
    public float HorizontalMargins;
    public float VerticalMargins;

    private float limit;

    private void Start()
    {
        limit = GetXLimit();
        GenerateBackground(PlayerData.player.levelCount);
        PlayerData.player.totalHeight = GetTotalHeight();
    }

    private float GetXLimit()
    {
        return Camera.main.orthographicSize / 2 - HorizontalMargins;
    }

    private void GenerateBackground(int coefficient)
    {
        for (int i = 0; i < SourceLength * coefficient; ++i)
        {
            Vector2 position = new Vector2(Random.Range(-limit, limit), (i + VerticalMargins) * -SourceOffset);
            InstantiateGameObject(Source[Random.Range(0, Source.Length)], position);
        }
    }
    
    private void InstantiateGameObject(GameObject source, Vector2 position)
    {
        GameObject obj = Instantiate(source) as GameObject;
        obj.transform.position = position;
        obj.transform.parent = transform;
    }

    private float GetTotalHeight()
    {
        return -gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position.y;
    }
}
