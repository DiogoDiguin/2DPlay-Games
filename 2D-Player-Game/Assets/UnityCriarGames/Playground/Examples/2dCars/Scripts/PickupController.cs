using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    //SERIALIZATION VARIABLES
    [SerializeField]    private Rigidbody2D carBody;
    [SerializeField]    private Rigidbody2D tireFrontRigdBody;
    [SerializeField]    private Rigidbody2D tireBackRigdBody;
    [SerializeField]    private float speed;
    [SerializeField]    private float speedCar;
    [SerializeField]    private Image imageGas;
    [SerializeField]    private GameObject panelGameOver;
    [SerializeField]    public int carDrive;

    //[SerializeField]    private Button GasButton;

    //PUBLIC VARIABLES
    [SerializeField] public float gas;
    [SerializeField] public float gasConsumer;       
    [SerializeField] private AudioClip motorCar;
    //PRIVATE VARIABLES
    private float movement;

    /*private void Awake(){
        GasButton.onClick.AddListener(GasButtonPressed);
    }*/

    private void Start()
    {
        panelGameOver.SetActive(false);
    }

    private void FixedUpdate() 
    {
        MovementACar();
    }

    private void Update()
    {
        GetInputKeyBoard();
        VerificGasolina();
    }
    
    //----------------------------------------------------------------
    private void GetInputKeyBoard()
    {
        movement = Input.GetAxis("Horizontal");
        imageGas.fillAmount = gas;
    }

    //----------------------------------------------------------------
    private void MovementACar()
    {
        if (gas>0)
        {
            tireFrontRigdBody.AddTorque(-movement * speed * Time.fixedDeltaTime);
            tireBackRigdBody.AddTorque(-movement * speed * Time.fixedDeltaTime);
            carBody.AddTorque(-movement * speedCar * Time.fixedDeltaTime);
        }
        gas -= gasConsumer * Mathf.Abs(movement) * Time.fixedDeltaTime * 10;
    }

    /*public void MoveCarMObile()
    {
        if (gas > 0)
        {
            tireFrontRigdBody.AddTorque(-carDrive * speed * Time.fixedDeltaTime);
            tireBackRigdBody.AddTorque(-carDrive * speed * Time.fixedDeltaTime);
            carBody.AddTorque(-carDrive * speedCar * Time.fixedDeltaTime);
        }
        gas -= gasConsumer * Mathf.Abs(movement) * Time.fixedDeltaTime * 10;
    }*/

    public void CacheCarDrive()
    {
        carDrive++;
    }

    private void VerificGasolina()
    {
        if (imageGas.fillAmount <= 0)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void GasButtonPressed()
    {
        Debug.Log(carDrive);

        if (gas > 0)
        {
            tireFrontRigdBody.AddTorque(-carDrive * speed * Time.fixedDeltaTime);
            tireBackRigdBody.AddTorque(-carDrive * speed * Time.fixedDeltaTime);
            carBody.AddTorque(-carDrive * speedCar * Time.fixedDeltaTime);

            if (carDrive < 25)
            {
                carDrive++;
            }
        }

        gas -= gasConsumer * Time.fixedDeltaTime * 10; // Usando um valor fixo para o consumo de gasolina

        Debug.Log(carDrive);
        Debug.Log("Gasolina: " + gas);

        AudioSource.PlayClipAtPoint(motorCar, transform.position);
    }

    
    public void BrakeButtonPressed()
    {
        carDrive = 1;
    }

}