using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTest01.Models
{
    public class EntityCollection : ViewModel
    {
        private ObservableCollection<Entity> _items;
        public ReadOnlyObservableCollection<Entity> Items
        {
            get { return new ReadOnlyObservableCollection<Entity>(_items); }
        }

        public EntityCollection()
        {
            _items = new ObservableCollection<Entity>();
        }

        public void Add(Entity entity)
        {
            entity.ParentCollection = this;
            _items.Add(entity);
        }

        public void Remove(Entity entity)
        {
            if (_items.Contains(entity))
                _items.Remove(entity);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public void ExecuteEntities()
        {
            _items.Where(x => x is IExecutableEntity).ToList().ForEach(i => ((IExecutableEntity)i).Execute());
        }
    }
}
