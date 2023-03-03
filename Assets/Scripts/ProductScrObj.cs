using UnityEngine;

[CreateAssetMenu(fileName = "Product", menuName = "ScriptableObjects/Product")]
public class ProductScrObj : ScriptableObject
{
    public string productName;
    public int productCost;
    public int productLvlUpCost;
    public int numberByClick;
    public Sprite productIcon;
}
