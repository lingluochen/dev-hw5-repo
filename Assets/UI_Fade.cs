using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fade : MonoBehaviour
{
    public Image black;
    public Physics slime;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        black.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (slime.move == false)
        { 
            StartCoroutine(FadeImage1(true));

        }else
        
        if (black.color.a > 0)
        {
            camera.backgroundColor = Color.black;
            StartCoroutine(FadeImage2(true));
        }
    }

    IEnumerator FadeImage1(bool fadein)
    {
        // fade from opaque to transparent
        if (fadein)
        {
            // loop over 1 second backwards
        

            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                black.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        

    }

    IEnumerator FadeImage2(bool fadeout)
    {
        // fade from opaque to transparent
        if (fadeout)
        {
            // loop over 1 second backwards


            
            for (float i = 1; i >= 0; i -= 0.4f*Time.deltaTime)
            {
                // set color with i as alpha
                black.color = new Color(1, 1, 1, i);
                yield return null;
            }
            
        }
        // fade from transparent to opaque

    }


}
