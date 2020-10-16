using UnityEngine;

namespace _Project.Scripts
{
    public class DifficultySetterCaller : MonoBehaviour
    {
        public void SetDifficulty(int difficulty)
        {
            DifficultySetter.Instance.SetDifficulty(difficulty);
        }
    }
}