using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface INationalityDataAccess
    {
        public void Create(Nationality nationality);
        public List<Nationality> Read();
        public Nationality Read(int nationalityId);
        public void Update(Nationality nationality);
        public void Delete(int nationalityId);
    }
}
