using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuellController : MonoBehaviour
{
    [SerializeField] private Image imageFuellSlider;
    private float fullGas = 1f;
    private bool isSuperGasActive = false;
    private float superGasDuration;

    [SerializeField] private PickupController pickupController;
    [SerializeField] private GameObject superGasolineIcon;
    [SerializeField] private GameObject GasolineIcon;

    [SerializeField] private AudioClip superGasolineCollect;
    [SerializeField] private AudioClip GasolineCollect;
    private void Start()
    {
        // Inicialize a duração da "Super Gasolina" aqui.
        superGasDuration = 5f;
        superGasolineIcon.SetActive(false);
        GasolineIcon.SetActive(true);
    }

    private void Update()
    {
        // Verifique se a "Super Gasolina" está ativa.
        if (isSuperGasActive)
        {
            // Defina o preenchimento como "fullGas" enquanto a "Super Gasolina" estiver ativa.
            imageFuellSlider.fillAmount = fullGas;

            // Reduza o tempo restante da "Super Gasolina".
            superGasDuration -= Time.deltaTime;

            Debug.Log("Tempo super gasolina: " + superGasDuration);

            if (superGasDuration <= 0)
            {
                // A "Super Gasolina" acabou, então desative-a.
                isSuperGasActive = false;

                // Volte a preencher a gasolina normalmente.
                imageFuellSlider.fillAmount = 0;
                pickupController.gasConsumer = 0.1f;
                superGasolineIcon.SetActive(false);
                GasolineIcon.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gas"))
        {
            Debug.Log("Capturou a Gasolina");
            imageFuellSlider.fillAmount = fullGas;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(GasolineCollect, transform.position);
        }

        if (other.CompareTag("SuperGas"))
        {
            Debug.Log("Capturou a Super Gasolina");
            isSuperGasActive = true; // Ativa a "Super Gasolina".
            pickupController.gasConsumer = 0f; // Define o consumo de gasolina como 0.
            
            // Desative o GameObject da "Super Gasolina".
            other.gameObject.SetActive(false);
            superGasolineIcon.SetActive(true);
            GasolineIcon.SetActive(false);
            AudioSource.PlayClipAtPoint(superGasolineCollect, transform.position);
            
            // Configure o tempo de duração da "Super Gasolina" (tempo de atividade).
            superGasDuration = 5f; // Define a duração da "Super Gasolina" para 5 segundos.
        }
    }
}
