using UnityEngine;

namespace _Root.Code
{
    public static class Extensions
    {
        public static bool TryGetTheComponent<T>(this GameObject go, out T component) where T : class
        {
            var result = go.GetComponent<T>();
            if (result != null)
            {
                component = result;
                return true;
            }

            component = null;
            return false;
        }
    }
}