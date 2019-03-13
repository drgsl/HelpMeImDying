using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{

    public GameObject fence;
    public int FenceNumber;
    public bool x;

    void Awake()
    {
        for (int i = 0; i <FenceNumber; i += 1)
        {
            GameObject obj;

            float posX = fence.transform.position.x;
            float posZ = fence.transform.position.z;


            if (x)
            {
                obj = Instantiate(fence, new Vector3(posX - i * 15, fence.transform.position.y, fence.transform.position.z), transform.rotation);
            }
            else
            {
                obj = Instantiate(fence, new Vector3(fence.transform.position.x, fence.transform.position.y, (posZ - i * 15)), transform.rotation);
            }

            obj.transform.parent = transform;

        }
    }
}
