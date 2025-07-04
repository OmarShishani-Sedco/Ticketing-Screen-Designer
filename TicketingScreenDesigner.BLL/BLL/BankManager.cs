﻿using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.DAL.DAL;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.BLL.BLL
{
    public class BankManager : IBankManager
    {
        private readonly IBankDAL _dal;

        public BankManager(IBankDAL dal)
        {
            _dal = dal;
        }

        public BankModel GetOrCreateBank(string name)
        {
            var existing = _dal.GetBankByName(name);
            if (existing != null)
                return existing;

            int newId = _dal.AddBank(name);
            return new BankModel { BankId = newId, BankName = name };
        }
        public List<BankModel> GetAllBanks()
        {
            return _dal.GetAllBanks();
        }
    }
}
