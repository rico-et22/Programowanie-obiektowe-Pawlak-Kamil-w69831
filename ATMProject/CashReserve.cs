using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class CashReserve
    {
        public Dictionary<int, int> Notes { get; set; }

        public CashReserve(Dictionary<int, int> initialNotes)
        {
            if (initialNotes != null && initialNotes.Count > 0)
            {
                Notes = new Dictionary<int, int>(initialNotes);
            }
        }

        public bool CanDispense(decimal amount)
        {
            decimal total = Notes.Sum(n => n.Key * n.Value);
            if (total < amount) return false;

            decimal remaining = amount;
            foreach (var note in Notes.OrderByDescending(n => n.Key))
            {
                int countNeeded = (int)(remaining / note.Key);
                if (countNeeded > note.Value)
                    countNeeded = note.Value;
                remaining -= countNeeded * note.Key;
            }
            return remaining == 0;
        }

        public bool Dispense(decimal amount, out Dictionary<int, int> dispensed)
        {
            dispensed = new Dictionary<int, int>();

            if (!CanDispense(amount))
                return false;

            decimal remaining = amount;
            var sortedNotes = Notes.OrderByDescending(n => n.Key).ToList();

            foreach (var note in sortedNotes)
            {
                int noteValue = note.Key;
                int available = note.Value;
                int countNeeded = (int)(remaining / noteValue);
                if (countNeeded > available)
                    countNeeded = available;
                if (countNeeded > 0)
                {
                    dispensed[noteValue] = countNeeded;
                    remaining -= countNeeded * noteValue;
                }
            }

            if (remaining == 0)
            {
                foreach (var d in dispensed)
                {
                    Notes[d.Key] -= d.Value;
                }
                return true;
            }
            return false;
        }

        public void AddCash(int denomination, int count)
        {
            if (Notes.ContainsKey(denomination))
                Notes[denomination] += count;
            else
                Notes[denomination] = count;
        }

        public void DisplayReserve()
        {
            Console.WriteLine("Aktualne zapasy gotówki:");
            foreach (var note in Notes.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{note.Key} PLN: {note.Value} szt.");
            }
        }
    }
}
