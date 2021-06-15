using Api.Pricex.myDB;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class ImportFileRepo
    {
        public pedb_devContext _context { get; }
        public ImportFileRepo(pedb_devContext context)
        {
            _context = context;
        }

        public OfferPaymentTransactions GetPaymentForImport(int payment_id)
        {
            var payment = _context.OfferPaymentTransactions.FirstOrDefault(e => e.Id == payment_id);
            if(payment == null)
            {
                var a = payment.Commission;
            }
            return payment;
        }

        public async Task<string> Import(IFormFile file, int import_id, string page)
        {
            string folder = Path.Combine("upload", page);
            string path = Path.Combine(Directory.GetCurrentDirectory(), folder);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            var model = GetPaymentForImport(import_id);

            if (model != null)
            {
                //model.Invoice = file.FileName;
                model.Status = 1;
                model.UpdatedAt = DateTime.Now;

                _context.OfferPaymentTransactions.Update(model);
                _context.SaveChanges();

                return String.Format("{0}/{1}", folder,file.FileName);
            }

            return String.Format("{0}/{1}", folder, file.FileName);
        }
    }
}
