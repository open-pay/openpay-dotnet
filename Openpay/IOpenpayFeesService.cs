using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface IOpenpayFeesService
    {
        List<Transaction> Details(int year, int month, string fee_type, PaginationParams paginationParams);
        OpenpayFeesSummary Summary(int year, int month);
    }
}