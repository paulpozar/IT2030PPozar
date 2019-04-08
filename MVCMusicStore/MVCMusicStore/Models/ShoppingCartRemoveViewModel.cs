using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore.Models.ViewModels
{
    public class ShoppingCartRemoveViewModel
    {
        public int DeleteId; //Match up with RecordId
        public decimal CartTotal;
        public int ItemCount;
        public int CartCount;
        public string Message;
    }
}