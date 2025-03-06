using UnityEngine;

namespace GameSession
{
    public interface IView
    {
        public void SetDirection(Quaternion quaternion);
        public void SetPositionImmediately(Vector3 position);
    }
}