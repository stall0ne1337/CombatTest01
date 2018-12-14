using CombatTest01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CombatTest01
{
    public class MainFrameEntityTemplateSelector : DataTemplateSelector
    {        
        public DataTemplate WallTemplate { get; set; }
        public DataTemplate TankTemplate { get; set; }
        public DataTemplate ProjectileTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Wall)
                return WallTemplate;

            if (item is Tank)
                return TankTemplate;

            if (item is Projectile)
                return ProjectileTemplate;

            return null;
        }
    }
}
