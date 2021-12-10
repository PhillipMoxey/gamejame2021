using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fade : MonoBehaviour
{
    public Image FadeIn;

    // Start is called before the first frame update
    void Start()
    {

        FadeIn.CrossFadeAlpha(0, 1, true);
    }

    // Update is called once per frame
    public void Fade_Fade()
    {
        FadeIn.CrossFadeAlpha(1, 1, true);
    }
}
