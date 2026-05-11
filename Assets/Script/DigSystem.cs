using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;

public class DigSystem : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text percentText;
    public TMP_Text depthText;

    [Header("Dig Setting")]
    public float digSpeed = 10f;
    private float requiredAmount = 100f;
    public float increaseRate = 1.15f;

    [Header("Tilemap Setting")]
    public Tilemap groundTilemap;
    public TileBase emptyTile;
    public float kmHeight = 16f;

    public float currentAmount = 0f;
    public int currentDepth = 0;

    void Update()
    {
        Dig();
        UpdateUI();
    }

    void Dig()
    {
        currentAmount += digSpeed * Time.deltaTime;

        if (currentAmount >= requiredAmount)
        {
            NextKM();
        }
    }

    void NextKM()
    {
        // 진행도 초기화
        currentAmount -= requiredAmount;

        // 점점 느려짐
        requiredAmount *= increaseRate;

        BoundsInt bounds = groundTilemap.cellBounds;

        int minX = bounds.xMin;
        int maxX = bounds.xMax;

        // 오른쪽 6칸 시작
        int startX = maxX - 6;

        // 현재 층의 "천장 줄"
        int ceilingY = bounds.yMax - 1 - (currentDepth * 4);

        // 천장 줄의 오른쪽 6칸 삭제
        for (int x = startX; x < maxX; x++)
        {
            Vector3Int pos = new Vector3Int(x, ceilingY, 0);

            groundTilemap.SetTile(pos, null);
        }

        // 천장 아래 3줄 전체 삭제
        for (int y = 1; y <= 3; y++)
        {
            for (int x = minX; x < maxX; x++)
            {
                Vector3Int pos = new Vector3Int(x, ceilingY - y, 0);

                groundTilemap.SetTile(pos, null);
            }
        }

        currentDepth++;
    }

    void UpdateUI()
    {
        float percent = (currentAmount / requiredAmount) * 100f;

        percent = Mathf.Clamp(percent, 0f, 100f);

        percentText.text = percent.ToString("F2") + "%";

        depthText.text = currentDepth + " KM";
    }
}