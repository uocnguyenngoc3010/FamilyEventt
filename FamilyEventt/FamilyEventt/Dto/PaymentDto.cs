using FamilyEventt.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyEventt.Dto
{
    public class PaymentDto
    {
        public string PaymentId { get; set; }
        public string EventId { get; set; }
        public decimal Amount { get; set; }
        public string PayContent { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        // public virtual EventOrder EventOrder { get; set; }
        // public virtual ICollection<Refund> Refund { get; set; }
    }
}
