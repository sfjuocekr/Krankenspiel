using UnityEngine;
using System.Collections;

public class MoverioCameraController : MonoBehaviour {

	private static MoverioCameraController _instance;
	public static MoverioCameraController Instance
	{
		get
		{
			if(_instance == null)
			{
				Debug.Log("Please Add MoverioCameraRig Prefab To Scene!");
			}

			return _instance;
		}
	}

	private Camera LeftEyeCam, RightEyeCam, Cam2D;

	MoverioDisplayType _displayState;

	void Awake()
	{
		_instance = this;
	}

    void Start()
    {
        if (Vuforia.VuforiaBehaviour.Instance.SecondaryCamera != null)
            SetCurrentDisplayType(MoverioDisplayType.Display3D);
        else
            SetCurrentDisplayType(MoverioDisplayType.Display2D);
    }

	public void SetPupillaryDistance(float pDist)
	{
        Debug.Log("YOLO DISTANCE: " + pDist.ToString());

		LeftEyeCam.transform.localPosition = new Vector3(-pDist, 0.0f, 0.0f);
        RightEyeCam.transform.localPosition = new Vector3(pDist, 0.0f, 0.0f);
	}

	void OnEnable()
	{
		MoverioController.OnMoverioStateChange += HandleOnMoverioStateChange;
    }

	void OnDisable()
	{
		MoverioController.OnMoverioStateChange -= HandleOnMoverioStateChange;
    }

	void HandleOnMoverioStateChange (MoverioEventType type)
	{
		switch(type)
		{
		case MoverioEventType.Display3DOff:
			SetCurrentDisplayType(MoverioDisplayType.Display2D);
			break;
		case MoverioEventType.Display3DOn:
			SetCurrentDisplayType(MoverioDisplayType.Display3D);
			break;
		}

	}

	public MoverioDisplayType GetCurrentDisplayState()
	{
		return _displayState;
	}

	public void SetCurrentDisplayType(MoverioDisplayType type)
	{
		_displayState = type;

		switch(_displayState)
		{
		    case MoverioDisplayType.Display2D:
                Cam2D = Vuforia.VuforiaBehaviour.Instance.PrimaryCamera;

                Cam2D.enabled = true;
                
                LeftEyeCam = RightEyeCam = null;

                break;
        
		    case MoverioDisplayType.Display3D:
                if (Vuforia.VuforiaBehaviour.Instance.IsStereoRendering)
                {
                    LeftEyeCam = Vuforia.VuforiaBehaviour.Instance.PrimaryCamera;
                    RightEyeCam = Vuforia.VuforiaBehaviour.Instance.SecondaryCamera;

                    LeftEyeCam.enabled = RightEyeCam.enabled = true;

                    Cam2D = null;

                    SetPupillaryDistance(Vuforia.VuforiaBehaviour.Instance.CameraOffset);
                }
                else
                {
                    Cam2D = Vuforia.VuforiaBehaviour.Instance.PrimaryCamera;

                    Cam2D.enabled = true;

                    LeftEyeCam = RightEyeCam = null;
                }

                break;
		}
    }


}
