using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Entities
{
	public partial class Page : BaseEntity
    {
        public Page()
        {
            TitleAuthorizations = new HashSet<TitleAuthorization>();
        }

        public int PageId { get; set; }
        public string PageName { get; set; }
        public string Path { get; set; }

        public virtual ICollection<TitleAuthorization> TitleAuthorizations { get; set; }
    }
}
