namespace Trip
{
    using System.Collections.Generic;
    using System.Linq;
    public class Converter
    {
        /// <summary>
        /// На вход получаем "Карточки".
        /// При первом проходе по ним формируем 2 словаря.
        /// 1) Словарь соответствия между названием города и его индексом (индекс присваивается динамически)
        /// 2) Словарь связей идексов отправления и индексов прибытия. Можно использовать и одномерный массив, 
        /// в котором номер отправления - индекс элемента, а номер прибытия - значение элемента, но возникает проблема с последующим поиском.
        /// Получив эти словари, из 2-го линейно строится цепочка отправлений (от конца к началу). А благодаря 1-му словарю восстанавливаются названия городов.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string[] TourListToChain(List<Tour> list)
        {
            var table = new Dictionary<string, int>();
            var chain = new Dictionary<int, int>();

            foreach (var tour in list) 
            {
                var index = table.Count;
                if (!table.ContainsKey(tour.From)) ////Если в 1-м словаре нет города отправления, то, соответсвенно, не и города прибытия. Поэтому добавляем оба и связываем их.
                {
                    table.Add(tour.From, index);
                    table.Add(tour.To, index + 1);
                    chain.Add(index, index + 1);
                    chain.Add(index + 1, -1);
                }
                else if (!table.ContainsKey(tour.To))//// Город отправления в словаре есть, города прибытия - нет. Добавляем город прибытия и связываем с городом отправления.
                {
                    table.Add(tour.To, index);
                    chain[table[tour.From]] = index;
                    chain.Add(index, -1);
                }
                else //// Если оба города в словаре есть, то просто добавляем связь.
                {
                    chain[table[tour.From]] = table[tour.To];
                }
            }

            string[] sortChain = new string[chain.Count];
            var chainElement = chain.First(x => x.Value == -1).Key; //// Последний город не является городом отправления, поэтому в таблице связий город прибытия для него стоит -1;
            for (var i = chain.Count - 1; i >= 0; i--)
            {
                ////Далее по цепочке от последнего города к первому восстанавливаем весь путь.
                sortChain[i] = table.FirstOrDefault(x => x.Value == chainElement).Key;
                chainElement = chain.FirstOrDefault(x => x.Value == chainElement).Key;
            }

            return sortChain;
        }
    }
}
