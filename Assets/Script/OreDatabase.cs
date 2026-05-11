using System.Collections.Generic;
using UnityEngine;

public class OreDatabase : MonoBehaviour
{
    public OreData[] ores;

    public OreData GetRandomOre(int depth)
    {
        List<OreData> possibleOres =
            new List<OreData>();

        // 현재 깊이에서 등장 가능한 광물 찾기
        foreach (OreData ore in ores)
        {
            if (depth >= ore.minDepth &&
                depth <= ore.maxDepth)
            {
                possibleOres.Add(ore);
            }
        }

        // 확률 계산
        foreach (OreData ore in possibleOres)
        {
            if (Random.value <= ore.spawnChance)
            {
                return ore;
            }
        }

        return null;
    }
}