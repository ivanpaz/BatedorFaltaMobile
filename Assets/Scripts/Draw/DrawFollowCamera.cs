using UnityEngine;
using UnityEngine.UIElements;

public class DrawFollowCamera : MonoBehaviour
{

    [SerializeField]
    float distance = 10f;

    
    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = Input.mousePosition;
        tempPos.z = distance;
        this.transform.position = Camera.main.ScreenToWorldPoint(tempPos);
    }
}
