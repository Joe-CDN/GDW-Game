using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logoFade : MonoBehaviour
{
    private float timer;
    private float t;
    private float newAlpha;
    Vector3 startAlpha = new Vector3(0, 0, 0);
    Vector3 endAlpha = new Vector3(200, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        timer = 22f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            t += Time.deltaTime * 0.001f;
            Vector3 lerpedAlpha = Vector3.Lerp(startAlpha, endAlpha, t);
            newAlpha = lerpedAlpha.x;
            this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(GetComponent<MeshRenderer>().material.color.r,
                                                                    GetComponent<MeshRenderer>().material.color.g,
                                                                    GetComponent<MeshRenderer>().material.color.b,
                                                                    newAlpha);
        }

        timer -= Time.deltaTime;

        if(t >= 0.005f)
        {
            SceneManager.LoadScene("Load");
        }
    }

    public static void SkipCS()
    {
        SceneManager.LoadScene("Load");
    }
}
