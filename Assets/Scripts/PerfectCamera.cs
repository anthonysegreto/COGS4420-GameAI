using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PerfectCamera : MonoBehaviour {

	private Camera thisCamera;
	private int CurrentHeight;
	private int CurrentWidth;
	[SerializeField]
	private int CurrentPPU;
	private float CurrentDPI;
	[SerializeField]
	private int PPUScale;
	[SerializeField]
	private bool SetTargetResolution;
	[SerializeField]
	private int TargetWidth;
	[SerializeField]
	private int TargetHeight;
	[SerializeField]
	private bool TieTargetResolutionToRendering;


	void SetPixelPerfect() {
		thisCamera.orthographicSize = ((float)(CurrentHeight)/(float)(PPUScale * CurrentPPU * 2));
	}

	void GetCamParams() {
		if (TieTargetResolutionToRendering) {
			CurrentHeight = TargetHeight;
			CurrentWidth = TargetWidth;
		}
		else {
			CurrentHeight = Screen.height;
			CurrentWidth = Screen.width;
		}
		CurrentDPI = Screen.dpi;
		if (SetTargetResolution) {
			if (CurrentWidth < CurrentHeight) {
				PPUScale = CurrentWidth/TargetWidth;
			}
			else {
				PPUScale = CurrentHeight/TargetHeight;
			}
		}
	}

	// Use this for initialization
	void Start () {
		thisCamera = GetComponent<Camera>();
		GetCamParams();
		SetPixelPerfect();
	}
	
	// Update is called once per frame
	void OnPreRender () {
		if ((CurrentHeight != Screen.height ||
	     	 CurrentWidth != Screen.width ||
		 	 CurrentDPI != Screen.dpi) && !TieTargetResolutionToRendering) {
			GetCamParams();
			SetPixelPerfect();
		}
	}
}
