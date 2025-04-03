using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models.Result
{
    public class SaltResultModel
    {
        public SaltResultModel() { }
        public SaltResultModel(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public string Hash { get; set; } = null!;
        public string Salt { get; set; } = null!;
    }
}
