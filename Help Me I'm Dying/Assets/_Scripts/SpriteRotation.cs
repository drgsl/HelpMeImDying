using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var v = transform.position - Camera.main.transform.position;
        v.y = 0;
        transform.rotation = Quaternion.LookRotation(v);
    }
}
