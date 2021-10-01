using UnityEngine;

namespace Script
{
    public class FigureController:MonoBehaviour
    {
        public Figure figure;

        public Trigger attack = new Trigger();
        public Trigger shield = new Trigger();

        // void Start()
        // {
        //     figure = new Figure()
        //     {
        //         name = "Abb",
        //         dmg = 10,
        //         health = 100,
        //         shield = 30,
        //     };
        // }
        
        void Update()
        {
            if (figure == null)
            {
                return;
            }
            if (attack.get())
            {
                Attack();
            }

            if (shield.get())
            {
                Shield();
            }
        }

        public void Attack()
        {
            Debug.Log($"name: {figure.name} attack, dmg: {figure.dmg}" );
        }

        public void Shield()
        {
            Debug.Log($"name: {figure.name} protect, shield left: {figure.shield}" );
        }

        public void Damage()
        {
            Debug.Log($"name: {figure.name} get damage, health left: {figure.health}" );
        }
    }
    
}