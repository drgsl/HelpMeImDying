using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{

    public GameObject fence;
    public int FenceNumber;
    public bool x;

    public int length = 15;

    void Awake()
    {
        for (int i = 1; i <FenceNumber; i += 1)
        {
            GameObject obj;

            float posX = fence.transform.position.x;
            float posZ = fence.transform.position.z;
            float posY = fence.transform.position.y;


            if (x)
            {
                obj = Instantiate(fence, new Vector3(posX - i * length, posY, posZ), fence.transform.rotation);
            }
            else
            {
                obj = Instantiate(fence, new Vector3(posX, posY, posZ - i * length), fence.transform.rotation);
            }

            obj.transform.parent = transform;

        }
    }
}
