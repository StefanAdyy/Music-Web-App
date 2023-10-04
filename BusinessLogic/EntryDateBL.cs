using BusinessLogic.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EntryDateBL : IEntryDateBL
    {
        IEntryDateDataAccess _entryDateDataAccess;
        public EntryDateBL(IEntryDateDataAccess entryDateDataAccess)
        {
            _entryDateDataAccess = entryDateDataAccess ?? throw new ArgumentNullException("IEntryDateDataAccess cannot be null");
        }
        public void Create(EntryDate entryDate)
        {
            _entryDateDataAccess.Create(entryDate);
        }

        public void Delete(int entryDateId)
        {
            _entryDateDataAccess.Delete(entryDateId);
        }

        public void InsertCurrentEntryDate()
        {
            var lastEntry = _entryDateDataAccess.ReadLastEntry();

            EntryDate currentEntryDate = new EntryDate();
            currentEntryDate.LastEntryHour = DateTime.Now;
            currentEntryDate.Date = currentEntryDate.LastEntryHour;
            currentEntryDate.HasExited = false;

            if (lastEntry.EntryDateId != 0 && lastEntry.Date.Date == currentEntryDate.Date.Date)
            {
                if (lastEntry.HasExited)
                {
                    currentEntryDate.EntryDateId = lastEntry.EntryDateId;
                    currentEntryDate.Minutes = lastEntry.Minutes;
                    _entryDateDataAccess.Update(currentEntryDate);
                }
            }
            else
            {
                _entryDateDataAccess.Create(currentEntryDate);
            }
        }

        public void UpdateMinutes(bool hasExited=true)
        {
            var lastEntry = _entryDateDataAccess.ReadLastEntry();

            TimeSpan timeSpan = DateTime.Now - lastEntry.LastEntryHour;
            lastEntry.Minutes = lastEntry.Minutes + Convert.ToInt32(timeSpan.TotalMinutes);
            lastEntry.LastEntryHour = DateTime.Now;
            lastEntry.HasExited = hasExited;

            _entryDateDataAccess.Update(lastEntry);
        }

        public List<EntryDate> Read()
        {
            return _entryDateDataAccess.Read();
        }

        public EntryDate Read(int entryDateId)
        {
            return _entryDateDataAccess.Read(entryDateId);
        }

        public EntryDate ReadLastEntry()
        {
            return _entryDateDataAccess.ReadLastEntry();
        }

        public void Update(EntryDate entryDate)
        {
            _entryDateDataAccess.Update(entryDate);
        }

        public int CountMinutes()
        {
            var lastEntry = _entryDateDataAccess.ReadLastEntry();

            TimeSpan timeSpan = DateTime.Now - lastEntry.LastEntryHour;
            return lastEntry.Minutes + Convert.ToInt32(timeSpan.TotalMinutes);
        }

        public int DailyAverageTime()
        {
            return _entryDateDataAccess.DailyAverageTime();
        }
    }
}
