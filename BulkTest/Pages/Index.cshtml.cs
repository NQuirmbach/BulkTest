using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkTest.Model;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BulkTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TestDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, TestDbContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task OnGet()
        {
            try
            {
                var teacher = new Teacher { FirstName = "Max", LastName = "Musterman", Subjects = "Math, Sports" };
                var student = new Student { FirstName = "Lina", LastName = "Maier", Teacher = teacher };

                var persons = new List<Person> { teacher, student };

                _context.Persons.AddRange(persons);
                await _context.BulkInsertOrUpdateOrDeleteAsync(persons);

            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while bulk insert");
            }
        }
    }
}
