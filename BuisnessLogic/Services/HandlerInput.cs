using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{
    public class HandlerInput
    {
        private Action<Exception>? ActionLog { get; set; }
        public HandlerInput(Action<Exception>? log = null)
        {
            ActionLog = log;
        }
        public bool Initaction(UserAction init, User user)
        {

            if (init is null) return false;
            try
            {
                return init(user);
            }
            catch (Exception ex)
            {
                if (ActionLog is not null) ActionLog(ex);
                return false;
            }
        }
    }
}
