using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vroom.Models.ViewModels
{
    public class BikeViewModel
    {
        public Bike Bike { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Currency> Curriencies { get; set; }
        private List<Currency> CreateCurrencyList()
        {
            var ret = new List<Currency>();
            ret.Add(new Currency("AUD", "AUD"));
            ret.Add(new Currency("USD", "USD"));
            ret.Add(new Currency("EUR", "EUR"));
            return ret;
        }

        public BikeViewModel()
        {
            Curriencies = CreateCurrencyList();
        }
    }
    public class Currency
    {
        public Currency(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}

