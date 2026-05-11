using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(
    fileName = "OreData",
    menuName = "Game/Ore Data"
)]
public class OreData : ScriptableObject
{
    [Header("기본 정보")]
    public string oreName;

    public Sprite icon;

    [Header("경제")]
    public int sellPrice;

    [Header("등장 조건")]
    public int minDepth;

    public int maxDepth;

    [Range(0f, 1f)]
    public float spawnChance;

    [Header("광물 설정")]
    public int hardness;

    [Header("타일")]
    public TileBase oreTile;
}