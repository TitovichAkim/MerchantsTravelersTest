using UnityEngine;

public class ProductBase : MonoBehaviour
{
    public GameSaver gameSaver;
    public ProductScrObj[] productSOBase;
    public SlotManager[] productSlots; // —сылки на каждый слот с товаром
    private int[] _productCost = {0, 0, 0};
    [SerializeField]private int[] _numberByClick = {0, 0, 0};

    private int[] _productLevels = {1, 1, 1};

    private void Start ()
    {
        LoadProductLvls();
    }
    public void LoadProductLvls ()
    {
        for(int i = 0; i < _productLevels.Length; i++)
        {
            _productLevels[i] = PlayerPrefs.GetInt($"productLVL{i}");
        }
    }
    public void UpdateSlots ()
    {
        foreach(SlotManager prodSlot in productSlots)
        {
            prodSlot.UpdateSlot();
            gameSaver.SaveGame();
        }
    }

    public int[] productLevels
    {
        get
        {
            return (_productLevels);
        }
        set
        {
            _productLevels = value;
        }
    }
    public int[] productCost
    {
        get
        {
            return (_productCost);
        }
        set
        {
            _productCost = value;

        }
    }
    public int[] numberByClick
    {
        get
        {
            return (_numberByClick);
        }
        set
        {
            _numberByClick = value;
        }
    }
}
