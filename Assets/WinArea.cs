using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            LevelManager.Instance.PlayerEnteredWinArea();
        }
    }

}
