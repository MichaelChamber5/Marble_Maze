using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] Vector3 centerPoint = new Vector3(0, 0, 0);
    [SerializeField] Vector3 setOffsetVector;
    [SerializeField] float lookSpeed;
    Vector3 offsetVector;

    Vector2 moveDir = Vector2.zero;


    void Start()
    {
        offsetVector = setOffsetVector;
        transform.position = offsetVector;
    }

    
    void Update()
    {
        if(moveDir.x > 0)
        {
            offsetVector = Quaternion.AngleAxis(Time.deltaTime * lookSpeed, transform.up) * offsetVector;
        }
        else if(moveDir.x < 0)
        {
            offsetVector = Quaternion.AngleAxis(Time.deltaTime * -lookSpeed, transform.up) * offsetVector;
        }
        if (moveDir.y > 0)
        {
            offsetVector = Quaternion.AngleAxis(Time.deltaTime * -lookSpeed, transform.right) * offsetVector;
        }
        else if (moveDir.y < 0)
        {
            offsetVector = Quaternion.AngleAxis(Time.deltaTime * lookSpeed, transform.right) * offsetVector;
        }
        transform.position = offsetVector + centerPoint;
        transform.rotation = Quaternion.LookRotation(centerPoint - transform.position, transform.up);
    }

    void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }

    public Vector3 GetRotation()
    {
        return (centerPoint - offsetVector).normalized;
    }

    void OnNewMaze()
    {
        SceneManager.LoadScene("Level1");
    }
}
