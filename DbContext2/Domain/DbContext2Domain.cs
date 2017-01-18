
using System.ComponentModel.DataAnnotations;

namespace TwoDbContexts.DbContext2.Domain
{
    public class DbContext2Domain
    {
        [Key]
        public int SomeNumber { get; set; }
        public string SomeString { get; set; }
    }
}
