using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerController : MonoBehaviour {

	protected Joystick _joystick;
	

	
	public Joybutton _joybutton_B;	
	public Joybutton _joybutton_Y;
	public Joybutton _joybutton_X;
	public Joybutton _joybutton_A;
	
	protected bool jump;
	protected bool slash;
	protected bool attack;
	protected bool block;
	
	[SerializeField]
	public Animator _anim;

	private Rigidbody rigidbody;
	
	void Start()
	{
		_joystick = FindObjectOfType<Joystick>();
		_anim = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody>();
		jump = false;
		slash = false;
		attack = false;
		block = false;
	}

	// Update is called once per frame
	void Update()
	{
		

		float x = _joystick.Horizontal;
		float y = _joystick.Vertical;
		
		rigidbody.velocity = new Vector3(x * 0.3f, rigidbody.velocity.y, y * 0.3f);

		
		Walk(x, y);
		Slash();
		Jump();
		Attack();
		Block();
	}

	void Attack()
	{
		if (!attack && _joybutton_Y.Pressed)
		{
			attack = true;
			_anim.SetBool("attack", true);
			print("attack true");
		}

		if (attack && !_joybutton_Y.Pressed)
		{
			attack = false;
			_anim.SetBool("attack", false);
			print("attack false");

		}
	}
	
	void Block()
	{
		if (!block && _joybutton_X.Pressed)
		{
			block = true;
			_anim.SetBool("block", true);
			print("block true");
		}

		if (block && !_joybutton_X.Pressed)
		{
			block = false;
			_anim.SetBool("block", false);
			print("block false");

		}
	}
	
	void Slash()
	{
		if (!slash && _joybutton_B.Pressed)
		{
			slash = true;
			_anim.SetBool("slash", true);
			print("slash true");
		}

		if (slash && !_joybutton_B.Pressed)
		{
			slash = false;
			_anim.SetBool("slash", false);
			print("slash false");

		}
	}

	void Jump()
	{
		if (!jump && _joybutton_A.Pressed)
		{
			jump = true;
			_anim.SetBool("jump", true);
			print("jump true");
		}

		if (jump && !_joybutton_A.Pressed)
		{
			jump = false;
			_anim.SetBool("jump", false);
			print("jump false");

		}
	}

	void Walk(float x, float y)
	{
		if (x != 0f || y != 0f)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg,
				transform.eulerAngles.z);
		}

		if (_joystick.Horizontal.Equals(0) && _joystick.Vertical.Equals(0))
		{
			print("walking false");
			_anim.SetBool("walking", false);
			_anim.SetBool("run", false);
		}
		else
		{
			print("walking true");
			_anim.SetBool("walking", true);

			if (x <= -0.7f || x >= 0.7 || y <= -0.7f || y >= 0.7f)
			{
				_anim.SetBool("run", true);
			}
			else
			{
				_anim.SetBool("run", false);
			}

		}
	}
}
