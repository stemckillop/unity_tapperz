using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public GameManager BtnManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(t.deltaPosition.x, t.deltaPosition.y, 0));
                    Ray ray = Camera.main.ScreenPointToRay(t.position);

                    RaycastHit info;
                    if (Physics.Raycast(ray, out info))
                    {
                        if (info.collider.gameObject.tag == "Block")
                        {
                            BtnManager.ButtonTouched(info.collider.GetComponent<Button>());
                        }
                    }
                }
            }
        }
	}
}
