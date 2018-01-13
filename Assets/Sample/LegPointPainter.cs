using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class LegPointPainter : MonoBehaviour
{
	public Brush brush;
	public InkCanvas canvas;

	public int paintTiming = 3;
	private int count;

	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
	}

	private void OnCollisionStay(Collision collision)
	{
		count++;
		if (count >= paintTiming)
		{
			count = 0;
			foreach (var p in collision.contacts)
			{
				var canvas = p.otherCollider.GetComponent<InkCanvas>();
				if (canvas != null)
					canvas.Paint(brush, p.point);
			}
		}
	}
}