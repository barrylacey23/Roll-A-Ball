using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {
	public float speed;
    public Text countText;
	private Rigidbody rb;

    private int count;
    public Text winText;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCountText();
        winText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }
}
