using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Entities
{
	public partial class Authorization : BaseEntity
    {
        public Authorization()
        {
            TitleAuthorizations = new HashSet<TitleAuthorization>();
        }

        public int AuthorizationId { get; set; }
        public string AuthroizationName { get; set; }

        public virtual ICollection<TitleAuthorization> TitleAuthorizations { get; set; }
    }
}
