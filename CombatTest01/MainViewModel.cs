using CombatTest01.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace CombatTest01
{
    public class MainViewModel : ViewModel
    {
        public EntityCollection EntityCollection { get; set; }

        public Tank PlayerA { get; private set; }
        public Tank PlayerB { get; private set; }

        private DispatcherTimer ClockTimer;

        public MainViewModel()
        {
            EntityCollection = new EntityCollection();

            ResetGame();
            InitializeTimer();           
        }

        private void InitializeTimer()
        {
            ClockTimer = new DispatcherTimer();
            ClockTimer.Tick += (o, a) => EntityCollection.ExecuteEntities();
            ClockTimer.Interval = TimeSpan.FromMilliseconds(40);
            ClockTimer.IsEnabled = true;
        }

        public void ResetGame()
        {
            EntityCollection.Clear();
            
            PlayerA = new Tank(new EntityPosition(50, 325), Player.PlayerA) { Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#8FD354")), Orientation = EntityOrientation.Right };
            EntityCollection.Add(PlayerA);

            PlayerB = new Tank(new EntityPosition(1000, 325), Player.PlayerB) { Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4A50DE")), Orientation = EntityOrientation.Left };
            EntityCollection.Add(PlayerB);

            AddWalls();
        }

        private void AddWalls()
        {
            // Outer Walls
            EntityCollection.Add(new Wall(new EntityPosition(0, 0), 30, 700));
            EntityCollection.Add(new Wall(new EntityPosition(0, 0), 1100, 30));
            EntityCollection.Add(new Wall(new EntityPosition(1070, 0), 30, 700));
            EntityCollection.Add(new Wall(new EntityPosition(0, 670), 1100, 30));

            // Vertical Obstacle Left
            EntityCollection.Add(new Wall(new EntityPosition(170, 250), 30, 200));
            EntityCollection.Add(new Wall(new EntityPosition(140, 220), 60, 30));
            EntityCollection.Add(new Wall(new EntityPosition(140, 450), 60, 30));

            // Vertical Obstacle Right
            EntityCollection.Add(new Wall(new EntityPosition(900, 250), 30, 200));
            EntityCollection.Add(new Wall(new EntityPosition(900, 220), 60, 30));
            EntityCollection.Add(new Wall(new EntityPosition(900, 450), 60, 30));

            // Horizontal Obstacles
            EntityCollection.Add(new Wall(new EntityPosition(170, 100), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(170, 570), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(850, 100), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(850, 570), 80, 30));

            // Inner Square Blocks
            EntityCollection.Add(new Wall(new EntityPosition(280, 325), 50, 50));
            EntityCollection.Add(new Wall(new EntityPosition(770, 325), 50, 50));

            // Wall Square Blocks
            EntityCollection.Add(new Wall(new EntityPosition(525, 30), 50, 50));
            EntityCollection.Add(new Wall(new EntityPosition(525, 620), 50, 50));

            // Corner Blocks Left
            EntityCollection.Add(new Wall(new EntityPosition(390, 150), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(390, 150), 30, 60));
            EntityCollection.Add(new Wall(new EntityPosition(390, 520), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(390, 490), 30, 60));

            // Corner Blocks Right
            EntityCollection.Add(new Wall(new EntityPosition(630, 150), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(680, 150), 30, 60));
            EntityCollection.Add(new Wall(new EntityPosition(630, 520), 80, 30));
            EntityCollection.Add(new Wall(new EntityPosition(680, 490), 30, 60));
        }
    }
}
