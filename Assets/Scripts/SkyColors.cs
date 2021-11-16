using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColors : MonoBehaviour
{
    public Color[] colors;

    void Start()
    {
        StartCoroutine(ChangeBackground());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    IEnumerator ChangeBackground()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            int c = Random.Range(0, 4);
            transform.GetComponent<Camera>().backgroundColor = colors[c];
        }
    }
}
