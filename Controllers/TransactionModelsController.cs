using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transaction.Data;
using Transaction.Models;

namespace Transaction.Controllers
{
    public class TransactionModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionModelsController(ApplicationDbContext context)
        {
           _context = context; 
        }
          
        public IActionResult Index()
        {
            IEnumerable<TransactionModel> transactionList = _context.Transactions;
            return View(transactionList);
        }

        //  GET: Create
        public  IActionResult Create()
        {
            return View();
        }
        // GET: /Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionModel  item)
        {
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);         
        }

        //  GET: Edit
        public async Task<IActionResult> Edit(int? transId)
        {
            if(transId == null)

            {
                return NotFound();
            }
            var item = await _context.Transactions.FindAsync(transId);
            
            if(transId == null)
            {
                return NotFound();
            }
            return View(item);
        }
        // GET: /Edit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int transId, TransactionModel item)
        {

            if (transId != item.TransId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {             
                _context.Transactions.Update(item);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
            return View(item);
        }


        // GET: /Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? transId)
        {
            if (transId == null)
            {
                return NotFound();
            }

            var item = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransId == transId);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: /Delete/5
        [Authorize]
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int transId)
        {
            var item = await _context.Transactions.FindAsync(transId);
            if(item == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}