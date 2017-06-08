using UnityEngine;
using System.Collections;

public class circlecollider : MonoBehaviour {

	public int NumEdges;
	public float Radius;
	void Start () {
		EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
		Vector2[] points = new Vector2[NumEdges];

		for (int i = 0; i < NumEdges; i++)
		{
			float angle = 2 * Mathf.PI * i / NumEdges;
			float x = Radius * Mathf.Cos(angle);
			float y = Radius * Mathf.Sin(angle);

			points[i] = new Vector2(x, y);
		}
		edgeCollider.points = points;
	}
}
