using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    public Tilemap groundTilemap;

    public TileBase dirtTile;

    public OreDatabase oreDatabase;

    public int width = 16;
    public int height = 16;

    // ±§π∞ ¿˙¿Â
    public Dictionary<Vector3Int, OreData> oreMap
        = new Dictionary<Vector3Int, OreData>();

    public void Generate(int depth)
    {
        groundTilemap.ClearAllTiles();

        oreMap.Clear();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos =
                    new Vector3Int(x, y, 0);

                // »Î ª˝º∫
                groundTilemap.SetTile(
                    pos,
                    dirtTile
                );

                // 15% »Æ∑¸∑Œ ±§π∞ º˚±‚±‚
                if (Random.value < 0.15f)
                {
                    OreData ore =
                        oreDatabase.GetRandomOre(
                            depth + y
                        );

                    if (ore != null)
                    {
                        oreMap.Add(pos, ore);
                    }
                }
            }
        }
    }

    public OreData GetOre(Vector3Int pos)
    {
        if (oreMap.ContainsKey(pos))
        {
            return oreMap[pos];
        }

        return null;
    }
}