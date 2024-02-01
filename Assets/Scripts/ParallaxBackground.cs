using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float animationSpeed = 1f;


    public void Awake()
    {
     sprite = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        sprite.size += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
