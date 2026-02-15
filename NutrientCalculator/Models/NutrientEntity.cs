using System;
using System.Collections.Generic;

namespace NutrientCalculator.Models
{
    public enum UnitTypes
    {
        kkal,
        g,
        mg,
        mkg,
        ME
    }
    public enum NutrientTypes
    {
        Macro,                              //Макро
        Minerals,                           //Минералы
        Vitamins,                           //Витамины
        FattyAcids,                         //Жирные кислоты
        AminoAcids,                         //Аминокислоты
        EssentialFattyAcids,                //Незамен. жирные к-ты (средн. значение)		
        Drugs                               //Наркотики
    }
    public class NutrientEntity()
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required UnitTypes UnitType { get; set; }
        public required NutrientTypes NutrientType { get; set; }
        public bool Essential { get; set; } = false;
        public ICollection<ProductNutrientEntity> ProductNutrients { get; set; } = [];
        public decimal Norma { get; set; }
    }

}
