using UnityEngine;

public class MakeSequence : MonoBehaviour
{

    public GameObject Cube;
    public GameObject Cylinder;
    public GameObject Sphere;
    public GameObject Capsule;

    int TapCount;

    void Start()
    {
        TapCount = 0;
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // Define object position and rotation relative to camera
                var newObjectPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(touch.position.x, touch.position.y, 3.0f));

                var newObjectRotation = Quaternion.LookRotation(-newObjectPosition);

                // Note: Must code spawning in reverse order
                // Fourth+: Capsule
                if (TapCount > 2)
                {
                    Instantiate(Capsule, newObjectPosition, newObjectRotation);

                }

                // Third: Sphere
                if (TapCount == 2)
                {
                    Instantiate(Sphere, newObjectPosition, newObjectRotation);
                    TapCount = TapCount + 1;
                }

                // Second: Cylinder
                if (TapCount == 1)
                {
                    Instantiate(Cylinder, newObjectPosition, newObjectRotation);
                    TapCount = TapCount + 1;
                }

                // First: Cube
                if (TapCount == 0)
                {
                    Instantiate(Cube, newObjectPosition, newObjectRotation);
                    TapCount = TapCount + 1;
                }

            }
        }
    }
}
