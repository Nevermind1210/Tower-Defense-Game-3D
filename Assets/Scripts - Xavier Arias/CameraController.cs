using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

namespace Controller
{
    public class CameraController : MonoBehaviour
    {
        private float panSpeed = 0.06f;
        private float zoomSpeed = 10.0f;
        private float rotateSpeed;

        private float minHeight = 10f;
        private float maxHeight = 20f;

        private Vector2 p1;
        private Vector2 p2;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                panSpeed = 0.06f;
                zoomSpeed = 20.0f;
            }
            else
            {
                panSpeed = 0.035f;
                zoomSpeed = 10.0f;
            }


            float hsp = transform.position.y * panSpeed * Input.GetAxis("Horizontal"); // WE GET THE 
            float vsp = transform.position.y * panSpeed * Input.GetAxis("Vertical");
            float scrollSp = Mathf.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

            if ((transform.position.y >= maxHeight) && (scrollSp > 0))
            {
                scrollSp = 0;
            }
            else if ((transform.position.y <= minHeight) && (scrollSp < 0))
            {
                scrollSp = 0;
            }

            if ((transform.position.y + scrollSp) > maxHeight)
            {
                scrollSp = transform.position.y - maxHeight;
            }
            else if ((transform.position.y + scrollSp) < minHeight)
            {
                scrollSp = minHeight - transform.position.y;
            }

            Vector3 verticalMove = new Vector3(0, scrollSp, 0);
            Vector3 lateralMove = hsp * transform.right;
            Vector3 forwardMove = transform.forward;
            forwardMove.y = 0;
            forwardMove.Normalize();
            forwardMove *= vsp;

            Vector3 move = verticalMove + lateralMove + forwardMove;

            transform.position += move;
            
            getCameraRotation();
        }

        void getCameraRotation()
        {
            if (Input.GetMouseButtonDown(2)) // checking if the middle mouse button is pressed
            {
                p1 = Input.mousePosition;
            }

            if (Input.GetMouseButtonDown(2)) // Middle mouse click
            {
                p2 = Input.mousePosition;
                
                float dx = (p2 - p1).x * rotateSpeed;
                float dy = (p2 - p1).y * rotateSpeed;

                transform.rotation *= Quaternion.Euler((new Vector3(0, dx, 0))); // Y rotation! :D WEEEEEEEEE
                transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy, 0, 0 ));

                p1 = p2;
            }
        }
    }
}