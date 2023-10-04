using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IArtistBL
    {
        public void Create(Artist artist);
        public List<Artist> Read();
        public Artist Read(int artistId);
        public void Update(Artist artist);
        public void Delete(int artistId);
    }
}
