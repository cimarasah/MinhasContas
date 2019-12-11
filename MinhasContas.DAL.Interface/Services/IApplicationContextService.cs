using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasContas.DAL.Interface.Services
{
    public interface IApplicationContextService
    {
        string CurrentUser { get; }
        int CurrentLevel { get; }
    }
}
