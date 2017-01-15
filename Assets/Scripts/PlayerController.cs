using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
    public int count;
    public Text countText;
    public Text winText;

	// Use this for initialization
	void Start () {
        count = 0;
        countText.text = "Count: " + count.ToString();
        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "pickUp")
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count: " + count.ToString();
            if (count >= 8)
            {
                winText.text = "You win!";
            }
        }
    }
}
