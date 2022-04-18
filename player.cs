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
		if (Input.GetKey(KeyCode.RightArrow))
        {
			transform.Translate(new Vector3(1f, 0f, 0f).normalized * Time.deltaTime * speed);
		}
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-1f, 0f, 0f).normalized * Time.deltaTime * speed);

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
		Debug.DrawRay(transform.position, Vector2.down, Color.red);

		if (rigid.velocity.y < 0)
		{
			if (Physics2D.Raycast(rigid.position, Vector2.down, 0.4f, LayerMask.GetMask(new string[] { "platform" })))
			{
				jumpCount = 2;
			}
		}
		
	}

}
