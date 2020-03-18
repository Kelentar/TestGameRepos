using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        var wigth = height * Screen.width / Screen.height;

        if (gameObject.name == "Background")
        {
            transform.localScale = new Vector3(wigth, height, 0);
        }else
        {
            transform.localScale = new Vector3(wigth + 3f, 5, 0);
        }
    }

}
