using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuarantineController : MonoBehaviour
{
    public Image[] borders;
    public Color initialColor;
    private float alphaDecayFactor;
    public float flashSpeed;

    private Color currentColor;
    public float initialAlphaDecayFActor;
    private bool isFlashing = false;
    private float alphaValue = 1f;
    private int quarantinedZones = 0;

    private void Start()
    {
        quarantinedZones = 0;
        alphaDecayFactor = initialAlphaDecayFActor;
        alphaValue = 0;
        currentColor = initialColor;
        currentColor.a = 0;
        SetBordersColor();
        isFlashing = false;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void EnableFlash()
    {
        alphaDecayFactor = initialAlphaDecayFActor;
        isFlashing = true;
        alphaValue = 1;
        currentColor = initialColor;
        StartCoroutine(Flash());
    }

    public void DisableFlash()
    {
        isFlashing = false;
        currentColor.a = 0;
        SetBordersColor();
    }

    private IEnumerator Flash()
    {
        while (isFlashing)
        {
            alphaValue += alphaDecayFactor;
            if (alphaValue <= 0 || alphaValue >= 1)
            {
                alphaDecayFactor = -alphaDecayFactor;
            }
            currentColor.a = alphaValue;
            SetBordersColor();
            yield return new WaitForSeconds(flashSpeed);
        }
    }

    private void SetBordersColor()
    {
        foreach (Image border in borders)
        {
            border.color = currentColor;
        }

    }

    public void StartQuarantine()
    {
        quarantinedZones++;
        if (!isFlashing)
        {
            EnableFlash();
        }

    }

    public void EndQuarantine()
    {
        quarantinedZones--;
        if (quarantinedZones == 0)
        {
            DisableFlash();
        }
    }
}
