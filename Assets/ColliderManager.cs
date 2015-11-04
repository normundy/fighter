﻿using UnityEngine;
using System.Collections;

public class ColliderManager : MonoBehaviour {
	
	// Set these in the editor
	public PolygonCollider2D[] idle;
	public PolygonCollider2D[] run;
	public PolygonCollider2D[] neutralLight;
	public PolygonCollider2D[] neutralHeavy;
	
	// Collider on this game object
	private PolygonCollider2D localCollider;
	
	public enum types
	{
		idle,
		run,
		neutral_light,
		neutral_heavy,
		clear // special case to remove all boxes
	}
	
	// We say box, but we're still using polygons.
	public enum frames
	{
		frame1,
		frame2,
		frame3,
		frame4,
		frame5,
		frame6,
		frame7,
		frame8,
		frame9,
		frame10,
		clear // special case to remove all boxes
	}
	
	void Start()
	{
		// Create a polygon collider
		localCollider = gameObject.AddComponent<PolygonCollider2D>();
		localCollider.isTrigger = true; // Set as a trigger so it doesn't collide with our environment
		localCollider.pathCount = 0; // Clear auto-generated polygons
	}
	
	public virtual void OnTriggerEnter2D(Collider2D collider)
	{

	}
	
	public void setCollider(types type, frames frame)
	{
		if(frame != frames.clear)
		{
			switch ((int)type){
			case 0:
				localCollider.SetPath(0, idle[(int)frame].GetPath(0));
				break;
			case 1:
				localCollider.SetPath(0, run[(int)frame].GetPath(0));
				break;
			case 2:
				localCollider.SetPath(0, neutralLight[(int)frame].GetPath(0));
				break;
			default:
				localCollider.SetPath(0, neutralHeavy[(int)frame].GetPath(0));
				break;
			}
			return;
		}
		localCollider.pathCount = 0;
	}
	
	public void clear() {
		localCollider.pathCount = 0;
	}
}
