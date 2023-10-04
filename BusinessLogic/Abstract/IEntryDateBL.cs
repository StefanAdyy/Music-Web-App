using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IEntryDateBL
    {
        public void Create(EntryDate entryDate);
        public void InsertCurrentEntryDate();
        public void UpdateMinutes(bool hasExited=true);
        public int CountMinutes();
        public int DailyAverageTime();
        public List<EntryDate> Read();
        public EntryDate Read(int entryDateId);
        public EntryDate ReadLastEntry();
        public void Update(EntryDate entryDate);
        public void Delete(int entryDateId);
    }
}
