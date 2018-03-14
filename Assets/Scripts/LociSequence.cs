using UnityEngine;


public class LociSequence : MonoBehaviour
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
        MovementChecker(Camera.main.transform.position);

        if (Input.touchCount > 0)
        {
            Spawner();
        }
    }


    // Spawn sequence of objects
    void Spawner()
    {
        // Spawn when screen is tapped
        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            // Define object position and rotation relative to camera 
            Vector3 newObjectPosition = PoV.transform.position;
            newObjectPosition.z += 0.5f;

            var TurnTo = PoV.transform.position - newObjectPosition;

            // Sorry for the spagetti conditions... new to C#
            // Note: Must code spawning in reverse order
            if (TapCount == 4 && NewLocation == 1)
            {
                // Spawn
                GameObject Poop = Instantiate(Sentence5, newObjectPosition, 
                                              Quaternion.identity) as GameObject;
                Poop.transform.rotation = Quaternion.LookRotation(TurnTo);

                // Track
                TapCount += 1;
                LastLocation = PoV.transform.position;
                NewLocation = 0;
            }

            if (TapCount == 3 && NewLocation == 1)
            {
                // Spawn
                GameObject Hunnid = Instantiate(Sentence4, newObjectPosition, 
                                                Quaternion.identity) as GameObject;
                Hunnid.transform.rotation = Quaternion.LookRotation(TurnTo);

                // Track
                TapCount += 1;
                LastLocation = PoV.transform.position;
                NewLocation = 0;
            }

            if (TapCount == 2 && NewLocation == 1)
            {
                // Spawn
                GameObject Wine = Instantiate(Sentence3, newObjectPosition, 
                                              Quaternion.identity) as GameObject;
                Wine.transform.rotation = Quaternion.LookRotation(TurnTo);

                // Track
                TapCount += 1;
                LastLocation = PoV.transform.position;
                NewLocation = 0;
            }

            if (TapCount == 1 && NewLocation == 1)
            {
                // Spawn
                GameObject House = Instantiate(Sentence2, newObjectPosition, 
                                               Quaternion.identity) as GameObject;
                House.transform.rotation = Quaternion.LookRotation(TurnTo);

                // Track
                TapCount += 1;
                LastLocation = PoV.transform.position;
                NewLocation = 0;
            }

            if (TapCount == 0 && NewLocation == 1)
            {
                // Spawn
                GameObject Thinking = Instantiate(Sentence1, newObjectPosition, 
                                                  Quaternion.identity) as GameObject;
                Thinking.transform.rotation = Quaternion.LookRotation(TurnTo);

                // Track
                TapCount += 1;
                LastLocation = PoV.transform.position;
                NewLocation = 0;
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
