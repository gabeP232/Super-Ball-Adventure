using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    [Header("Level Goals")]
    public int coinsRequired = 0;
    public int buttonsRequired = 0; // 0 - Disabled, 1 - 1 button press needed


    [Header("HUD Elements")]
    public TextMeshProUGUI winText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI coinText;
    public Button playAgain;

    private int coinsCollected = 0;
    private int buttonsPressed = 0;

    private bool levelComplete = false;

    private void Awake() {
        Instance = this;

        if (coinText != null) {
            updateCoinUI();
        }
    }

    public void addCoin(int add) {
        coinsCollected = coinsCollected + add;

        //Debug.Log("LevelManager -- Coin Picked Up");
        updateCoinUI();
    }
    
    private void updateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinsCollected + " / " + coinsRequired;
        }
    }


    public void addButtonPress() {
        buttonsPressed++;
    }

    public void removeButtonPress() {
        buttonsPressed--;
    }

    public void PlayerEnteredWinArea() {
        Debug.Log("Player entered win area");
        if (levelComplete) return;
        TriggerWin();

    }

    private void TriggerWin()
    {
        levelComplete = true;

        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.enabled = true;
        }
    }

    public void PlayerDied() {
        Debug.Log("Player died");

        if (playAgain != null) {
            playAgain.gameObject.SetActive(true);
            playAgain.enabled = true;
            deathText.gameObject.SetActive(true);
            deathText.enabled = true;
        }
    }
}
