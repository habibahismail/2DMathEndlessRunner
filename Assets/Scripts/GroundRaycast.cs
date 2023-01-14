using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bebaSpace
{
    public class GroundRaycast : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;

        private Transform objectTransform;

        private void Start()
        {
            objectTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundLayer);

            if (hit)
            {


                Vector3 bounds = new Vector3(0, 0, 45); // ie: x axis has a range of -20 to 20 degrees

                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                rotation = ClampRotation(rotation, bounds);
                //objectTransform.rotation = rotation; 

                objectTransform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 0.75f);
            }
            
        }

        public static Quaternion ClampRotation(Quaternion q, Vector3 bounds)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
            angleX = Mathf.Clamp(angleX, -bounds.x, bounds.x);
            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            float angleY = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.y);
            angleY = Mathf.Clamp(angleY, -bounds.y, bounds.y);
            q.y = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleY);

            float angleZ = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.z);
            angleZ = Mathf.Clamp(angleZ, -bounds.z, bounds.z);
            q.z = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleZ);

            return q.normalized;
        }
    }
}
