using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float xRange = 5f;

    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float yRange = 4f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float controlRollFactor = -25f;

    float xThrow;
    float yThrow;
    bool isControlEnabled = true;


    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            transformX();
            transformY();
            processRotation();
            processFiring();
        }
    }

    // called be string reference
    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    private void processRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + 
            yThrow * controlPitchFactor;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void transformX()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float finalXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        transform.localPosition = new Vector3(finalXPos,
            transform.localPosition.y, transform.localPosition.z);
    }

    private void transformY()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float finalYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x,
            finalYPos, transform.localPosition.z);
    }

    private void processFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }
}
