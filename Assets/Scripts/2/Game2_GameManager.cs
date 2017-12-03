using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2_GameManager : MonoBehaviour {

    public SpriteRenderer paperSprite;
    public Sprite[] papers;

    public SpriteRenderer ribbonSprite;
    public Sprite[] ribbons;

    public SpriteRenderer designSprite;
    public Sprite[] designs;

    private int paperIndex = 0;
    private int ribbonIndex = 0;
    private int designIndex = 0;
    
    void Start ()
    {
        paperSprite.sprite = papers[paperIndex];
        ribbonSprite.sprite = ribbons[ribbonIndex];
        designSprite.sprite = designs[designIndex];

        AkSoundEngine.PostEvent("Play_Game2_Music", gameObject);
    }

    private void PlaySound()
    {
        AkSoundEngine.PostEvent("Play_Game1_win", gameObject);
    }

    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("screenshot_your_own_present.png");
    }

    public void SwapPaper(int order)
    {
        PlaySound();

        paperIndex += order;

        if(paperIndex < 0)
        {
            paperIndex = papers.Length - 1;
        }

        if(paperIndex > papers.Length - 1)
        {
            paperIndex = 0;
        }

        paperSprite.sprite = papers[paperIndex];
    }

    public void SwapRibbon(int order)
    {
        PlaySound();

        ribbonIndex += order;

        if (ribbonIndex < 0)
        {
            ribbonIndex = ribbons.Length - 1;
        }

        if (ribbonIndex > ribbons.Length - 1)
        {
            ribbonIndex = 0;
        }

        ribbonSprite.sprite = ribbons[ribbonIndex];
    }

    public void SwapDesign(int order)
    {
        PlaySound();

        designIndex += order;

        if (designIndex < 0)
        {
            designIndex = designs.Length - 1;
        }

        if (designIndex > designs.Length - 1)
        {
            designIndex = 0;
        }

        designSprite.sprite = designs[designIndex];
    }
}
