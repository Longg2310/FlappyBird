using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;

        float bgHeight = Camera.main.orthographicSize * 2f;
        float bgWidht = bgHeight * Screen.width / Screen.height;

        tempScale.y = bgHeight / height;
        tempScale.x = bgWidht / width;

        transform.localScale = tempScale;
    }
}
