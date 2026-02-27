using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using NutrientCalculator;
using NutrientCalculator.Models;

namespace NutrientCalculator.DataSeeds;

static public class SeedRuner
{
    static async public Task RunAllIfNeed(AppDBContext dBContext)
    {
        if(await dBContext.Nutrients.AnyAsync()) 
            await NutrientSeed(dBContext);
        if(await dBContext.Products.AnyAsync())
            await ProductSeed(dBContext);
    }

    static async public Task RunAllHardRestart(AppDBContext dBContext)
    {
        await NutrientSeed(dBContext, ReSeed: true);
        await ProductSeed(dBContext,  ReSeed: true);
    }
    static async public Task<bool> NutrientSeed(AppDBContext dBContext, bool ReSeed = false)
    {
        if(ReSeed) dBContext.Nutrients.RemoveRange(dBContext.Nutrients);
        if(await dBContext.Nutrients.AnyAsync()) return false;

        var nutrients = new List<NutrientEntity>
            {
                new() { Name = "Вода",                              UnitType = UnitTypes.g,    NutrientType = NutrientTypes.Macro,                  Essential = true },     //Общие                     //Вода, г
                new() { Name = "Энергия",                           UnitType = UnitTypes.kkal, NutrientType = NutrientTypes.Macro,                  Essential = true },     //Энергия, кКал
                new() { Name = "Белки",                             UnitType = UnitTypes.g,    NutrientType = NutrientTypes.Macro,                  Essential = true },     //Белки, г
                new() { Name = "Жиры",                              UnitType = UnitTypes.g,    NutrientType = NutrientTypes.Macro,                  Essential = true },     //Жиры, г
                new() { Name = "Углеводы",                          UnitType = UnitTypes.g,    NutrientType = NutrientTypes.Macro,                  Essential = true },     //Углеводы, г
                new() { Name = "Волокна",                           UnitType = UnitTypes.g,    NutrientType = NutrientTypes.Macro,                  Essential = true },     //Волокна, г
                new() { Name = "Сахара",                            UnitType = UnitTypes.g,    NutrientType = NutrientTypes.Macro,                  Essential = true },     //Сахара, г
                new() { Name = "Кальций",                           UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Minerals,               Essential = true },     //Минералы                      //Кальций, Ca, мг
                new() { Name = "Железо",                            UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Minerals,               Essential = true },     //Железо, Fe, мг
                new() { Name = "Магний",                            UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Minerals,               Essential = true },     //Магний, Mg, мг    
                new() { Name = "Фосфор",                            UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Minerals,               Essential = true },     //Фосфор, P, мг
                new() { Name = "Калий",                             UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Minerals,               Essential = true },     //Калий, K, мг
                new() { Name = "Натрий",                            UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Minerals,               Essential = true },     //Натрий, Na, мг
                new() { Name = "Цинк",                              UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Minerals,               Essential = true },     //Цинк, Zn, мг
                new() { Name = "Медь",                              UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Minerals,               Essential = true },     //Медь, Cu, мг
                new() { Name = "Марганец",                          UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Minerals,               Essential = true },     //Марганец, Mn, мг
                new() { Name = "Селен",                             UnitType = UnitTypes.mkg,  NutrientType = NutrientTypes.Minerals,               Essential = true },     //Селен, Se, мкг
                new() { Name = "Фтор",                              UnitType = UnitTypes.mkg,  NutrientType = NutrientTypes.Minerals,               Essential = true },     //Фтор, F, мкг
                new() { Name = "C, аскорбиновая к-та",              UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Vitamins,               Essential = true },     //C, аскорбиновая к-та, мг    //Витамины   
                new() { Name = "B1, тиамин",                        UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Vitamins,               Essential = true },     //B1, тиамин, мг
                new() { Name = "B2, рибофлавин",                    UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Vitamins,               Essential = true },     //B2, рибофлавин, мг
                new() { Name = "B3, ниацин",                        UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Vitamins,               Essential = true },     //B3, ниацин, мг
                new() { Name = "B6, пиридоксин",                    UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Vitamins,               Essential = true },     //B6, пиридоксин, мг
                new() { Name = "B9, фолаты",                        UnitType = UnitTypes.mkg,  NutrientType = NutrientTypes.Vitamins,               Essential = true },     //B9, фолаты, мкг
                new() { Name = "В12, кобаламин"    ,                UnitType = UnitTypes.mkg,  NutrientType = NutrientTypes.Vitamins,               Essential = true },     //В12, кобаламин, мкг
                new() { Name = "A, ретинол",                        UnitType = UnitTypes.mkg,  NutrientType = NutrientTypes.Vitamins,               Essential = true },     //A, ретинол, мкг
                new() { Name = "А, ретинол"    ,                    UnitType = UnitTypes.ME,   NutrientType = NutrientTypes.Vitamins,               Essential = false},     //А, ретинол, МЕ
                new() { Name = "E, α-токоферол",                    UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Vitamins,               Essential = true },     //E, α-токоферол, мг
                new() { Name = "D (D2+D3)",                         UnitType = UnitTypes.mkg,  NutrientType = NutrientTypes.Vitamins,               Essential = true },     //D (D2+D3), мкг
                new() { Name = "D, "    ,                           UnitType = UnitTypes.ME,   NutrientType = NutrientTypes.Vitamins,               Essential = false},     //D, МЕ
                new() { Name = "K, филлохинон",                     UnitType = UnitTypes.mkg,  NutrientType = NutrientTypes.Vitamins,               Essential = true },     //K, филлохинон, мкг
                new() { Name = "B5, пантотеновая к-та",             UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Vitamins,               Essential = true },     //B5, пантотеновая к-та, мг
                new() { Name = "В4, Холин",                         UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Vitamins,               Essential = true },     //В4, холин, мг
                new() { Name = "Бетаин",                            UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Vitamins,               Essential = false },    //Бетаин, мг
                new() { Name = "Насыщенные"      ,                  UnitType = UnitTypes.g,    NutrientType = NutrientTypes.FattyAcids,             Essential = false },    //Жирные кислоты                        //Насыщенные,  г
                new() { Name = "Мононенасыщенные",                  UnitType = UnitTypes.g,    NutrientType = NutrientTypes.FattyAcids,             Essential = false },    //Мононенасыщенные,  г
                new() { Name = "Полиненасыщенные",                  UnitType = UnitTypes.g,    NutrientType = NutrientTypes.FattyAcids,             Essential = false },    //Полиненасыщенные,  г
                new() { Name = "Холестерин",                        UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.FattyAcids,             Essential = false },    //Холестерин, мг
                new() { Name = "Триптофан",                         UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = true },     //Аминокислоты                      //Триптофан, г
                new() { Name = "Треонин",                           UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = true },     //Треонин, г
                new() { Name = "Изолейцин",                         UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = true },     //Изолейцин, г
                new() { Name = "Лейцин",                            UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = true },     //Лейцин, г
                new() { Name = "Лизин",                             UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = true },     //Лизин, г
                new() { Name = "Метионин",                          UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = true },     //Метионин, г
                new() { Name = "Цистин",                            UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = false },    //Цистин, г
                new() { Name = "Фенилаланин",                       UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = true },     //Фенилаланин, г
                new() { Name = "Тирозин",                           UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = false },    //Тирозин, г
                new() { Name = "Валин",                             UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = true },     //Валин, г
                new() { Name = "Аргинин",                           UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = false },    //Аргинин, г
                new() { Name = "Гистидин",                          UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = true },     //Гистидин, г
                new() { Name = "Аланин",                            UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = false },    //Аланин, г
                new() { Name = "Аспарагиновая кислота",             UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = false },    //Аспарагиновая кислота, г
                new() { Name = "Глутаминовая кислота",              UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = false },    //Глутаминовая кислота, г
                new() { Name = "Глицин",                            UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = false },    //Глицин, г
                new() { Name = "Пролин",                            UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = false },    //Пролин, г
                new() { Name = "Серин",                             UnitType = UnitTypes.g,    NutrientType = NutrientTypes.AminoAcids,             Essential = false },    //Серин, г
                new() { Name = "Омега-3 (линоленовая)",             UnitType = UnitTypes.g,    NutrientType = NutrientTypes.EssentialFattyAcids,    Essential = true },     //Омега-3 (линоленовая), г //Незамен. жирные к-ты (средн. значение)    
                new() { Name = "Омега-6 (линолевая)",               UnitType = UnitTypes.g,    NutrientType = NutrientTypes.EssentialFattyAcids,    Essential = false },    //Омега-6 (линолевая), г 
                new() { Name = "Алкоголь",                          UnitType = UnitTypes.g,    NutrientType = NutrientTypes.Drugs,                  Essential = false },    //Алкоголь, г               //Наркотики
                new() { Name = "Кофеин",                            UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Drugs,                  Essential = false },    //Кофеин, мг
                new() { Name = "Теобромин",                         UnitType = UnitTypes.mg,   NutrientType = NutrientTypes.Drugs,                  Essential = false },    //Теобромин, мг

            };

        dBContext.Nutrients.AddRange(nutrients);
        await dBContext.SaveChangesAsync();

        return true;
    }

