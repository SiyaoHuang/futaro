using System.Collections;
using UnityEngine;

namespace Script
{
    public class EnemyController : MonoBehaviour
    {
        public FigureController figureController;

        void Start()
        {
            StartCoroutine(RandomAttack());
        }

        IEnumerator RandomAttack()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                if (Random.value > 0.5f)
                {
                    figureController.attack.set();
                }
            }
        }
    }
}