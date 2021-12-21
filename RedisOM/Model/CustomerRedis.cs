using Redis.OM.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisOM.Model
{
    [Document]
    public class CustomerRedis
    {
        [Indexed(Sortable = true)] public string FirstName { get; set; }
        [Indexed(Sortable = true)] public string LastName { get; set; }
        [Indexed(Sortable = true)] public string Email { get; set; }
        [Indexed(Sortable = true)] public int Age { get; set; }
    }
}
