using Microsoft.EntityFrameworkCore;
using MicroService_Email.Data;
using MicroService_Email.Models;

namespace MicroService_Email.Services
{
    public class EmailService
    {
        private DbContextOptions<AppDbContext> options;
        public EmailService(DbContextOptions<AppDbContext> options)
        {
            this.options = options;
        }

        public async Task SaveData(EmailLoggers emailLoggers)
        {
            //create _context

            var _context = new AppDbContext(this.options);
            _context.EmailLoggers.Add(emailLoggers);
            await _context.SaveChangesAsync();
        }
    }
}
