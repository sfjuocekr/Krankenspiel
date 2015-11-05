using UnityEngine;

public class DebugRenderer : MonoBehaviour
{
	private void Start ()
    {
            GetComponent<Renderer>().enabled = Debug.isDebugBuild;
    }
}
