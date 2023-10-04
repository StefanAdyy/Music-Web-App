using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEntryDateDataAccess
    {
        public void Create(EntryDate entryDate);
        public List<EntryDate> Read();
        public EntryDate Read(int entryDateId);
        public EntryDate ReadLastEntry();
        public int DailyAverageTime();
        public void Update(EntryDate entryDate);
        public void Delete(int entryDateId);
    }
}
