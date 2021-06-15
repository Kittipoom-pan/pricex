using Api.Pricex.myDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo.CustomerService
{
    public class CaseSummaryRepo
    {
        public pedb_devContext _context { get; }
        public CaseSummaryRepo(pedb_devContext context)
        {
            _context = context;
        }

        public CaseSummary GetCaseSummary(int id)
        {
            return _context.CaseSummary.OrderByDescending(p => p.Seq).SingleOrDefault(e => e.Id == id);
        }

        public List<CaseSummary> GetAllCaseSummary(int booking_id)
        {
            return _context.CaseSummary.Where(e => e.BookingId == booking_id).OrderByDescending(c => c.Seq).ToList();
        }

        public async Task<String> EditCaseSummary(CaseSummary model, int id)
        {
            var caseSummary = GetCaseSummary(id);

            if (caseSummary == null)
            {
                return null;
            }
            else
            {
                caseSummary.Seq = model.Seq;
                caseSummary.Date = model.Date;
                caseSummary.From = model.From;
                caseSummary.Channel = model.Channel;
                caseSummary.Note = model.Note;
                caseSummary.By = model.By;
                caseSummary.UpdatedAt = DateTime.Now;

                _context.CaseSummary.Update(caseSummary);
                _context.SaveChanges();
            }

            return "Case summary update successfully";
        }

        public async Task<String> AddCaseSummary(CaseSummary model, int booking_id)
        {
            var bookingReport = new CaseSummary
            {
                BookingId = booking_id,
                Seq = model.Seq,
                Date = model.Date,
                From = model.From,
                Channel = model.Channel,
                Note = model.Note,
                By = model.By,
                CreatedAt = DateTime.Now
            };

            _context.CaseSummary.Add(bookingReport);
            _context.SaveChanges();

            return "Create case summary successfully";
        }
    }
}
