using NutrientCalculator.Models;
using NutrientCalculator;
using ClosedXML.Excel;

namespace NutrientCalculator.DataSeeds
{
    public class SeedRuner()
    {       

        static async public Task<bool> NutrientSeed(AppDBContext dBContext)
        {
            if(dBContext.Nutrients.Any())
            {
                Console.WriteLine("Nutrients ware already fiiled");
                return false;
            }
            var nutrients = new List<NutrientEntity>
            {
                //Общие
                //Вода, г
                new NutrientEntity { Name = "Вода", UnitType = UnitTypes.g,NutrientType = NutrientTypes.Macro,Essential = true },
                //Энергия, кКал
                new NutrientEntity { Name = "Энергия", UnitType = UnitTypes.kkal,NutrientType = NutrientTypes.Macro,Essential = true },
                //Белки, г
                new NutrientEntity { Name = "Белки", UnitType = UnitTypes.g,NutrientType = NutrientTypes.Macro,Essential = true },
                //Жиры, г
                new NutrientEntity { Name = "Жиры", UnitType = UnitTypes.g,NutrientType = NutrientTypes.Macro,Essential = true },
                //Углеводы, г
                new NutrientEntity { Name = "Углеводы", UnitType = UnitTypes.g,NutrientType = NutrientTypes.Macro,Essential = true },
                //Волокна, г
                new NutrientEntity { Name = "Волокна", UnitType = UnitTypes.g,NutrientType = NutrientTypes.Macro,Essential = true },
                //Сахара, г
                new NutrientEntity { Name = "Сахара", UnitType = UnitTypes.g,NutrientType = NutrientTypes.Macro,Essential = true },
                //Минералы
                //Кальций, Ca, мг
                new NutrientEntity { Name = "Кальций", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Железо, Fe, мг
                new NutrientEntity { Name = "Железо", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Магний, Mg, мг    
                new NutrientEntity { Name = "Магний", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Фосфор, P, мг
                new NutrientEntity { Name = "Фосфор", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Калий, K, мг
                new NutrientEntity { Name = "Калий", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Натрий, Na, мг
                new NutrientEntity { Name = "Натрий", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Цинк, Zn, мг
                new NutrientEntity { Name = "Цинк", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Медь, Cu, мг
                new NutrientEntity { Name = "Медь", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Марганец, Mn, мг
                new NutrientEntity { Name = "Марганец", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Селен, Se, мкг
                new NutrientEntity { Name = "Селен", UnitType = UnitTypes.mkg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Фтор, F, мкг
                new NutrientEntity { Name = "Фтор", UnitType = UnitTypes.mkg,NutrientType = NutrientTypes.Minerals,Essential = true },
                //Витамины
                //C, аскорбиновая к-та, мг
                new NutrientEntity { Name = "Витамин C", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Vitamins,Essential = true },
                //B1, тиамин, мг
                new NutrientEntity { Name = "Витамин B1", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Vitamins,Essential = true },
                //B2, рибофлавин, мг
                new NutrientEntity { Name = "Витамин B2", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Vitamins,Essential = true },
                //B3, ниацин, мг
                new NutrientEntity { Name = "Витамин B3", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Vitamins,Essential = true },
                //B6, пиридоксин, мг
                new NutrientEntity { Name = "Витамин B6", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Vitamins,Essential = true },
                //B9, фолаты, мкг
                new NutrientEntity { Name = "Витамин B9", UnitType = UnitTypes.mkg,NutrientType = NutrientTypes.Vitamins,Essential = true },
                //В12, кобаламин, мкг
                new NutrientEntity { Name = "Витамин B12", UnitType = UnitTypes.mkg,NutrientType = NutrientTypes.Vitamins,Essential = true },
                //A, ретинол, мкг
                new NutrientEntity { Name = "Витамин A", UnitType = UnitTypes.mkg,NutrientType = NutrientTypes.Vitamins,Essential = true },
                //А, ретинол, МЕ
                new NutrientEntity { Name = "Витамин A (МЕ)", UnitType = UnitTypes.ME,NutrientType = NutrientTypes.Vitamins},
                //E, α-токоферол, мг
                new NutrientEntity { Name = "Витамин E", UnitType = UnitTypes.mg,NutrientType = NutrientTypes.Vitamins,Essential = true },
                //D (D2+D3), мкг
                new NutrientEntity { Name = "Витамин D", UnitType = UnitTypes.mkg, NutrientType = NutrientTypes.Vitamins, Essential = true },
                //D, МЕ
                new NutrientEntity { Name = "Витамин D (МЕ)", UnitType = UnitTypes.ME, NutrientType = NutrientTypes.Vitamins },
                //K, филлохинон, мкг
                new NutrientEntity { Name = "Витамин K", UnitType = UnitTypes.mkg, NutrientType = NutrientTypes.Vitamins, Essential = true },
                //B5, пантотеновая к-та, мг
                new NutrientEntity { Name = "Витамин B5", UnitType = UnitTypes.mg, NutrientType = NutrientTypes.Vitamins, Essential = true },
                //В4, холин, мг
                new NutrientEntity { Name = "Холин", UnitType = UnitTypes.mg, NutrientType = NutrientTypes.Vitamins, Essential = true },
                //Бетаин, мг
                new NutrientEntity { Name = "Бетаин", UnitType = UnitTypes.mg, NutrientType = NutrientTypes.Vitamins, Essential = false },
                //Жирные кислоты
                //Насыщенные,  г
                new NutrientEntity { Name = "Насыщенные жирные кислоты", UnitType = UnitTypes.g, NutrientType = NutrientTypes.FattyAcids, Essential = false },
                //Мононенасыщенные,  г
                new NutrientEntity { Name = "Мононенасыщенные жирные кислоты", UnitType = UnitTypes.g, NutrientType = NutrientTypes.FattyAcids, Essential = false },
                //Полиненасыщенные,  г
                new NutrientEntity { Name = "Полиненасыщенные жирные кислоты", UnitType = UnitTypes.g, NutrientType = NutrientTypes.FattyAcids, Essential = false },
                //Холестерин, мг
                new NutrientEntity { Name = "Холестерин", UnitType = UnitTypes.mg, NutrientType = NutrientTypes.FattyAcids, Essential = false },
                //Аминокислоты
                //Триптофан, г
                new NutrientEntity { Name = "Триптофан", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = true },
                //Треонин, г
                new NutrientEntity { Name = "Треонин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = true },
                //Изолейцин, г
                new NutrientEntity { Name = "Изолейцин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = true },
                //Лейцин, г
                new NutrientEntity { Name = "Лейцин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = true },
                //Лизин, г
                new NutrientEntity { Name = "Лизин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = true },
                //Метионин, г
                new NutrientEntity { Name = "Метионин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = true },
                //Цистин, г
                new NutrientEntity { Name = "Цистин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = false },
                //Фенилаланин, г
                new NutrientEntity { Name = "Фенилаланин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = true },
                //Тирозин, г
                new NutrientEntity { Name = "Тирозин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = false },
                //Валин, г
                new NutrientEntity { Name = "Валин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = true },
                //Аргинин, г
                new NutrientEntity { Name = "Аргинин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = false },
                //Гистидин, г
                new NutrientEntity { Name = "Гистидин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = true },
                //Аланин, г
                new NutrientEntity { Name = "Аланин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = false },
                //Аспарагиновая кислота, г
                new NutrientEntity { Name = "Аспарагиновая кислота", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = false },
                //Глутаминовая кислота, г
                new NutrientEntity { Name = "Глутаминовая кислота", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = false },
                //Глицин, г
                new NutrientEntity { Name = "Глицин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = false },
                //Пролин, г
                new NutrientEntity { Name = "Пролин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = false },
                //Серин, г
                new NutrientEntity { Name = "Серин", UnitType = UnitTypes.g, NutrientType = NutrientTypes.AminoAcids, Essential = false }

            };
            dBContext.Nutrients.AddRange(nutrients);
            await dBContext.SaveChangesAsync();

            Console.WriteLine("Nutrients filled");
            return true;
        }

        static async public Task<bool> ProductSeed(AppDBContext _dbContext,string FileName = "Nutrient_Table.xlsx")
        {
            if(_dbContext.Products.Any()) 
                return false;

            using var workbook = new XLWorkbook(@"Dataseeds/" + FileName);
            if(workbook == null) return false;

            var products = new List<ProductEntity>();
            var nutrients = _dbContext.Nutrients;

            foreach(var workSheet in workbook.Worksheets)
            {
                string CategoryName = workSheet.Name;
                for(int colunmNumber = 4; colunmNumber <= workSheet.LastColumnUsed().ColumnNumber() ; colunmNumber++)
                {
                    string Name = string.Empty;
                    string State = string.Empty;

                    // Попробуем прочесть название/состояние
                    if(workSheet.Cell(1, colunmNumber).TryGetValue<string>(out Name) || Name == "")
                    {
                        workSheet.Cell(1, colunmNumber - 1).TryGetValue<string>(out Name);
                    }
                    workSheet.Cell(2, colunmNumber).TryGetValue<string>(out State);

                    var product = new ProductEntity
                    {
                        Name = Name,
                        State = State,
                        CategoryType = CategoryName,
                        ProductNutrients = []
                    };

                    for(int row = 5; row < workSheet.LastRowUsed().RowNumber(); row++)
                    {
                        if(workSheet.Cell(row, colunmNumber).TryGetValue<double>(out double s) && s != 0d)
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
                        products.Add(product);
                    }
                }
            }

            _dbContext.Products.AddRange(products);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
