using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20f)
        {
            GameObject.Find("Stats").GetComponent<Stats>().no_hit_blocks++;
            Destroy(gameObject);
        }
    }
}
