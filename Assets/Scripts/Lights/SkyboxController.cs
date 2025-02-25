using System;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    [SerializeField] DayTimeManager m_dayTimeManager;
    [SerializeField] Material m_materialDay;
    [SerializeField] Material[] m_materials;
    private int m_hour;
    private int dayState;

    private void Start()
    {
        m_dayTimeManager.onDayTimeChange += OnTimeChange;
        m_hour = m_dayTimeManager.dayTime.Hour;
        MakeTwoMaterialsEqual(m_materialDay, m_materials[0]);
        dayState++;
        m_hour = m_dayTimeManager.dayTime.Hour;
    }

    private void OnTimeChange(DayTime time)
    {
        m_materialDay.Lerp(m_materialDay, m_materials[dayState], Time.deltaTime);
        Debug.Log(m_materials[dayState]);
        if (time.Hour > m_hour + 2)
        {
            m_hour += 3;
            dayState++;
        }
        Debug.Log(time.Hour);
    }

    private void MakeTwoMaterialsEqual(Material main, Material nextMat)
    {
        main.SetColor("_SunDiscColor", nextMat.GetColor("_SunDiscColor"));
        main.SetFloat("_SunDiscMultiplier", nextMat.GetFloat("_SunDiscMultiplier"));
        main.SetFloat("_SunDiscExponent", nextMat.GetFloat("_SunDiscExponent"));
        // [Header(Sun Disc)]
        // _SunDiscColor("Color", Color) = (1, 1, 1, 1)
        // _SunDiscMultiplier("Multiplier", float) = 25
        // _SunDiscExponent("Exponent", float) = 125000

        main.SetColor("_SunHaloColor", nextMat.GetColor("_SunHaloColor"));
        main.SetFloat("_SunHaloExponent", nextMat.GetFloat("_SunHaloExponent"));
        main.SetFloat("_SunHaloContribution", nextMat.GetFloat("_SunHaloContribution"));
        // [Header(Sun Halo)]
        // _SunHaloColor("Color", Color) = (0.8970588, 0.7760561, 0.6661981, 1)
        // _SunHaloExponent("Exponent", float) = 125
        // _SunHaloContribution("Contribution", Range(0, 1)) = 0.75

        main.SetColor("_HorizonLineColor", nextMat.GetColor("_HorizonLineColor"));
        main.SetFloat("_HorizonLineExponent", nextMat.GetFloat("_HorizonLineExponent"));
        main.SetFloat("_HorizonLineContribution", nextMat.GetFloat("_HorizonLineContribution"));
        // [Header(Horizon Line)]
        // _HorizonLineColor("Color", Color) = (0.9044118, 0.8872592, 0.7913603, 1)
        // _HorizonLineExponent("Exponent", float) = 4
        // _HorizonLineContribution("Contribution", Range(0, 1)) = 0.25
        
        main.SetColor("_SkyGradientTop", nextMat.GetColor("_SkyGradientTop"));
        main.SetColor("_SkyGradientBottom", nextMat.GetColor("_SkyGradientBottom"));
        main.SetFloat("_SkyGradientExponent", nextMat.GetFloat("_SkyGradientExponent"));
        // [Header(Sky Gradient)]
        // _SkyGradientTop("Top", Color) = (0.172549, 0.5686274, 0.6941177, 1)
        // _SkyGradientBottom("Bottom", Color) = (0.764706, 0.8156863, 0.8509805)
        // _SkyGradientExponent("Exponent", float) = 2.5
    }
}
