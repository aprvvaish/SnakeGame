﻿using Microsoft.Extensions.Configuration;
using SnakeGame.Source.Common;
using SnakeGame.Source.FoodGenerationStrategies.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame.Source.FoodGenerationStrategies
{
    public class Level3Strategy : FoodDrawStrategyBase, IFoodDrawer
    {
        public (int, int) Draw(List<KeyValuePair<int, int>> coordinates)
        {
            var (foodX, foodY) = DrawFoodWithinWallsAndNotOnSnake(coordinates);
            var section = ConfigurationHelper.GetSection("level3ObstacleCoordinates").GetChildren();
            while (section.Any(x => x.GetValue<int>("x") == foodX && x.GetValue<int>("y") == foodY))
            {
                (foodX, foodY) = DrawFoodWithinWallsAndNotOnSnake(coordinates);
            }            
            DrawFood(foodX, foodY);
            return (foodX, foodY);
        }
    }
}
