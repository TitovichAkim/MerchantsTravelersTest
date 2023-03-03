using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver: MonoBehaviour
{
    public TownsManager townsManager;
    public ProductBase productBase;
    public PlayerInventory playerInventory;

    public void SaveGame ()
    {
        SaveTownLvls();
        SaveProductLvls();
        PlayerPrefs.SetInt("Coins", playerInventory.coins);
    }
    private void SaveTownLvls ()
    {
        for(int i = 0; i < townsManager.locationsLVL.Length; i++)
        {
            PlayerPrefs.SetInt($"locationsLVL{i}", townsManager.locationsLVL[i]);
        }
    }

    private void SaveProductLvls ()
    {
        for(int i = 0; i < productBase.productLevels.Length; i++)
        {
            PlayerPrefs.SetInt($"productLVL{i}", productBase.productLevels[i]);
        }
    }
}
