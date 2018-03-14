using UnityEngine;

public class MakeCube : MonoBehaviour 
{
    public GameObject GameObjPrefab;

    void Update () 
    {
        if (Input.touchCount > 0) 
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                var newObjectPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(touch.position.x, touch.position.y, 1.0f));
                Instantiate(GameObjPrefab, newObjectPosition, Quaternion.identity);
            }
        }
	}
}
