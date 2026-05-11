using UnityEngine;

public class OreTest : MonoBehaviour
{
    public OreDatabase oreDatabase;

    public int currentDepth = 300;

    void Start()
    {
        OreData ore =
            oreDatabase.GetRandomOre(currentDepth);

        if (ore != null)
        {
            Debug.Log(
                "µÓ¿Â ±§π∞ : " +
                ore.oreName
            );
        }
        else
        {
            Debug.Log("±§π∞ æ¯¿Ω");
        }
    }
}