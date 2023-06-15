using System;
using System.Collections;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    public Animator anim;

    public SpriteRenderer sprite;
    public Material defaultMaterial;
    public Material flashMaterial;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        defaultMaterial = sprite.material;
    }


    public void HurtFXTrigger()
    {
        anim.SetTrigger("hurt");
    }

    public IEnumerator HurtFX()
    {
        HurtFXTrigger();
        sprite.material = flashMaterial;

        yield return new WaitForSeconds(0.15f);

        sprite.material = defaultMaterial;
    }
}