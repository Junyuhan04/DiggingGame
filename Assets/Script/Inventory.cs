using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<OreData, int> ores
        = new Dictionary<OreData, int>();

    //-----------------------------------
    // ±¤¹° Ãß°¡
    //-----------------------------------

    public void AddOre(OreData ore)
    {
        if (ores.ContainsKey(ore))
        {
            ores[ore]++;
        }
        else
        {
            ores.Add(ore, 1);
        }

        Debug.Log(
            ore.oreName +
            " È¹µæ! ÇöÀç °³¼ö : " +
            ores[ore]
        );
    }

    //-----------------------------------
    // ±¤¹° °³¼ö °¡Á®¿À±â
    //-----------------------------------

    public int GetOreCount(OreData ore)
    {
        if (ores.ContainsKey(ore))
        {
            return ores[ore];
        }

        return 0;
    }

    //-----------------------------------
    // ±¤¹° °³¼ö ¼³Á¤
    //-----------------------------------

    public void SetOreCount(
        OreData ore,
        int amount
    )
    {
        if (ores.ContainsKey(ore))
        {
            ores[ore] = amount;
        }
        else
        {
            ores.Add(ore, amount);
        }
    }

    //-----------------------------------
    // ±¤¹° Á¦°Å
    //-----------------------------------

    public void RemoveOre(
        OreData ore,
        int amount
    )
    {
        if (!ores.ContainsKey(ore))
            return;

        ores[ore] -= amount;

        if (ores[ore] <= 0)
        {
            ores.Remove(ore);
        }
    }
}