using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public int gold;

    public void AddGold(int amount)
    {
        gold += amount;

        Debug.Log(
            "ÇöÀç °ñµå : " + gold
        );
    }
}