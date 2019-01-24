using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HorizonWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorizonWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Bill")]
    public class BillController : Controller
    {
        private readonly HorizonWebApiContext _context;

        public BillController(HorizonWebApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostBill([FromBody] BillPost billpost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bill = new Bill
            {
                customerName = billpost.customerName,
                total = billpost.total
            };

            bill.BillItems = new List<BillItem>();
           
            foreach (int it in billpost.itemIds)
            {
                bill.BillItems.Add(new BillItem {
                    ItemId=it,
                    BillId=bill.billId
                });
            }


            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBill", new { id = bill.billId }, bill);

            
        }

    }
}