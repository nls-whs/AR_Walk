using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Blendet den Avatar aus sobald er mit einem Objekt kollidiert.
/// </summary>
public class FadeOnCollision : MonoBehaviour
{
    [SerializeField] private Renderer avatarPartShow1;
    [SerializeField] private Renderer[] avatarPartsShow;
    [SerializeField] private GameObject[] avatarPartsHide;
    private Shader transparent;
    private Shader originalShader;
    private Renderer avatarRenderer;
    [SerializeField] private GameObject sign;
    void Start()
    {
        originalShader = avatarPartShow1.material.shader;
        transparent = Shader.Find("Transparent/Diffuse");
        avatarRenderer = GetComponent<Renderer>();
        originalShader = avatarRenderer.material.shader;
    }
    void OnCollisionEnter(Collision collision)
    {
        fadeMaterial(avatarRenderer, 0.2f);
        sign.SetActive(true);
        foreach (Renderer avatarPart in avatarPartsShow)
        {
            fadeMaterial(avatarPart, 0.2f);
        }
        foreach (GameObject avatarPart in avatarPartsHide)
        {
            avatarPart.SetActive(false);
        }
    }
    void OnCollisionExit(Collision collision)
    {

        showMaterial(avatarRenderer);
        sign.SetActive(false);
        foreach (Renderer avatarPart in avatarPartsShow)
        {
            showMaterial(avatarPart);
        }
        foreach (GameObject avatarPart in avatarPartsHide)
        {
            avatarPart.SetActive(true);
        }
    }
    void fadeMaterial(Renderer r, float alpha)
    {
        r.material.shader = transparent;
        Color color = r.material.color;
        color.a = alpha;
        r.material.color = color;
    }
    void showMaterial(Renderer r)
    {
        if (r.material.shader = transparent)
        {
            Color color = r.material.color;
            color.a = 1f;
            r.material.color = color;
            r.material.shader = originalShader;
        }

    }
}

