using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]    private GameObject panelEndGame;
    GameObject player;
    [SerializeField] private AudioClip endGame;
    [SerializeField] private GameObject pedalsCar;
    private void Start()
    {
        panelEndGame.SetActive(false);
        pedalsCar.SetActive(true);
    }

    private void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            panelEndGame.SetActive(true);
            pedalsCar.SetActive(false);
        }
        AudioSource.PlayClipAtPoint(endGame, transform.position);
    }
}