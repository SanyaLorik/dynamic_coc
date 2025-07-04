using UnityEngine;

namespace _KotletaGames.Additional_M
{
    public static class VectorExtension
    {
        public static Vector3 SetXZ(this Vector3 source, float x, float z)
        {
            source.x = x;
            source.z = z;
            return source;
        }

        public static Vector3 SetX(this Vector3 source, float x)
        {
            source.x = x;
            return source;
        }

        public static Vector3 SetY(this Vector3 source, float y)
        {
            source.y = y;
            return source;
        }

        public static Vector3 Add(this Vector3 source, Vector3 commutative)
        {
            return source + commutative;
        }

        public static Vector3 AddXZ(this Vector3 source, float x, float z)
        {
            source.x += x;
            source.z += z;
            return source;
        }

        public static Vector3 AddXY(this Vector3 source, float x, float y)
        {
            source.x += x;
            source.y += y;
            return source;
        }

        public static Vector3 AddY(this Vector3 source, float y)
        {
            source.y += y;
            return source;
        }

        public static Vector3 AddX(this Vector3 source, float x)
        {
            source.x += x;
            return source;
        }

        public static Vector3 AddZ(this Vector3 source, float z)
        {
            source.z += z;
            return source;
        }

        public static Vector3 GetXZ(this Vector3 source)
        {
            return new()
            {
                x = source.x,
                z = source.z
            };
        }

        public static Vector3 ResetX(this Vector3 source)
        {
            source.x = 0;
            return source;
        }

        public static Vector3 ResetY(this Vector3 source)
        {
            source.y = 0;
            return source;
        }

        public static Vector3 ResetZ(this Vector3 source)
        {
            source.z = 0;
            return source;
        }

        public static Vector3 ResetXZ(this Vector3 source)
        {
            source.x = 0;
            source.z = 0;
            return source;
        }

        public static Vector3 InversX(this Vector3 source)
        {
            source.x *= -1;
            return source;
        }

        public static Vector3 InversY(this Vector3 source)
        {
            source.y *= -1;
            return source;
        }

        public static Vector3 RotationToPositionNormalizing(this Vector3 source, Vector3 to)
        {
            Quaternion rotation = Quaternion.LookRotation(to);
            Vector3 direction = rotation * source;

            return direction.normalized;
        }

        public static Vector3 RotationToPosition(this Vector3 source, Vector3 to)
        {
            Quaternion rotation = Quaternion.LookRotation(to);
            Vector3 direction = rotation * source;

            return direction;
        }

        public static Vector2 Add(this Vector2 source, Vector2 commutative)
        {
            return source + commutative;
        }

        public static Vector2 SetX(this Vector2 source, float x)
        {
            source.x = x;
            return source;
        }

        public static Vector2 SetY(this Vector2 source, float y)
        {
            source.y = y;
            return source;
        }

        public static Vector2 AddX(this Vector2 source, float x)
        {
            source.x += x;
            return source;
        }

        public static Vector2 AddY(this Vector2 source, float y)
        {
            source.y += y;
            return source;
        }

        public static Vector2 InversX(this Vector2 source)
        {
            source.x *= -1;
            return source;
        }

        public static Vector2 InversY(this Vector2 source)
        {
            source.y *= -1;
            return source;
        }

        public static Vector2 ResetX(this Vector2 source)
        {
            source.x = 0;
            return source;
        }

        public static Vector2 ResetY(this Vector2 source)
        {
            source.y = 0;
            return source;
        }
    }
}