    static public async Task<bool> ProductSeed(AppDBContext _dbContext, string FileName = "Nutrient_Table.xlsx", bool ReSeed = false)
    {
        if(ReSeed) _dbContext.Products.RemoveRange(_dbContext.Products);
        if(await _dbContext.Products.AnyAsync())
            return false;

        using var workbook = new XLWorkbook(@"Dataseeds/" + FileName);
        if(workbook == null) return false;

        var nutrients = await _dbContext.Nutrients.ToListAsync();

        foreach(var workSheet in workbook.Worksheets)
        {
            string CategoryName = workSheet.Name;
            string tempName = string.Empty;
            for(int colunmNumber = 4; colunmNumber <= workSheet.LastColumnUsed().ColumnNumber(); colunmNumber++)
            {
                string Name = string.Empty;
                string State = string.Empty;

                // Попробуем прочесть название/состояние
                workSheet.Cell(1, colunmNumber).TryGetValue<string>(out Name);
                if(string.IsNullOrWhiteSpace(Name))
                    Name = tempName;
                else
                    tempName = Name;
                workSheet.Cell(2, colunmNumber).TryGetValue<string>(out State);

                var product = new ProductEntity
                {
                    Name = Name,
                    State = State,
                    CategoryType = CategoryName,
                    ProductNutrients = new List<ProductNutrientEntity>()
                };

                for(int row = 5; row < workSheet.LastRowUsed().RowNumber(); row++)
                {
                    if(workSheet.Cell(row, colunmNumber).TryGetValue<decimal>(out decimal s) && s != 0)
                    {
                        workSheet.Cell(row, 1).TryGetValue<string>(out string nutrientName);
                        var nutrient = nutrients.FirstOrDefault(n => nutrientName.Contains(n.Name));
                        if(nutrient != null)
                        {
                            product.ProductNutrients.Add(new ProductNutrientEntity
                            {
                                Product = product,
                                Nutrient = nutrient,
                                Amount = s
                            });
                        }
                    }
                }
                if(product.ProductNutrients.Count > 0)
                {
                    _dbContext.Products.Add(product);
                }
            }
        }
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
