using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    public int bonusDiamondScore;
    public GameObject particleEffects;

    bool movingLeft = true;
    bool firstClick = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
    }
    private void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
    private void CheckInput()
    {
        if (firstClick)
        {
            firstClick = false;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            GameManager.instance.BonusScore(bonusDiamondScore);
            Instantiate(particleEffects, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
        }
    }
}
