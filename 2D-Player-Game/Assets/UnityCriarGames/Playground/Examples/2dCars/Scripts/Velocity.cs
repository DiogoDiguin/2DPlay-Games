using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Velocity : MonoBehaviour
{
    [SerializeField] private TMP_Text velocityLabel;
    [SerializeField] private PickupController pickupController;
    private int velocity;


    void Update()
    {
        velocityLabel.text = pickupController.carDrive.ToString();
    }

}
