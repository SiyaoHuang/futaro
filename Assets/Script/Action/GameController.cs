using System;
using UnityEngine;

namespace Script
{

    public  enum FigureType
    {
        player,
        enemy
    }
    public class GameController : MonoBehaviour
    {
        void Start()
        {
            SpawnFigure(new Figure()
            {
                name = "Joe",
                dmg = 10,
                health = 100,
                shield = 30,
            }, FigureType.player);
            SpawnFigure(new Figure()
            {
                name = "Abb",
                dmg = 10,
                health = 100,
                shield = 30,
            }, FigureType.enemy);
        }

        void Update()
        {
            
        }

        public void SpawnFigure(Figure figure, FigureType type)
        {
            GameObject figureGameObject = new GameObject();
            figureGameObject.name = figure.name;
            var figureController = figureGameObject.AddComponent<FigureController>();
            figureController.figure = figure;
            switch(type){
                case FigureType.player:
                    var playerController = figureGameObject.AddComponent<PlayerController>();
                    playerController.figureController = figureController;
                    break;
                case FigureType.enemy:
                    var enemyController = figureGameObject.AddComponent<EnemyController>();
                    enemyController.figureController = figureController;
                    break;
            }
           
        }
    }
}