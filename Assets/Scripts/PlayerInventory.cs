using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory:MonoBehaviour
{
    public GameSaver gameSaver;
    public Text coinsText;
    private int _coins;

    private void Start ()
    {
        _coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = $"{_coins} $";
    }
    public int coins
    {
        get
        {
            return (_coins);
        }
        set
        {
            _coins = value;
            coinsText.text = $"{_coins} $";
            gameSaver.SaveGame();
        }
    }
}
