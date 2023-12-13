using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Entities
{
    public partial class Rule : BaseEntity
    {
        public int Id { get; set; }
        public decimal? MaxAmount { get; set; }
        public decimal? MinAmount { get; set; }
        public DateTime? Date { get; set; }
        public int? TitleId { get; set; }

        public virtual Title Title { get; set; }
    }
}
