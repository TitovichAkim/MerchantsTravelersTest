using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager:MonoBehaviour
{

    public ProductBase productBase;


    [SerializeField] private Text _lvlText;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _costText;
    [SerializeField] private Text _numberByClickText;
    [SerializeField] private Text _lvlUpButtonText;
    [SerializeField] private Image _iconImage;
    private ProductScrObj _productSO;
    private PlayerInventory _playerInventory;
    private int _productLVL;
    private int _slotNumber;

    private void Start ()
    {
        _playerInventory = productBase.gameObject.GetComponent<PlayerInventory>();
        GetTheSlotIndex();
        _productSO = productBase.productSOBase[_slotNumber];
        UpdateSlot();
        productBase.productCost[_slotNumber] = _productLVL * _productSO.productCost;
        productBase.numberByClick[_slotNumber] = 1 + (_productLVL / 5);
    }
    public void GetTheSlotIndex ()
    {
        for(int i = 0; i < productBase.productLevels.Length; i++)
        {
            if(productBase.productSlots[i] == this)
            {
                _slotNumber = i;
                break;
            }
        }
    }
    public void UpdateSlot ()
    {
        _productLVL = productBase.productLevels[_slotNumber];
        _lvlText.text = $"LVL {_productLVL}";
        _nameText.text = $"{_productSO.productName}";
        _costText.text = $"{_productSO.productCost * _productLVL} -> {_productSO.productCost * (_productLVL + 1)}";

        if ((_productLVL + 1)%5 == 0)
        {
            _numberByClickText.text = $"{1 + (_productLVL / 5)} -> {1 + ((_productLVL+1) / 5)}";
        }
        else
        {
            _numberByClickText.text = $"{1 + (_productLVL / 5)}";
        }

        _lvlUpButtonText.text = $"Улучшить\n{_productSO.productCost * _productLVL}$";
        _iconImage.GetComponent<Image>().sprite = _productSO.productIcon;

        // И тут же изменим значение в базе
        productBase.productCost[_slotNumber] = _productLVL * _productSO.productCost;
        productBase.numberByClick[_slotNumber] = 1 + (_productLVL / 5);
    }

    public void ProductLvlUp ()
    {
        if(_playerInventory.coins >= _productSO.productCost * _productLVL)
        {
            _playerInventory.coins -= _productSO.productCost * _productLVL;
            productBase.productLevels[_slotNumber]++;
            productBase.UpdateSlots();
        }
    }
}
