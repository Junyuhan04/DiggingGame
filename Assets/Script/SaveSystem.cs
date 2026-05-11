using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public Inventory inventory;

    public CurrencySystem currencySystem;

    public DigSystem digSystem;

    public OreDatabase oreDatabase;

    //-----------------------------------
    // 저장
    //-----------------------------------

    public void SaveGame()
    {
        // 골드 저장
        PlayerPrefs.SetInt(
            "Gold",
            currencySystem.gold
        );

        // 깊이 저장
        PlayerPrefs.SetInt(
       "Depth",
       digSystem.currentDepth
   );

        PlayerPrefs.SetFloat(
            "CurrentAmount",
            digSystem.currentAmount
        );

        // 광물 저장
        foreach (OreData ore in oreDatabase.ores)
        {
            int count =
                inventory.GetOreCount(ore);

            PlayerPrefs.SetInt(
                ore.oreName,
                count
            );
        }

        PlayerPrefs.Save();

        Debug.Log("게임 저장 완료");
    }

    //-----------------------------------
    // 불러오기
    //-----------------------------------

    public void LoadGame()
    {
        // 골드 불러오기
        currencySystem.gold = PlayerPrefs.GetInt("Gold", 0);
        
        // 깊이 불러오기
        digSystem.currentDepth = PlayerPrefs.GetInt("Depth", 0);

        digSystem.currentAmount = PlayerPrefs.GetFloat("CurrentAmount", 0f);

        // 광물 불러오기
        foreach (OreData ore in oreDatabase.ores)
        {
            int count =
                PlayerPrefs.GetInt(
                    ore.oreName,
                    0
                );

            if (count > 0)
            {
                inventory.SetOreCount(ore, count);
            }
        }

        Debug.Log("게임 불러오기 완료");
    }

    //-----------------------------------
    // 자동 저장
    //-----------------------------------

    void OnApplicationQuit()
    {
        SaveGame();
    }
}