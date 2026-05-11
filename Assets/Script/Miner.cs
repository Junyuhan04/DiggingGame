using UnityEngine;

public class Miner : MonoBehaviour
{
    public OreDatabase oreDatabase;

    public Inventory inventory;

    // ÇöÀç Ã¤±¼ ±íÀÌ
    public int currentDepth = 0;

    // Ã¤±¼ ¼Óµµ
    public float mineDelay = 1f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= mineDelay)
        {
            timer = 0f;

            Mine();
        }
    }

    void Mine()
    {
        OreData ore =
            oreDatabase.GetRandomOre(
                currentDepth
            );

        // ±¤¹° È¹µæ ¼º°ø
        if (ore != null)
        {
            inventory.AddOre(ore);

            Debug.Log(
                gameObject.name +
                " Ã¤±¼ : " +
                ore.oreName
            );
        }
        else
        {
            Debug.Log(gameObject.name + " Èë¸¸ Äº´Ù");
        }
    }
}