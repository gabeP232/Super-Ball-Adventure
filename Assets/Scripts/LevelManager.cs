using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    [Header("Level Goals")]
    public int coinsRequired = 0;
    public int buttonsRequired = 0; // 0 - Disabled, 1 - 1 button press needed

    [Header("Level Completion")]
    public TextMeshProUGUI winText;

    private int coinsCollected = 0;
    private int buttonsPressed = 0;

    private bool levelComplete = false;

    private void Awake() {
        Instance = this;
    }

    public void addCoin(int add) {
        coinsCollected = coinsCollected + add;

        Debug.Log("LevelManager -- Coin Picked Up");
        checkWin();
    }

    public void addButtonPress() {
        buttonsPressed++;
        checkWin();
    }

    public void removeButtonPress() {
        buttonsPressed--;
        checkWin();
    }

    private void checkWin() {
        if (levelComplete) {
            return;
        }

        bool coinsSatisfied = coinsCollected >= coinsRequired;
        bool buttonsSatisfied = buttonsRequired == 0 || buttonsPressed >= buttonsRequired;

        if (coinsSatisfied && buttonsSatisfied) {
            levelComplete = true;
            Debug.Log("Level complete");
            Debug.Log(winText);
            if (winText != null) {
                Debug.Log("TEXT");
                winText.gameObject.SetActive(true);
                winText.enabled = true;
            }
        }
    }
}
