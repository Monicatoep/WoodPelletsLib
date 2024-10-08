using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WoodPelletsLib
{
    public class WoodPelletRepository
    {
        private int _nextId = 1;
        private readonly List<WoodPellet> _woodPellets = new();

        public WoodPelletRepository()
        {
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "BioWood", Price = 4995, Quality = 4 });
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "BioWood", Price = 5195, Quality = 4 });
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "BilligPille", Price = 4125, Quality = 1 });
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "GoldenWoodPellet", Price = 5995, Quality = 5 });
            _woodPellets.Add(new WoodPellet() { Id = _nextId++, Brand = "GoldenWoodPellet", Price = 5795, Quality = 5 });

        }

        public WoodPellet Add(WoodPellet woodPellet)
        {
            woodPellet.Validate();
            woodPellet.Id = _nextId++;
            _woodPellets.Add(woodPellet);
            return woodPellet;
        }

        public IEnumerable<WoodPellet?> GetAll()
        {
            if (_woodPellets == null)
            {
                return null;
            }
            return _woodPellets;
        }

        public WoodPellet? GetById(int id)
        {
            return _woodPellets.Find(a => a.Id == id);
        }

        public WoodPellet? Update(int id, WoodPellet woodPellet)
        {
            woodPellet.Validate();
            WoodPellet? woodPelletToUpdate = GetById(id);
            if (woodPelletToUpdate != null)
            {
                woodPelletToUpdate.Brand = woodPellet.Brand;
                woodPelletToUpdate.Price = woodPellet.Price;
                woodPelletToUpdate.Quality = woodPellet.Quality;
                return woodPelletToUpdate;
            }
            return null;
        }
    }
}


