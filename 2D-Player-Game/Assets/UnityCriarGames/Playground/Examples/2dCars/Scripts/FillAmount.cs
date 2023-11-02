using UnityEngine;
using UnityEngine.UI;

public class FillAmount : MonoBehaviour
{
    public Image fillImage;  // Refer�ncia � imagem preench�vel

    void Start()
    {
        // Obtenha a refer�ncia � imagem preench�vel
        fillImage = GetComponent<Image>();
    }

    void Update()
    {
        float fillSpeed = 0.2f;  // Taxa de preenchimento por segundo

        // Verifique se o preenchimento atual menor que 1 (100%)
        if (fillImage.fillAmount >= 0.1f)
        {
            // Aumente gradualmente o preenchimento
            fillImage.fillAmount -= fillSpeed * Time.deltaTime;
        }
        else
        {
            Debug.Log("A Gasolina Acabou");
        }
    }
}
