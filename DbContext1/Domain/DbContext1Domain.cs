
using System.ComponentModel.DataAnnotations;

namespace TwoDbContexts.DbContext1.Domain
{
    public class DbContext1Domain
    {
        [Key]
        public int SomeNumber { get; set; }
        public string SomeString { get; set; }
    }
}
