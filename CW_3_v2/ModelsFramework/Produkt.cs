using System;
using System.Collections.Generic;

namespace CW_3_v2.ModelsFramework
{
    public partial class Produkt
    {
        public int IdProdukt { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public int? IdKategoria { get; set; }
    }
}
