using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Entities
{
    public partial class TitleAuthorization : BaseEntity
    {
        public int TitleId { get; set; }
        public int AuthorizationId { get; set; }
        public int PageId { get; set; }

        public virtual Authorization Authorization { get; set; }
        public virtual Page Page { get; set; }
        public virtual Title Title { get; set; }
    }
}
