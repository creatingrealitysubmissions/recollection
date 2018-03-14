using UnityEngine;

public class LociSequenceOld : MonoBehaviour
{
    // Objects to activate
    public GameObject Sentence1;
    public GameObject Sentence2;
    public GameObject Sentence3;
    public GameObject Sentence4;
    public GameObject Sentence5;
    public GameObject poop;
    public GameObject PoV;

    // Ensure player doesn't put all items in same place
    public static float Distance;
    public static int NewLocation = 1;

    Vector3 LastLocation;
    int TapCount = 0;


    void Update ()
    {









        if (Input.GetKeyDown(KeyCode.Space))
        {
            //instantiate

            Vector3 tempPos = PoV.transform.position;
            tempPos.z += 0.5f;


            var newObjectPosition = tempPos;


            //Camera.main.ScreenToWorldPoint(
            //new Vector3(touch.position.x, touch.position.y, 3.0f));

            var CamDirection = PoV.transform.position - newObjectPosition;


            //var newObjectRotation = PoV.transform.rotation;
            //newObjectRotation.eulerAngles = new Vector3(newObjectRotation.x, 90f, newObjectRotation.z);
            //LookRotation(-PoV.transform.forward);

            //Instantiate(poop, newObjectPosition, newObjectRotation);


            GameObject pee = Instantiate(poop, newObjectPosition, Quaternion.identity)
                as GameObject;
            pee.transform.rotation = Quaternion.LookRotation(CamDirection);
            pee.SetActive(true);


        }

        MovementChecker(Camera.main.transform.position);

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // Define object position and rotation relative to camera
                var newObjectPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(touch.position.x, touch.position.y, 3.0f));

                var newObjectRotation = Quaternion.LookRotation(-PoV.transform.forward);

                // Note: Must code spawning in reverse order
                if (TapCount == 4 && NewLocation == 1)
                {
                    Instantiate(Sentence5, newObjectPosition, newObjectRotation);
                    TapCount = TapCount + 1;
                    LastLocation = Camera.main.transform.position;
                    NewLocation = 0;
                }

                if (TapCount == 3 && NewLocation == 1)
                {
                    Instantiate(Sentence4, newObjectPosition, newObjectRotation);
                    TapCount = TapCount + 1;
                    LastLocation = Camera.main.transform.position;
                    NewLocation = 0;
                }

                if (TapCount == 2 && NewLocation == 1)
                {
                    Instantiate(Sentence3, newObjectPosition, newObjectRotation);
                    TapCount = TapCount + 1;
                    LastLocation = Camera.main.transform.position;
                    NewLocation = 0;
                }

                if (TapCount == 1 && NewLocation == 1)
                {
                    Instantiate(Sentence2, newObjectPosition, newObjectRotation);
                    TapCount = TapCount + 1;
                    LastLocation = Camera.main.transform.position;
                    NewLocation = 0;
                }

                if (TapCount == 0 && NewLocation == 1)
                {
                    Instantiate(Sentence1, newObjectPosition, newObjectRotation);
                    TapCount = TapCount + 1;
                    LastLocation = Camera.main.transform.position;
                    NewLocation = 0;
                }

            }
        }
    }


    // Track how far the player has moved since they placed the last object
    // If player has moved sufficiently far, unlock ability to place new object
    void MovementChecker (Vector3 CurrentSpot)
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
