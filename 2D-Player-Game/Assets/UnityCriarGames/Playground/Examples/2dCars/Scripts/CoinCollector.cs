using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text coinLabel;
    [SerializeField] private AudioClip coinCollect;
    [SerializeField] private AudioClip coisMasterCollect;
    private int coin = 0;
    private int coinMaster = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            AudioSource.PlayClipAtPoint(coinCollect, transform.position);
            Debug.Log("Player collected a coin.");
            coin++;
            Debug.Log("Coin received: " + coin);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("CoinMaster"))
        {
            AudioSource.PlayClipAtPoint(coisMasterCollect, transform.position);
            Debug.Log("Player collected a coin master.");
            coinMaster += 20; // Soma 20 a coinMaster
            Debug.Log("Coin Master received: " + coinMaster);
            Destroy(other.gameObject);
        }

        // Atualize o texto de coinLabel para mostrar a soma de coin e coinMaster
        coinLabel.text = (coin + coinMaster).ToString();
    }
}

