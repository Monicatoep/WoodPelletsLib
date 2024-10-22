using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public IEnumerable<WoodPellet?> GetAll(string? brand = null, string? quality = null, string? orderBy = null)
        {
            IEnumerable<WoodPellet> result = new List<WoodPellet>(_woodPellets);

            if (brand != null)
            {
                result = result.Where(m => m.Brand.Contains(brand));
            }

            if (quality != null)
            {
                result = result.Where(m => m.Quality >= int.Parse(quality));
            }

            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "brand":
                    case "brand_asc":
                        result = result.OrderBy(m => m.Brand);
                        break;
                    case "brand_desc":
                        result = result.OrderByDescending(m => m.Brand);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(m => m.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(m => m.Price);
                        break;
                    case "quality":
                    case "quality_asc":
                        result = result.OrderBy(m => m.Quality);
                        break;
                    case "quality_desc":
                        result = result.OrderByDescending(m => m.Quality);
                        break;
                    default:
                        break;
                }
            }
            return result;
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

        public WoodPellet? Remove(int id)
        {
            WoodPellet? woodPelletToRemove = GetById(id);
            if (woodPelletToRemove != null)
            {
                _woodPellets.Remove(woodPelletToRemove);
                return woodPelletToRemove;
            }
            return null;
        }
    }
}


