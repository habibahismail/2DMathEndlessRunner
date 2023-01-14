using UnityEngine;
using UnityEngine.U2D;

/* 
 * Based on tutorial at: https://www.youtube.com/watch?v=a3Ev24uWJKE
 */

namespace bebaSpace
{
    public class TerrainCreator : MonoBehaviour
    {
        [SerializeField] private int scale = 100;
        [SerializeField] private int numOfPoints = 15;
        [SerializeField] private float perlinNoiseModifier = 5f;

        private float distanceBtwnPoints;
        private SpriteShapeController shape;

        private void Start()
        {
            shape = GetComponent<SpriteShapeController>();
            distanceBtwnPoints = scale / numOfPoints;

            shape.spline.SetPosition(2, shape.spline.GetPosition(2) + Vector3.right * scale);
            shape.spline.SetPosition(3, shape.spline.GetPosition(3) + Vector3.right * scale);

            shape.spline.SetTangentMode(0, ShapeTangentMode.Linear);
            shape.spline.SetTangentMode(1, ShapeTangentMode.Linear);
            shape.spline.SetTangentMode(2, ShapeTangentMode.Linear);
            shape.spline.SetTangentMode(3, ShapeTangentMode.Linear);

            for (int i = 0; i < numOfPoints; i++)
            {
                float xPos = shape.spline.GetPosition(i + 1).x + distanceBtwnPoints;
                Vector3 newPos = new Vector3(xPos, perlinNoiseModifier * Mathf.PerlinNoise(i * Random.Range(5f, 15f), 0));

                shape.spline.InsertPointAt(i + 2, newPos);

                //if(i == numOfPoints - 1)
                //{
                //    float lastXpoint = xPos;
                //    GameEvents.OnPlatformGenerated(lastXpoint);
                //}
            }

            for (int i = 2; i < numOfPoints + 2; i++)
            {
                shape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                shape.spline.SetLeftTangent(i, new Vector3(Random.Range(-1.3f,-2.5f), 0, 0));
                shape.spline.SetRightTangent(i, new Vector3(Random.Range(1.3f, 2.5f), 0, 0));
            }

            float lastXpoint = (shape.spline.GetPosition(3).x + scale) - shape.spline.GetPosition(0).x;
            GameEvents.OnPlatformGenerated(lastXpoint);
        }

    }
}
