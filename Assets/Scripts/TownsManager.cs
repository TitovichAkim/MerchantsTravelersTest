using UnityEngine;
using UnityEngine.UI;

public class TownsManager : MonoBehaviour
{
    public GameSaver gameSaver;
    public Image currentProductIcon;
    public Image progressBar;
    public Text progressText;

    private ProductBase _productBase;
    private PlayerInventory playerInventory;
    private int[] _locationsLVL = {1, 1, 1};
    private int[] _currentDemand = {10, 10, 10};

    private int _townIndex = 0;
    private int _demandForLocation;
    private int _productIndex;


    private void Start ()
    {
        LoadTownLvls();
        _productBase = GetComponent<ProductBase>();
        playerInventory = GetComponent<PlayerInventory>();
        _productIndex = Random.Range(0, _currentDemand.Length);
        _demandForLocation = _currentDemand[_townIndex] * _locationsLVL[_townIndex];
        currentProductIcon.sprite = _productBase.productSOBase[_productIndex].productIcon;
        UpdateProductBar();
    }

    public void LoadTownLvls ()
    {
        for(int i = 0; i < locationsLVL.Length; i++)
        {
            locationsLVL[i] = PlayerPrefs.GetInt($"locationsLVL{i}");
        }
    }
    public void SellTheProduct ()
    {
        if (_demandForLocation >= _productBase.numberByClick[_productIndex])
        {
            _demandForLocation -= _productBase.numberByClick[_productIndex];
            playerInventory.coins += _productBase.productCost[_productIndex] * _productBase.numberByClick[_productIndex];
        } 
        else
        {
            playerInventory.coins += _productBase.productCost[_productIndex] * _demandForLocation;
            _demandForLocation = 0;
        }
        if (_demandForLocation == 0)
        {
            NextTown();
        }
        UpdateProductBar();
        gameSaver.SaveGame();
    }

    private void NextTown ()
    {
        locationsLVL[_townIndex]++;
        _townIndex++;
        if (_townIndex >= locationsLVL.Length)
        {
            _townIndex = 0;
        }
        _productIndex = Random.Range(0, _currentDemand.Length);
        _demandForLocation = _currentDemand[_townIndex] * locationsLVL[_townIndex];
        currentProductIcon.sprite = _productBase.productSOBase[_productIndex].productIcon;

    }

    private void UpdateProductBar ()
    {
        progressBar.GetComponent<Image>().fillAmount = 1f - (float)_demandForLocation / (_currentDemand[_townIndex] * locationsLVL[_townIndex]);
        progressText.text = _demandForLocation.ToString();
    }

    public int[] locationsLVL
    {
        get
        {
            return (_locationsLVL);
        }
        set
        {
            _locationsLVL = value;
        }
    }
}
