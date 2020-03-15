using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Mariage.Models
{
    public class MariageUser : IdentityUser
    {
        public virtual Participation Participation { get; set; }
    }
}