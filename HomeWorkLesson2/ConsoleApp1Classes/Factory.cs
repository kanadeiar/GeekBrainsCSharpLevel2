using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Classes
{
    /// <summary>
    /// Фабрика
    /// </summary>
    class Factory : IEnumerable
    {
        public string Name { get; set; }
        private BaseWorker[] workers;
        public Factory(BaseWorker[] workers, string name)
        {
            this.workers = workers;
            Name = name;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var w in workers)
                yield return w;
        }
    }
}
