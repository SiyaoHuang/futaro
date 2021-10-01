using UnityEngine;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        public FigureController figureController;

        void Update()
        {
            if (figureController == null)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                figureController.attack.set();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                figureController.shield.set();
            }
        }
    }
}