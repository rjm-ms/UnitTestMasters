﻿using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IPromotionService
    {
        Task<Result> PromoteInternalEmployeeAsync(InternalEmployee employee);
    }
}
