using UnityEngine;

namespace JsonSave
{
    public struct TransformData
    {
        public float positionX;
        public float positionY;
        public float positionZ;
        public float rotationX;
        public float rotationY;
        public float rotationZ;
        public float rotationW;
        public float scaleX;
        public float scaleY;
        public float scaleZ;

        public TransformData(Transform transform)
        {
            positionX = transform.localPosition.x;
            positionY = transform.localPosition.y;
            positionZ = transform.localPosition.z;
            rotationX = transform.localRotation.x;
            rotationY = transform.localRotation.y;
            rotationZ = transform.localRotation.z;
            rotationW = transform.localRotation.w;
            scaleX = transform.localScale.x;
            scaleY = transform.localScale.y;
            scaleZ = transform.localScale.z;
        }

        public static void SetTransform(TransformData data, Transform transform)
        {
            transform.localPosition = new Vector3(data.positionX, data.positionY, data.positionZ);
            transform.localRotation = new Quaternion(data.rotationX, data.rotationY, data.rotationZ, data.rotationW);
            transform.localScale = new Vector3(data.scaleX, data.scaleY, data.scaleZ);
        }
    }
}