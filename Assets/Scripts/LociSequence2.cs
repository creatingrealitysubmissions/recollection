using UnityEngine;

public class LociSequence2 : MonoBehaviour
{
    // Objects to activate
    public GameObject Sentence1;
    public GameObject Sentence2;
    public GameObject Sentence3;
    public GameObject Sentence4;
    public GameObject Sentence5;
    public GameObject PoV;

    // Ensure player doesn't put all items in same place
    public static float Distance;
    public static int NewLocation = 1;
    Vector3 LastLocation;
    int TapCount = 0;


    void Update()
    {
        MovementChecker(PoV.transform.position);

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // Define object position and rotation relative to camera
                var newObjectPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(touch.position.x, touch.position.y, 3.0f));

                var newObjectRotation = Quaternion.LookRotation(PoV.transform.forward);
                newObjectRotation *= Quaternion.Euler(Vector3.up * 180);

                // Note: Must code spawning in reverse order
                if (TapCount == 4 && NewLocation == 1)
                {
                    Instantiate(Sentence5, newObjectPosition, newObjectRotation);
                    TapCount += 1;
                    LastLocation = PoV.transform.position;
                    NewLocation = 0;
                }

                if (TapCount == 3 && NewLocation == 1)
                {
                    Instantiate(Sentence4, newObjectPosition, newObjectRotation);
                    TapCount += 1;
                    LastLocation = PoV.transform.position;
                    NewLocation = 0;
                }

                if (TapCount == 2 && NewLocation == 1)
                {
                    Instantiate(Sentence3, newObjectPosition, newObjectRotation);
                    TapCount += 1;
                    LastLocation = PoV.transform.position;
                    NewLocation = 0;
                }

                if (TapCount == 1 && NewLocation == 1)
                {
                    Instantiate(Sentence2, newObjectPosition, newObjectRotation);
                    TapCount += 1;
                    LastLocation = PoV.transform.position;
                    NewLocation = 0;
                }

                if (TapCount == 0 && NewLocation == 1)
                {
                    Instantiate(Sentence1, newObjectPosition, newObjectRotation);
                    TapCount += 1;
                    LastLocation = PoV.transform.position;
                    NewLocation = 0;
                }

            }
        }
    }


    // Track how far the player has moved since they placed the last object
    // If player has moved sufficiently far, unlock ability to place new object
    void MovementChecker(Vector3 CurrentSpot)
    {
        if (NewLocation == 0)
        {
            Distance = Vector3.Distance(CurrentSpot, LastLocation);
            if (Distance > 1.25f)
            {
                NewLocation = 1;
            }
        }
    }


}
