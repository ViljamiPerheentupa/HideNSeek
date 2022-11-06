using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimator : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;
    int index;
    public float timePerFrame = 0.5f;
    float lastTick;

    private void Start()
    {
        index = 0;
        lastTick = Time.time;
        image = GetComponent<Image>();
    }
    void Update()
    {
        if(Time.time - lastTick >= timePerFrame)
        {
            if (index + 1 < sprites.Length)
            {
                lastTick = Time.time;
                index++;
                image.sprite = sprites[index];
            } else
            {
                lastTick = Time.time;
                index = 0;
                image.sprite = sprites[index];
            }

        }
    }
}
