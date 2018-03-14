using UnityEngine;

public class MakeObj : MonoBehaviour {

    public GameObject Cube;
    public GameObject Cylinder;
    public GameObject Sphere;
    public GameObject Capsule;
    int TapCount;


    void Start () 
    {
        TapCount = 0;
    }

	
    void Update () 
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // Define object position on tap
                var newObjectPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(touch.position.x, touch.position.y, 1.0f));
                
                // First: Cube
                if (TapCount == 0)
                {
                    Instantiate(Cube, newObjectPosition, Quaternion.identity);
                    TapCount = TapCount + 1;
                }

                // Second: Cylinder
                if (TapCount == 1)
                {
                    Instantiate(Cylinder, newObjectPosition, Quaternion.identity);
                    TapCount = TapCount + 1;
                }

                // Third: Sphere
                if (TapCount == 2)
                {
                    Instantiate(Sphere, newObjectPosition, Quaternion.identity);
                    TapCount = TapCount + 1;
                }

                // Fourth+: Capsule
                if (TapCount > 2)
                {
                    Instantiate(Capsule, newObjectPosition, Quaternion.identity);
                }

            }
        }
	}
}
