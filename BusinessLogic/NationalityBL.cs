using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NationalityBL:INationalityBL
    {
        private readonly INationalityDataAccess _nationalityDataAccess;

        public NationalityBL(INationalityDataAccess nationalityDataAccess)
        {
            _nationalityDataAccess=nationalityDataAccess ?? throw new ArgumentNullException("INationalityDataAccess cannot be null");
        }
        public void Create(Nationality nationality)
        {
            _nationalityDataAccess.Create(nationality);
        }

        public void Delete(int nationalityId)
        {
            _nationalityDataAccess.Delete(nationalityId);
        }

        public List<Nationality> Read()
        {
            return _nationalityDataAccess.Read();
        }

        public Nationality Read(int nationalityId)
        {
            return _nationalityDataAccess.Read(nationalityId);
        }

        public void Update(Nationality nationality)
        {
            _nationalityDataAccess.Update(nationality);
        }
    }
}
