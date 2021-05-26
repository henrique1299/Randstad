using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Randstad.Models
{
    public class Coin
    {
        [Key]
        public int id { get; set; }
        public String symbol { get; set; }
        public String name { get; set; }
        public String nameid { get; set; }
        public int rank { get; set; }
        public double price_usd { get; set; }
        public double percent_change_24h { get; set; } 
        public double percent_change_1h { get; set; } 
        public double percent_change_7d { get; set; }  
        public double market_cap_usd { get; set; }  
        public double volume24 { get; set; } 
        public double volume24_native { get; set; }  
        public double csupply { get; set; }  
        public double price_btc { get; set; } 
        public double tsupply { get; set; } 
        public double msupply { get; set; }  
    }
}
