using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaform : MonoBehaviour
{
    public GameObject diamond;
    void Start()
    {
        int randomNbr = Random.Range(0, 5);
        Vector3 diamondPosition = transform.position;
        diamondPosition.y += 1.0f;
        if(randomNbr < 1)
        {
            GameObject d = Instantiate(diamond, diamondPosition, diamond.transform.rotation);
            d.transform.SetParent(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", 0.2f);
        }
    }
    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1.0f);
    }
}
