using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D boundingBox;
    // Start is called before the first frame update
    void Start()
    {
        boundingBox = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x < 0)
            {
                boundingBox.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                boundingBox.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            boundingBox.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            GameObject.Find("Stats").GetComponent<Stats>().total_hits_by_block++;
            GameObject.Find("GameStatsController").GetComponent<GameStatsController>().SaveStats();
            SceneManager.LoadScene("Menu");
        }
    }
}
