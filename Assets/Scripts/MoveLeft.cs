using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float movingSpeed = 20.0f;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.gameOver)
        {
            transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide " + nameof(other));
    }
}
