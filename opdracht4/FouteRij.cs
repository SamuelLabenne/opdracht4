using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_4
{
    internal class FouteRij<T>
    {
        private List<T> container = new List<T>();
        private T Huidig { get; set; }
        public bool IsLeeg { get; set; }
        public int Count { get; set; }
        public T HuidigElement { get; set; }

        public T Toevoegen(T iets)
        {
            container.Add(iets);
            return this.Huidig;
        }

        public T Verwijderen(T Huidig)
        {
            container.Remove(Huidig);
            return this.Huidig;
        }

        public T Volgende()
        {
            for (int i = 0; i < container.Count; i++)
            {
                if (container[i] == null)
                {
                    container[i] = this.Huidig;
                }
            }
            return this.Huidig;
        }

        public void Leegmaken()
        {
            container.Clear();
            this.Huidig = default(T);
        }

        public T ZetAchteraan(T Huidig)
        {
            container.Remove(Huidig);
            container.Add(Huidig);
            return Huidig;
        }

        public string ToString()
        {
            string text = "";
            foreach(T item in container)
            {
                text += item.ToString() + "\n";
            }
            return text;
        }

        public List<T> Copy()
        {
            return container;
        }
    }
}
