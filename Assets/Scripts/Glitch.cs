using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    public float m_GlitchChance = 0.1f;
    public float m_WaitBetweenGlitches = .1f;
    private Material m_hologramMaterial;

    // Start is called before the first frame update
    void Start()
    {
        m_hologramMaterial = GetComponent<Renderer>().sharedMaterial;
        StartCoroutine(GlitchEffect());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GlitchEffect()
    {
        while (true)
        {
            float glitchTry = Random.Range(0f, 1f);

            if (glitchTry <= m_GlitchChance)
            {
                float originalGlowIntensity = m_hologramMaterial.GetFloat("_GlowIntensity");

                m_hologramMaterial.SetFloat("_GLowIntensity", Random.Range(0.05f, 1f));
                m_hologramMaterial.SetFloat("_GlitchIntensity", Random.Range(0.05f, 1f));

                yield return new WaitForSeconds(0.1f);

                m_hologramMaterial.SetFloat("_GLowIntensity",originalGlowIntensity);
                m_hologramMaterial.SetFloat("_GlitchIntensity", 0f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}