using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool isRight;
    public bool isLeft;
    public int jumpCount;
	public float jumpPower;
	public Rigidbody2D rigid;

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
		float x = Input.GetAxisRaw("Horizontal");
		if (Input.GetKeyDown(KeyCode.RightArrow))
        {
			isRight = true;
        }
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			isRight = false;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			isLeft = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			isLeft = false;
		}
		transform.Translate(new Vector3(x, 0f, 0f).normalized * Time.deltaTime * speed);
		if (isLeft)
		{
			transform.Translate(new Vector3(-1f, 0f, 0f).normalized * Time.deltaTime * speed);
		}
		if (isRight)
		{
			transform.Translate(new Vector3(1f, 0f, 0f).normalized * Time.deltaTime * speed);
		}
		if (Input.GetKeyDown("space") && jumpCount > 0)
		{
			rigid.velocity = Vector2.zero;
			rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
			jumpCount--;
		}
	}

}
